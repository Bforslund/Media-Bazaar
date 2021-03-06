﻿using MySql.Data.MySqlClient;
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

        public Shift(int id, int dayId, int shiftType, int min, int max)
        {
            this.id = id;
            this.dayId = dayId;
            this.shiftType = shiftType;
            minAssinged = min;
            maxAssigned = max;
        }

        /// <summary>
        /// loads the people assigned to the shift
        /// </summary>
        public void LoadAssignedEmployees()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query;
            query = "SELECT * FROM users_has_shift us, users u WHERE ";
            query += $"us.shift_id = {id} AND ";
            query += $"us.users_id = u.id ";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = DatabaseInfo.connectionTimeout;
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
                        string password = reader["password"].ToString();
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int privilage = Convert.ToInt32(reader["privilage"]);
                        double wage = Convert.ToDouble(reader["wage"]);
                        DateTime hiredate = Convert.ToDateTime(reader["hiredate"]);
                        DateTime birthday = Convert.ToDateTime(reader["birthday"]);
                        string allergies = reader["allergies"].ToString();
                        string adress = reader["adress"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phone"].ToString();
                        int contract = Convert.ToInt32(reader["contract"]);
                        Department department = new DepartmentController().GetDepartment(Convert.ToInt32(reader["department_id"]));

                        assignedEmployees.Add(new Employee(id, email, firstname, lastname, privilage, username, password, adress, birthday, allergies, contract, department, hiredate, phone, wage));
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

        /// <summary>
        /// checks if the minimum amount of employees have been assigned
        /// </summary>
        /// <returns></returns>
        public bool CheckShiftStatus()
        {
            if (assignedEmployees.Count() < minAssinged)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// returns shift type (morning, evening, night)
        /// </summary>
        /// <returns></returns>
        public int GetshiftType()
        {
            return shiftType;
        }

        /// <summary>
        /// returns shift id
        /// </summary>
        /// <returns></returns>
        public int Id()
        {
            return id;
        }

        /// <summary>
        /// returns employees assigned
        /// </summary>
        /// <returns></returns>
        public List<Personal> GetPersonal()
        {
            return assignedEmployees;
        }

        public int GetMinAssigned()
        {
            return minAssinged;
        }
    }
}
