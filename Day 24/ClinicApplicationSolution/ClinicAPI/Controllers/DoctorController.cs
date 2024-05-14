using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctors();
                return Ok(doctors.ToList());
            }
            catch (NoDoctorsFoundException ndfe)
            {
                return NotFound(ndfe);
            }
        }

        [HttpGet]
        [Route("GetDoctorBySpeciality")]
        public async Task<ActionResult<IList<Doctor>>> GetDoctorBySpeciality(string speciality)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpeciality(speciality);
                return Ok(doctors.ToList());
            }
            catch(NoDoctorsFoundException ndfe)
            {
                return NotFound(ndfe);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateDoctorExperience(int id, int experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch(NoSuchDoctorException nsde)
            {
                return NotFound(nsde);
            }
        }
    }
}
