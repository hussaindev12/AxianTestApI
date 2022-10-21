using AxianTast.Core.Context;
using AxianTast.Core.Entities;
using AxianTest.Infrastructure.Interfaces;
using AxianTest.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTest.Infrastructure.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly ApplicationDBContext _dBContext;
        public EmployeeService(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public bool EditEmployee(int id, EmployeeModel employeeModel)
        {
            try
            {
                var employee = _dBContext.Employees.Single(x => x.Id == id);
                var user = _dBContext.Users.Single(x => x.EmpId == employee.Id);
                var department = _dBContext.Departments.Single(x => x.Id == employee.DepId);

                employee.User.FullName = employeeModel.FullName;
                employee.User.Email = employeeModel.Email;
                employee.User.Password = employeeModel.Password;
                employee.DOB = employeeModel.DOB;
                employee.Salary = employeeModel.Salary;
                employee.LeavPeryear = employeeModel.LeavPeryear;
                employee.SickLeave = employeeModel.SickLeave;
                employee.Address = employeeModel.Address;
                employee.DepId = employeeModel.DepId;
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var user = new User()
                {
                    //Id = employeeModel.Id,
                    FullName = employeeModel.FullName,
                    Email = employeeModel.Email,
                    Password = employeeModel.Password,
                    EmpId = employeeModel.Id,
                    Type = "Employee"
                };
                _dBContext.Users.Add(user);
                var emp = new Employee()
                {
                    //Id = employeeModel.Id,
                    User = user,
                    DOB = employeeModel.DOB,
                    Salary = employeeModel.Salary,
                    LeavPeryear = employeeModel.LeavPeryear,
                    SickLeave = employeeModel.SickLeave,
                    Address = employeeModel.Address,
                    DepId = employeeModel.DepId,
                    //department =new Department()
                };
                var db = _dBContext.Employees.Add(emp);
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public EmployeeModel Get(int id)
        {
            var employee = _dBContext.Employees.Single(x => x.Id == id);
            var user = _dBContext.Users.Single(x => x.EmpId == employee.Id);
            var department = _dBContext.Departments.Single(x => x.Id == employee.DepId);
            var empModel = new EmployeeModel() 
            {
                Id = employee.Id,
                FullName = employee.User.FullName,
                DOB = employee.DOB,
                Salary = employee.Salary,
                LeavPeryear = employee.LeavPeryear,
                SickLeave = employee.SickLeave,
                Address = employee.Address,
                DepName = employee.department.Name
            };
            return empModel;
        }

        public IList<EmployeeModel> GetAll()
        {          
            List<EmployeeModel> employeeList = (from emp in _dBContext.Employees
                         join dep in _dBContext.Departments on emp.DepId equals dep.Id
                         join user in _dBContext.Users on emp.Id equals user.EmpId   
                         select new EmployeeModel()
                         {
                             Id = emp.Id,
                             FullName = emp.User.FullName,
                             DOB = emp.DOB,
                             Salary = emp.Salary,
                             LeavPeryear = emp.LeavPeryear,
                             SickLeave = emp.SickLeave,
                             Address = emp.Address,
                             DepName = emp.department.Name
                         }).ToList();

            return employeeList;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _dBContext.Employees.Single(x => x.Id == id);
            var user = _dBContext.Users.Single(x => x.EmpId == employee.Id);
            _dBContext.Employees.Remove(employee);
            _dBContext.Users.Remove(user);
            _dBContext.SaveChanges();
            return true;
        }
      
    }
}
