using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteDoctor(int id)
        {
            try
            {
                var doctorDeleted = await _doctorService.DeleteDoctor(id);
                return Ok(doctorDeleted);
            }
            catch(NoSuchDoctorException nsde)
            {
                return NotFound(nsde);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> AddDoctor([FromBody] Doctor doctor)
        {
            try
            {
                var doc = await _doctorService.AddDoctor(doctor);
                return Ok(doc);
            }
            catch(NoDoctorsFoundException nsde)
            {
                return NotFound(nsde);
            }
        }
    }
}
