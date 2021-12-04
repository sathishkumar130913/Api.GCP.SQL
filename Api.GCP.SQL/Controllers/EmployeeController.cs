using Api.GCP.SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.GCP.SQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly webapigcpContext _dbcontext;

        public EmployeeController(webapigcpContext webapidbcontxt)
        {
            _dbcontext = webapidbcontxt;
        }
        // GET: EmployeeController
        [HttpGet]
        public IEnumerable<Empdetails> Get()
        
        {
            using (var context = _dbcontext)
            {
                return context.Empdetails.ToList();

            }
        }


    }
}
