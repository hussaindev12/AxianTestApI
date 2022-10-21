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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        // GET: api/<Employee>
        [HttpGet]
        public IList<EmployeeModel> Get()
        {
            IList<EmployeeModel> employees = _employee.GetAll();
            return employees;
        }

        // GET api/<Employee>/5
        [HttpGet("{id}")]
        public EmployeeModel Get(int id)
        {
            var employee = _employee.Get(id);
            return employee;
        }

        // POST api/<Employee>
        [HttpPost]
        public bool Post([FromBody] EmployeeModel employeeModel)
        {
           return _employee.AddEmployee(employeeModel);
        }

        // PUT api/<Employee>/5
        [HttpPut("{id}")]
        public bool  Put(int id, [FromBody] EmployeeModel employeeModel)
        {
            return _employee.EditEmployee(id, employeeModel);
        }

        // DELETE api/<Employee>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _employee.DeleteEmployee(id);
        }
    }
}
