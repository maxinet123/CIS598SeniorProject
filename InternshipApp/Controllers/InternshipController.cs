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

        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies()
        {
            var data = _internshipService.GetCompanies();
            return Ok();
        }

        [HttpGet("GetDisciplines")]
        public IActionResult GetDisciplines()
        {
            var data = _internshipService.GetDisciplines();
            return Ok();
        }

        [HttpGet("GetLocations")]
        public IActionResult GetLocations()
        {
            var data = _internshipService.GetLocations();
            return Ok();
        }

        [HttpGet("GetRatings")]
        public IActionResult GetRatings()
        {
            var data = _internshipService.GetRatings();
            return Ok();
        }

        [HttpGet("GetMajors")]
        public IActionResult GetMajors()
        {
            var data = _internshipService.GetMajors();
            return Ok();
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship([FromBody] Data data)
        {
            _internshipService.AddInternship(data.internship, data.company, data.discipline, data.location);
            return Ok();
        }


        [HttpPost("UpdateVote")]
        public IActionResult UpdateVote([FromBody] Vote vote)
        {
            _internshipService.UpdateVote(vote);
            return Ok();
        }
    }
}
