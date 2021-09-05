using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Data;
using AutoMapper;
using PSW_ClinicSystem.IServices;

namespace PSW_ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase   // Default
    {
        private IDoctorService doctorService;
        private IMapper mapper; // mapping Db entities to DTOs

        public DoctorController(IDoctorService doctorS, IMapper maper)
        {
            mapper = maper;
            doctorService = doctorS;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            try
            {
                var doctors = doctorService.GetDoctors();  // List DoctorResponseDTO
                //var doctorsResult = mapper.Map<IEnumerable<DoctorDTO>>(doctors);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }

        [HttpGet("specialists/{id}")]
        public IActionResult GetBySpecialistField(int id)
        {
            try
            {
                var doctors = doctorService.GetBySpecialistField(id);  // List DoctorResponseDTO
                //var doctorsResult = mapper.Map<IEnumerable<DoctorDTO>>(doctors);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }

        [HttpGet("{id}", Name = "DoctorById")]
        public IActionResult GetDoctorById(int id)
        {
            try
            {
                var doctor = doctorService.GetById(id);   // ResponseDTO
                if (doctor == null)
                {
                    return NotFound();
                }
                else
                {
                    //var temp = mapper.Map<Doctor>(doctor);
                    //var doctorResult = mapper.Map<DoctorDTO>(temp);
                    return Ok(doctor);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateDoctor([FromBody] DoctorDTO doctor)
        {
            try
            {
                if (doctor == null)
                {
                    return BadRequest("Doctor object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                //var doctorEntity = mapper.Map<DoctorDTO>(doctor);
                doctorService.CreateDoctor(doctor);
                var temp = mapper.Map<Doctor>(doctor);
                var createdFb = mapper.Map<DoctorResponseDTO>(temp);
                return CreatedAtRoute("DoctorById", new { id = createdFb.doctorId }, createdFb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                var doctor = doctorService.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                doctorService.DeleteDoctor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

