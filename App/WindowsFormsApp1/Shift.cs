using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Shift
    {
        private int id;
        private int dayId;
        private int shiftType;
        private int minAssinged;
        private int maxAssigned;
        private List<Personal> assignedEmployees = new List<Personal>();

        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        public Shift(int id, int dayId, int shiftType, int min, int max)
        {
            this.id = id;
            this.dayId = dayId;
            this.shiftType = shiftType;
            minAssinged = min;
            maxAssigned = max;
        }

        public void LoadAssignedEmployees()
        {
            string query;
            query = "SELECT * FROM `users_has_shift` us, users u WHERE ";
            query += $"us.shift_id = {id} AND ";
            query += $"us.users_id = u.id ";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    assignedEmployees.Clear();
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string username = reader["username"].ToString();
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int privilage = Convert.ToInt32(reader["privilage"]);
                        double wage = Convert.ToDouble(reader["wage"]);
                        DateTime hiredate = Convert.ToDateTime(reader["hiredate"]);
                        DateTime birthday = Convert.ToDateTime(reader["birthday"]);
                        string adress = reader["adress"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phone"].ToString();
                        bool contract = Convert.ToBoolean(reader["contract"]);
                        //int department = Convert.ToInt32(reader["department_id"]);
                        int department = 0;

                        assignedEmployees.Add(new Employee(id, email, firstname, lastname, privilage, username, adress, birthday, contract, department, hiredate, phone, wage));
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
        }

        public bool CheckShiftStatus()
        {
            if (assignedEmployees.Count() < minAssinged)
            {
                return false;
            }
            return true;
        }

        public int GetshiftType()
        {
            return shiftType;
        }

        public int Id()
        {
            return id;
        }

        public List<Personal> GetPersonal()
        {
            return assignedEmployees;
        }
    }
}
