using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Pabo.Calendar;

namespace WindowsFormsApp1
{
    class AutoSchedule
    {
        MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
        EmployeeController employeeControler = new EmployeeController();


        List<Personal> contractedEmployees = new List<Personal>();
        List<Personal> miscEmployees = new List<Personal>();

        //first list is day, second list is shift, third list is the personal assigned to the shift
        List<List<List<Personal>>> scheduledEmployees = new List<List<List<Personal>>>();

        public List<List<List<Personal>>> AutoScheduleEmployees(int weekNum, int year)
        {
            List<Personal> PersonalList = employeeControler.GetAllEmployees();

            //load shift preference and unwated days
            foreach (Personal p in PersonalList)
            {
                Employee employee = (Employee)p;
                employee.SetShiftPreference();
                employee.SetUnwatedDays();

                //employee.Contract == 1 ? contractedEmployees.Add(p) : miscEmployees.Add(p); 
                //line above error Only assignment, call, increment, decrement, await, and new object expressions can be used as a statement

                if (employee.Contract == 1) contractedEmployees.Add(p);
                else miscEmployees.Add(p);
            }

            //get the first day of the select week
            DateTime weekStartDate = FirstDateOfWeekISO8601(year, weekNum);

            //add 7 days to the list (aka 1 week)
            for (int i = 0; i < 7; i++)
            {
                scheduledEmployees.Add(new List<List<Personal>>());
            }

            //foreach day add 3 shifts to the list
            foreach (List<List<Personal>> shiftList in scheduledEmployees)
            {
                for (int i = 0; i < 3; i++)
                {
                    shiftList.Add(new List<Personal>());
                }
            }

            //run the scheduling code twice to make sure contractedEmployees get scheduled first
            ScheduleEmployees(weekStartDate, contractedEmployees);
            ScheduleEmployees(weekStartDate, miscEmployees);


            return scheduledEmployees;
        }

