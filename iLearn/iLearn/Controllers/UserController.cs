using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iLearn.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            private readonly MainProjectContext _Context;

            public EmployeeController(MainProjectContext _context)
            {
                _Context = _context;
            }
            [HttpGet]
            [EnableCors("Corspolicy")]
            public ActionResult<List<User>> Get()
            {
                return Ok(_Context.User.ToList());
            }
        }
    }
}