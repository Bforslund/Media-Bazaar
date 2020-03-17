using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Pabo.Calendar;

namespace WindowsFormsApp1
{
    class CalenderManager
    {
        private List<Day> days = new List<Day>();
        private DateItem[] dateItems;

        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        public void LoadShifts(ActiveMonth activeMonth)
        {
            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            string query;
            query = "SELECT * FROM `day` WHERE ";
            query += $"CAST(`day` AS Date) >= CAST(N'{firstDayOfMonth.ToString("yyyy-MM-dd")}' AS Date) AND ";
            query += $"CAST(`day` AS Date) <= CAST(N'{lastDayOfMonth.ToString("yyyy-MM-dd")}' AS Date);";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    days.Clear();
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        DateTime day = Convert.ToDateTime(reader["day"]);

                        days.Add(new Day(id, day));
                    }

                    databaseConnection.Close();
                }
                else
                {
                    databaseConnection.Close();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
            }

            foreach (Day day in days)
            {
                day.LoadShifts();
            }
        }

        public DateItem[] SetDaysForMonth(ActiveMonth activeMonth)
        {
            int days = DateTime.DaysInMonth(activeMonth.Year, activeMonth.Month);

            dateItems = new DateItem[days];

            for (int i = 0; i < days; i++)
            {
                Color color = Color.Red;
                DateTime date = new DateTime(activeMonth.Year, activeMonth.Month, (i + 1));

                dateItems[i] = new DateItem();
                dateItems[i].Date = new DateTime(activeMonth.Year, activeMonth.Month, (i + 1));

                foreach (Day day in this.days)
                {
                    DateTime test = day.Date();
                    if (test == date)
                    {
                        color = day.SetDayColor();
                        //color = Color.YellowGreen;
                    }
                }
                dateItems[i].BackColor1 = color;
            }

            return dateItems;
        }

        public List<Personal> GetPersonalAssigned(DateTime date, int shiftType)
        {
            foreach (Day day in days)
            {
                if (day.Date() == date)
                {
                    foreach (Shift shift in day.GetShifts())
                    {
                        if (shift.GetshiftType() == shiftType)
                        {
                            return shift.GetPersonal();
                        }
                    }
                }
            }

            return null;
        }

        public void SetShift(DateTime date, int shift, int person, ActiveMonth activeMonth)
        {
            long dayId = -1;
            long shiftId = -1;

            foreach (Day day in days)
            {
                if (day.Date() == date)
                {
                    dayId = day.Id();
                }
            }

            if (dayId < 0)
            {
                //insert new day and shifts
                string insertQuery = $"INSERT INTO day(day) VALUES(CAST(N'{date.ToString("yyyy-MM-dd")}' AS Date));";
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                //commandDatabase.Parameters.AddWithValue("@day", date.ToString("yyyy-MM-dd"));
                commandDatabase.ExecuteNonQuery();
                dayId = commandDatabase.LastInsertedId;

                //if (result != null) { dayId = Convert.ToInt32(result); }
                databaseConnection.Close();

                for (int i = 0; i < 3; i++)
                {
                    int max = 5;
                    if (i == 2) { max = 2; }

                    insertQuery = $"INSERT INTO shift(shifttype, min, max, day_id) VALUES(@shifttype, 2, @max, @dayId); select last_insert_id();";
                    databaseConnection.Open();
                    commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@shifttype", i);
                    commandDatabase.Parameters.AddWithValue("@max", max);
                    commandDatabase.Parameters.AddWithValue("@dayId", dayId);
                    commandDatabase.ExecuteNonQuery();

                    if (shift == i)
                    {
                        shiftId = commandDatabase.LastInsertedId;
                    }

                    databaseConnection.Close();
                }
            }
            else
            {
                string sql = $"SELECT id FROM shift WHERE day_id = {dayId} AND shifttype = {shift};";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                databaseConnection.Open();
                Object result = cmd.ExecuteScalar();
                if (result != null) { shiftId = Convert.ToInt32(result); }
                databaseConnection.Close();
            }

            if (shiftId >= 0 && person >= 0)
            {
                string insertQuery = $"INSERT INTO users_has_shift(users_id, shift_id) VALUES(@userId, @shiftId); select last_insert_id();";
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@userId", person);
                commandDatabase.Parameters.AddWithValue("@shiftId", shiftId);
                commandDatabase.ExecuteNonQuery();
                databaseConnection.Close();
            }

            LoadShifts(activeMonth);
        }

        public void RemoveEmployee(DateTime date, int shiftType, int employeeId, ActiveMonth activeMonth)
        {
            int shiftId = -1;
            foreach (Day day in days)
            {
                if (day.Date() == date)
                {
                    foreach (Shift shift in day.GetShifts())
                    {
                        if (shift.GetshiftType() == shiftType)
                        {
                            shiftId = shift.Id();
                        }
                    }
                }
            }

            if (shiftId >= 0 && employeeId >= 0)
            {
                string insertQuery = $"DELETE FROM `users_has_shift` WHERE users_id = @userId AND shift_id = @shiftId;";
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@userId", employeeId);
                commandDatabase.Parameters.AddWithValue("@shiftId", shiftId);
                commandDatabase.ExecuteNonQuery();
                databaseConnection.Close();
            }

            LoadShifts(activeMonth);
        }
    }
}