        private void ScheduleEmployees(DateTime weekStartDate, List<Personal> Employees)
        {
            //loop trough the days
            for (int d = 0; d < scheduledEmployees.Count(); d++)
            {
                //temp list so you can remove employees who already have a shift assigned on the current day
                List<Personal> TempEmployeeList = new List<Personal>();
                TempEmployeeList.Clear();
                TempEmployeeList.AddRange(Employees);

                //get the current date of the loop
                DateTime date = weekStartDate.AddDays(d);

                Day dayObj = GetDayId(date);
                dayObj.LoadShifts();
                List<Shift> shifts = dayObj.GetShifts();

                //loop trough the shifts
                for (int s = 0; s < scheduledEmployees[d].Count(); s++)
                {
                    Shift shift = shifts[s];
                    shift.LoadAssignedEmployees();

                    for (int i = 0; i < TempEmployeeList.Count(); i++)
                    {
                        //gets the employees assigned to the shift before
                        List<string> previousShift = GetPreviousShift(s, date);

                        //checks if the employee is already assigned to the shift
                        foreach (Personal p in shift.GetPersonal())
                        {
                            if (i >= TempEmployeeList.Count())
                            {
                                if (p.ToString() == TempEmployeeList[i].ToString())
                                {
                                    scheduledEmployees[d][s].Add(TempEmployeeList[i]);
                                    TempEmployeeList.RemoveAt(i);
                                }
                            }
                        }

                        Employee employee = (Employee)TempEmployeeList[i];

                        //checks if the min number of employees is reached if yes stops assigned employees for that shift
                        if (scheduledEmployees[d][s].Count() < shift.GetMinAssigned())
                        {
                            //checks if the employee was assigned in the previous shift
                            if (!previousShift.Contains(TempEmployeeList[i].ToString()))
                            {
                                //checks if shiftPreference matches
                                if (employee.GetShiftPreference().Contains(s) || employee.GetShiftPreference().Count() == 0)
                                {
                                    //checks if unwanteDays matches
                                    if (!employee.GetUnwatedDays().Contains(date))
                                    {
                                        scheduledEmployees[d][s].Add(TempEmployeeList[i]);

                                        //inserts the employee into the database (is also used to check if employee is assigned on previous shift
                                        InsertEmployee(shift.Id(), TempEmployeeList[i].Id);

                                        //removes employee from list so it can not be assigned again
                                        TempEmployeeList.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private Day GetDayId(DateTime day)
        {
            Day selectedDay = null;

            string query;
            query = $"SELECT * FROM `day` WHERE day = CAST(N'{day.ToString("yyyy-MM-dd")}' AS Date)";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = DatabaseInfo.connectionTimeout;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        DateTime dayDate = Convert.ToDateTime(reader["day"]);

                        selectedDay = new Day(id, day);
                    }
                    databaseConnection.Close();
                }
                else
                {
                    databaseConnection.Close();
                }
                databaseConnection.Close();
            }
            catch (MySqlException ex)
            {
                databaseConnection.Close();
                throw ex;
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
            }

            if (selectedDay == null)
            {
                selectedDay = InsertDayAndShifts(day);
            }

            return selectedDay;
        }

        private Day InsertDayAndShifts(DateTime date)
        {
            //insert new day and shifts
            string insertQuery = $"INSERT INTO day(day) VALUES(CAST(N'{date.ToString("yyyy-MM-dd")}' AS Date));";
            databaseConnection.Open();
            MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
            //commandDatabase.Parameters.AddWithValue("@day", date.ToString("yyyy-MM-dd"));
            commandDatabase.ExecuteNonQuery();
            long dayId = commandDatabase.LastInsertedId;

            //if (result != null) { dayId = Convert.ToInt32(result); }
            databaseConnection.Close();

            for (int i = 0; i < 3; i++)
            {
                //sets the default max assigned employees for a shift
                int max = 5;
                if (i == 2) { max = 2; }

                //sets the default min assigned employees for a shift
                int min = 2;

                //inserts a new shift and gets the id
                insertQuery = $"INSERT INTO shift(shifttype, min, max, day_id) VALUES(@shifttype, @min, @max, @dayId); select last_insert_id();";
                databaseConnection.Open();
                commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@shifttype", i);
                commandDatabase.Parameters.AddWithValue("@min", min);
                commandDatabase.Parameters.AddWithValue("@max", max);
                commandDatabase.Parameters.AddWithValue("@dayId", dayId);
                commandDatabase.ExecuteNonQuery();


                databaseConnection.Close();

            }

            Day selectedDay = null;
            string query;
            query = $"SELECT * FROM `day` WHERE id = {dayId}";

            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = DatabaseInfo.connectionTimeout;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        DateTime dayDate = Convert.ToDateTime(reader["day"]);

                        selectedDay = new Day(id, dayDate);
                    }
                    databaseConnection.Close();
                }
                else
                {
                    databaseConnection.Close();
                }
                databaseConnection.Close();
            }
            catch (MySqlException ex)
            {
                databaseConnection.Close();
                throw ex;
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
            }

            return selectedDay;
        }

        private List<string> GetPreviousShift(int shift, DateTime date)
        {
            List<Personal> previousShift = new List<Personal>();
            List<string> previousShiftStr = new List<string>();

            if (shift == 0)
            {
                date.AddDays(-1);
                shift = 2;

                string query = "SELECT u.firstname, u.lastname ";
                query += "FROM `users` u, `users_has_shift` uhs, `shift` s, `day` d WHERE ";
                query += $"d.day = CAST(N'{date.ToString("yyyy-MM-dd")}' AS Date) AND ";
                query += "d.id = s.day_id AND ";
                query += $"s.shifttype = {shift} AND ";
                query += "uhs.users_id = u.id ";

                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = DatabaseInfo.connectionTimeout;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    if (reader.HasRows)// check if any rows are found
                    {
                        while (reader.Read()) //read each individual row
                        {
                            string firstname = reader["firstname"].ToString();
                            string lastname = reader["lastname"].ToString();

                            previousShift.Add(new Employee(firstname, lastname));
                        }
                        databaseConnection.Close();
                    }
                    else
                    {
                        databaseConnection.Close();
                    }
                    databaseConnection.Close();
                }
                catch (MySqlException ex)
                {
                    databaseConnection.Close();
                    throw ex;
                }
                catch (Exception ex)
                {
                    databaseConnection.Close();
                }
            }

            foreach(Personal p in previousShift)
            {
                previousShiftStr.Add(p.ToString());
            }

            return previousShiftStr;
        }

        private void InsertEmployee(int shiftId, int employeeId)
        {
            try
            {
                string deleteQuery = $"DELETE FROM `users_has_shift` WHERE users_id = @userId AND shift_id = @shiftId";
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(deleteQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@userId", employeeId);
                commandDatabase.Parameters.AddWithValue("@shiftId", shiftId);
                commandDatabase.ExecuteNonQuery();
                databaseConnection.Close();

                string insertQuery = $"INSERT INTO users_has_shift(users_id, shift_id) VALUES(@userId, @shiftId)";
                databaseConnection.Open();
                commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@userId", employeeId);
                commandDatabase.Parameters.AddWithValue("@shiftId", shiftId);
                commandDatabase.ExecuteNonQuery();
                databaseConnection.Close();
            }
            catch(Exception ex)
            {

            }
        }

        private static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
    }


}
