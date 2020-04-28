using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Department
    {
        private string name;
        private int id;
        private int manager_id;
        private int min_employees;
        private int max_employees;
        public Department(string name, int manager_id, int min_employees, int max_employees)
            : this(0, name, manager_id, min_employees, max_employees)
        {
        }

        public Department(int id, string name, int manager_id, int min_employees, int max_employees)
        {
            this.Name = name;
            this.Id = id;
            this.Manager_id = manager_id;
            this.Min_employees = min_employees;
            this.Max_employees = max_employees;
        }

        public string Name 
        { 
            get { return name; } 
            set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                name = value;
            } 
        }
        public int Id { get => id; set => id = value; }
        public int Manager_id // has to be one manager when you create a department.
        {
            get
            {
                return manager_id;
            }
            set
            {
                if(value > 0)
                {
                    manager_id = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
                    
            }
        }
        public int Min_employees { get => min_employees; set => min_employees = value; }
        public int Max_employees // max employees cant be less than minimum
        {
            get
            {
                return max_employees;
            }
            set
            {
                if(value < min_employees)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    max_employees = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
