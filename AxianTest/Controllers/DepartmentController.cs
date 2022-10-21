using AxianTest.Infrastructure.Interfaces;
using AxianTest.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AxianTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;
        public DepartmentController(IDepartment department)
        {
            _department = department;
        }
        // GET: api/<DepartmnetController>
        [HttpGet]
        public IList<DepartmentModel> GetAll()
        {
            return _department.GetAllDepartments();
             
        }

        // GET api/<DepartmnetController>/5
        [HttpGet("{id}")]
        public DepartmentModel Get(int id)
        {
            return _department.GetDepartment(id);
          
        }

        // POST api/<DepartmnetController>
        [HttpPost]
        public bool Post([FromBody] DepartmentModel departmentModel)
        {
            return _department.AddDepartment(departmentModel);
        }

        // PUT api/<DepartmnetController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] DepartmentModel departmentModel)
        {
            return _department.EditDepartment(id, departmentModel);
        }

        // DELETE api/<DepartmnetController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
           return _department.DeleteDepartment(id);
        }
    }
}
