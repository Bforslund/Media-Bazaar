using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class StoreStats
    {
        public string Month { get; set; }
        public decimal EmployeeCosts { get; set; }
        public decimal SalesIn { get; set; }
        public decimal ProdCosts { get; set; }

        public string departmentName { get; set; }
        public int departmantSales { get; set; }

        public StoreStats(string _month, decimal _employeeCosts, decimal _salesIn, decimal _prodCosts)
        {
            this.Month = _month;
            this.SalesIn = _salesIn;
            this.ProdCosts = _prodCosts;
            this.EmployeeCosts = _employeeCosts;
        }

        public StoreStats(string _depName, int _depAmount)
        {
            this.departmentName = _depName;
            this.departmantSales = _depAmount;
        }

        //Tijdelijke ctors voor stats
        public StoreStats(string _month, decimal _employeeCosts)
        {
            this.Month = _month;
            this.EmployeeCosts = _employeeCosts;
        }
        public StoreStats()
        {

        }

        public override string ToString()
        {
            return Month + " " + SalesIn + " " + ProdCosts + " " + EmployeeCosts;
        }
    }
}
