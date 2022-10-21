using AxianTest.Infrastructure.Interfaces;
using AxianTest.Infrastructure.ViewModel;
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

    
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }

        // GET: api/<AccountController>
        [HttpPost]
        public UserModel Login(UserModel userModel)
        {
            return _account.Authentication(userModel);
        }
            
    }
}
