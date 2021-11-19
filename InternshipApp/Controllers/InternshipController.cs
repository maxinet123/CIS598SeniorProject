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
        public Task<List<Data>> GetInternships()
        {
            var data = _internshipService.GetInternships();
            return data;
        }

        [HttpGet("GetCompanies")]
        public Task<List<Company>> GetCompanies()
        {
            var data = _internshipService.GetCompanies();
            return data;
        }

        [HttpGet("GetDisciplines")]
        public Task<List<Discipline>> GetDisciplines()
        {
            var data = _internshipService.GetDisciplines();
            return data;
        }

        [HttpGet("GetLocations")]
        public Task<List<Location>> GetLocations()
        {
            var data = _internshipService.GetLocations();
            return data;
        }

        [HttpGet("GetRatings")]
        public Task<List<Rating>> GetRatings()
        {
            var data = _internshipService.GetRatings();
            return data;
        }

        [HttpGet("GetMajors")]
        public Task<List<Major>> GetMajors()
        {
            var data = _internshipService.GetMajors();
            return data;
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship([FromHeader] InternshipHeaders internshipHeaders)
        {
            _internshipService.AddInternship(internshipHeaders.Internship, internshipHeaders.Company, internshipHeaders.Location, internshipHeaders.Major, internshipHeaders.Discipline, internshipHeaders.Rating, internshipHeaders.User);
            return Ok();
        }


        [HttpPost("UpdateVote")]
        public IActionResult UpdateVote([FromBody] Internship internship)
        {
             _internshipService.UpdateVote(internship);
            var data = _internshipService.GetInternshipById(internship.Id);
            return Ok(data);
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship( [FromBody] User user)
        {
            _internshipService.AddUser(user);
            return Ok();
        }
    }
}
