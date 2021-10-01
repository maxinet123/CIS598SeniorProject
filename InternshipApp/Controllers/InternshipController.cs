using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternshipApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InternshipController : ControllerBase
    {
        public InternshipController()
        {

        }

        [HttpGet]
        public IActionResult GetInternships()
        {
            return Ok();
        }
    }
}
