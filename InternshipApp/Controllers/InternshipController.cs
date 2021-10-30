using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipData.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InternshipData.Core.Models;
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
            var data = _internshipService.GetInternships();
            return Ok();
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship([FromBody] Data data)
        {
            _internshipService.AddInternship(data.internship, data.company, data.discipline, data.location);
            return Ok();
        }
    }
}
