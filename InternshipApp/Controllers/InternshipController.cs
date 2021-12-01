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
            return _internshipService.GetInternships();
        }

        [HttpGet("GetCompanies")]
        public Task<List<Company>> GetCompanies()
        {
            return _internshipService.GetCompanies();
        }

        [HttpGet("GetDisciplines")]
        public Task<List<Discipline>> GetDisciplines()
        {
            return _internshipService.GetDisciplines();
        }

        [HttpGet("GetLocations")]
        public Task<List<Location>> GetLocations()
        {
            return _internshipService.GetLocations();
        }

        [HttpGet("GetRatings")]
        public Task<List<Rating>> GetRatings()
        {
            return _internshipService.GetRatings();
        }

        [HttpGet("GetMajors")]
        public Task<List<Major>> GetMajors()
        {
            return _internshipService.GetMajors();
        }

        [HttpPost("AddInternship")]
        public IActionResult AddInternship([FromBody] InternshipHeaders internshipHeaders)
        {
            _internshipService.AddInternship(internshipHeaders.Internship, internshipHeaders.Company, internshipHeaders.Location, internshipHeaders.Major, internshipHeaders.Discipline, internshipHeaders.Rating, internshipHeaders.User);
            return Ok();
        }


        [HttpPost("UpdateVote")]
        public Task<Internship> UpdateVote([FromHeader] Data internship)
        {
             _internshipService.UpdateVote(internship);
            var data = _internshipService.GetInternshipById(internship.InternshipId);
            return data;
        }

        [HttpPost("AddUser")]
        public Task<User> AddUser( [FromBody] User user)
        {
            return _internshipService.AddUser(user);
        }
    }
}
