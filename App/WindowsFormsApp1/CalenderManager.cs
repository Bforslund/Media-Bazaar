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

            foreach(Day day in days)
            {
                day.LoadShifts();
            }
        }

        public DateItem[] SetDaysForMonth (ActiveMonth activeMonth)
        {
            int days = DateTime.DaysInMonth(activeMonth.Year, activeMonth.Month);

            dateItems = new DateItem[days];

            for (int i = 0; i < days; i++)
            {
                Color color = Color.Red;
                DateTime date = new DateTime(activeMonth.Year, activeMonth.Month, (i + 1));

                dateItems[i] = new DateItem();
                dateItems[i].Date = new DateTime(activeMonth.Year, activeMonth.Month, (i+1));

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
            foreach(Day day in days)
            {
                if(day.Date() == date)
                {
                    foreach (Shift shift in day.GetShifts())
                    {
                        if(shift.GetshiftType() == shiftType)
                        {
                            return shift.GetPersonal();
                        }
                    }
                }
            }

            return null;
        }
    }
}
