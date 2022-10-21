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
    public class DepartmentService : IDepartment
    {
        private readonly ApplicationDBContext _dBContext;
        public DepartmentService(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public bool AddDepartment(DepartmentModel employeeModel)
        {

            try
            {
                var emp = new Department()
                {
                    Name = employeeModel.Name,
                    Location = employeeModel.Location

                };
                var db = _dBContext.Departments.Add(emp);
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteDepartment(int id)
        {
            try
            {
                var department = _dBContext.Departments.Single(x => x.Id == id);
                _dBContext.Departments.Remove(department);
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EditDepartment(int id, DepartmentModel employeeModel)
        {
            try
            {
                var department = _dBContext.Departments.Single(x => x.Id == id);               
                department.Name = employeeModel.Name;
                department.Location = employeeModel.Location;
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IList<DepartmentModel> GetAllDepartments()
        {
            var viewDepartment = new List<DepartmentModel>();
            var dbDepartment = _dBContext.Departments.ToList();
            foreach (var dep in dbDepartment)
            {
                var viewDep = new DepartmentModel()
                {
                    Id = dep.Id,
                    Name = dep.Name,
                    Location = dep.Location
                };
                viewDepartment.Add(viewDep);
            }

            return viewDepartment;
           
        }

        public DepartmentModel GetDepartment(int id)
        {
            var department = _dBContext.Departments.Single(x => x.Id == id);
            var viewDep = new DepartmentModel()
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location
            };
            return viewDep;

        }
    }
}
