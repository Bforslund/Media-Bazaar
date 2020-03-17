using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Day
    {
        private int dbId;
        private DateTime date;
        List<Shift> shifts = new List<Shift>();

        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        public Day(int id, DateTime date)
        {
            dbId = id;
            this.date = date;
        }

        public void LoadShifts()
        {
            string query = $"SELECT * FROM `shift` WHERE day_id = {dbId}";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    shifts.Clear();
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        int shiftType = Convert.ToInt32(reader["shifttype"]);
                        int min = Convert.ToInt32(reader["min"]);
                        int max = Convert.ToInt32(reader["max"]);

                        shifts.Add(new Shift(id, dbId, shiftType, min, max));
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

            foreach (Shift shift in shifts)
            {
                shift.LoadAssignedEmployees();
            }
        }

        public DateTime Date()
        {
            return date;
        }

        public int Id()
        {
            return dbId;
        }

        public Color SetDayColor()
        {
            int succesCounter = 0;
            Color color;

            foreach (Shift shift in shifts)
            {
                if (shift.CheckShiftStatus())
                {
                    succesCounter++;
                }
            }

            switch (succesCounter)
            {
                case 0: color = Color.Red; break; // no shifts filled
                case 1: color = Color.Yellow; break; // 1 out of 3 shifts filled
                case 2: color = Color.Orange; break; // 2 out of 3 shifts filled
                default: color = Color.Red; break; // all shifts filled
            }

            return color;
        }

        public List<Shift> GetShifts()
        {
            return shifts;
        }
    }
}
