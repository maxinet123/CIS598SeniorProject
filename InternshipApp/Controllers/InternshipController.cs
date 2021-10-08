using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipData.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternshipApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InternshipController : ControllerBase
    {
        private readonly IInternshipServices _internshipService;
        public InternshipController(IInternshipServices internshipService)
        {
            _internshipService = internshipService;
        }

        [HttpGet]
        public IActionResult GetInternships()
        {
            return Ok(_internshipService.GetInternships());
        }

        [HttpPost]
        public IActionResult AddInternship(Internship internship)
        {
            return Ok(internship);
        }
    }
}
