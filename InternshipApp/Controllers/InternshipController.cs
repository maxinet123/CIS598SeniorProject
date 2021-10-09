using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipData.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace InternshipApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternshipController : ControllerBase
    {
        private readonly IInternshipServices _internshipService;
        public InternshipController(IInternshipServices internshipService)
        {
            _internshipService = internshipService;
        }

        [HttpGet("GetInternships")]
        public IActionResult GetInternships()
        {

            return Ok(_internshipService.GetInternships());
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship(Internship internship)
        {
            _internshipService.AddInternship(internship);
            return Ok(internship);
        }
    }
}
