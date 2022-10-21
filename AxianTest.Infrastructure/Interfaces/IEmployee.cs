using AxianTest.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTest.Infrastructure.Interfaces
{
    public interface IEmployee
    {
        public IList<EmployeeModel> GetAll();
        public EmployeeModel Get(int id);
        public bool AddEmployee(EmployeeModel employeeModel);
        public bool EditEmployee(int id,EmployeeModel employeeModel);
        public bool DeleteEmployee(int id);

    }
}
