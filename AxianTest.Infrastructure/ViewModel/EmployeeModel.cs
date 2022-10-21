using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTest.Infrastructure.ViewModel
{
    public class EmployeeModel:BaseModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }      
        public string DOB { get; set; }        
        public decimal Salary { get; set; }
        public int LeavPeryear { get; set; }
        public int SickLeave { get; set; }
        public string Address { get; set; }
        public int DepId { get; set; }
        public string DepName { get; set; }


    }
}
