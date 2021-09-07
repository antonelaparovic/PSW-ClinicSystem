using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using AutoMapper;
using PSW_ClinicSystem.IServices;

namespace PSW_ClinicSystem.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService patientService;
        private IMapper mapper; // mapping Db entities to DTOs

        public PatientController(IPatientService patientS, IMapper maper)
        {
            mapper = maper;
            patientService = patientS;
        }

        [HttpGet]
        public IActionResult GetAllPatient()
        {
            try
            {
                var patients = patientService.GetPatients();
                //var patientsResult = mapper.Map<IEnumerable<PatientDTO>>(patients);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }

        [HttpGet("{id}", Name = "PatientById")]
        public IActionResult GetPatientById(int id)
        {
            try
            {
                var fb = patientService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                else
                {
                    //var temp = mapper.Map<Patient>(fb);
                   // var fbResult = mapper.Map<PatientDTO>(temp);
                    return Ok(fb);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreatePatient([FromBody] PatientDTO fb)
        {
            try
            {
                if (fb == null)
                {
                    return BadRequest("Patient object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                //var fbEntity = mapper.Map<Patient>(fb);
                patientService.CreatePatient(fb);
                var temp = mapper.Map<Patient>(fb);
                var createdFb = mapper.Map<PatientResponseDTO>(temp);
                return CreatedAtRoute("PatientById", new { id = createdFb.patientId }, createdFb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                var fb = patientService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                patientService.DeletePatient(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("block/{id}")]
        public IActionResult BlockPatient(int id)
        {
            try
            {
                var fb = patientService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                patientService.BlockPatient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("unblock/{id}")]
        public IActionResult UnblockPatient(int id)
        {
            try
            {
                var fb = patientService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                patientService.UnblockPatient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
