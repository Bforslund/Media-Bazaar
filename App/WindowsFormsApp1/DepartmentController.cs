using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public class DepartmentController
    {
        private List<Personal> Managers = new List<Personal>();
        public void AddDepartment(Department d)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "INSERT INTO department (name, manager_id, min_employees, max_employees) VALUES(@name, @manager_id, @min, @max)";

                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                cmd.Parameters.AddWithValue("@name", d.Name);

                cmd.Parameters.AddWithValue("@manager_id", d.Manager_id);

                cmd.Parameters.AddWithValue("@min", d.Min_employees);

                cmd.Parameters.AddWithValue("@max", d.Max_employees);

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public void UpdateDepartment(Department d)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "UPDATE department SET name = @name, manager_id = @manager_id, min_employees = @min, max_employees = @max WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                cmd.Parameters.AddWithValue("@name", d.Name);
                cmd.Parameters.AddWithValue("@id", d.Id);
                cmd.Parameters.AddWithValue("@manager_id", d.Manager_id);

                cmd.Parameters.AddWithValue("@min", d.Min_employees);

                cmd.Parameters.AddWithValue("@max", d.Max_employees);


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public void DeleteDepartment(Department d)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "DELETE FROM department WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                cmd.Parameters.AddWithValue("@id", d.Id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<Department> GetDepartments()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();
                string sql = "SELECT * FROM department";
                List<Department> returnedDepartments = new List<Department>();
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Department d = new Department(Convert.ToInt32(dr["id"]), dr["name"].ToString(), Convert.ToInt32(dr["manager_id"]), Convert.ToInt32(dr["min_employees"]), Convert.ToInt32(dr["max_employees"]));
                    returnedDepartments.Add(d);
                }
                return returnedDepartments;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
          
        }
        public List<Department> FilterDepartments(string filterTerm) // same the filtering in the schedule
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();
                filterTerm = filterTerm.ToLower(); //makes everything lower case, makes it easier to compare

                if (string.IsNullOrEmpty(filterTerm)) // if no filter term given return all products
                {
                    return GetDepartments();
                }

                List<Department> filterProducts = new List<Department>();

                foreach (Department d in GetDepartments())
                {
                    if (d.ToString().ToLower().IndexOf(filterTerm) >= 0) // check if the product contains a part of the filter term
                    {
                        filterProducts.Add(d);
                    }
                }

                return filterProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }

        }

        public Department GetDepartment(int departmentId)
        {
            foreach(Department department in GetDepartments())
            {
                if(department.Id == departmentId)
                {
                    return department;
                }
            }

            return null;
        }
    }
}