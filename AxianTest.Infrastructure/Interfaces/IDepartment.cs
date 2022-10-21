using AxianTest.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTest.Infrastructure.Interfaces
{
    public interface IDepartment
    {
        public IList<DepartmentModel> GetAllDepartments();
        public DepartmentModel GetDepartment(int id);
        public bool AddDepartment(DepartmentModel employeeModel);
        public bool EditDepartment(int id, DepartmentModel employeeModel);
        public bool DeleteDepartment(int id);
    }
}
