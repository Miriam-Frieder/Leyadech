﻿using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace leyadech.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteerController : Controller
    {
        private readonly VolunteerService _volunteerService;
        public VolunteerController(VolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpGet]
        public ActionResult<List<Volunteer>> Get()
        {
            var volunteers = _volunteerService.GetAllVolunteers();
            return Ok(volunteers);
        }

        [HttpGet("{id}")]
        public ActionResult<Volunteer> Get(int id)
        {
            var volunteer = _volunteerService._volunteerHelper.GetVolunteerById(id);
            if (volunteer == null)
                return NotFound();
            return Ok(volunteer);
        }

        [HttpPost]
        public ActionResult<bool> Add([FromBody] Volunteer volunteer)
        {
            if(!_volunteerService.IsRequiredFields(volunteer))return BadRequest();
            if (!_volunteerService.IsValidFields(volunteer)) return BadRequest();
            bool result = _volunteerService.AddVolunteer(volunteer);
            if (!result)
                return BadRequest();
            return true;
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Volunteer volunteer)
        {
            if (_volunteerService._volunteerHelper.GetVolunteerById(id) == null) return NotFound();
            if (!_volunteerService.IsValidFields(volunteer)) return BadRequest();
            bool result = _volunteerService.UpdateVolunteerFields(id, volunteer);
            if (!result)
                return NotFound();
            return true;
        }

        [HttpPut("{id}/status")]
        public ActionResult<bool> UpdateStatus(int id, [FromBody] EVolunteerStatus status)
        {
            if (_volunteerService._volunteerHelper.GetVolunteerById(id) == null) return NotFound();
            bool result = _volunteerService.UpdateVolunteerStatus(id, status);
            if (!result)
                return BadRequest();
            return true;
        }

        [HttpGet("{id}/volunteerings")]
        public ActionResult<List<Volunteering>> GetVolunteeringsByVolunteerId(int id)
        {
            if (_volunteerService._volunteerHelper.GetVolunteerById(id) == null) return NotFound();
            var volunteerings = _volunteerService.GetAllVolunteeringsById(id);
            return Ok(volunteerings);
        }
    }
}
