using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IPrescriptionService prescriptionService;
        private IMapper mapper; // mapping Db entities to DTOs

        public PrescriptionController(IPrescriptionService prescriptionS, IMapper maper)
        {
            mapper = maper;
            prescriptionService = prescriptionS;
        }

        [HttpGet]
        public IActionResult GetAllPrescription()
        {
            try
            {
                var prescriptions = prescriptionService.GetPrescriptions();
                //var prescriptionsResult = mapper.Map<IEnumerable<PrescriptionDTO>>(prescriptions);
                return Ok(prescriptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }

        [HttpGet("{id}", Name = "PrescriptionById")]
        public IActionResult GetPrescriptionById(int id)
        {
            try
            {
                var fb = prescriptionService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                else
                {
                   // var temp = mapper.Map<Prescription>(fb);
                   // var fbResult = mapper.Map<PrescriptionDTO>(temp);
                    return Ok(fb);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreatePrescription([FromBody] PrescriptionDTO fb)
        {
            try
            {
                if (fb == null)
                {
                    return BadRequest("Prescription object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                //var fbEntity = mapper.Map<Prescription>(fb);
                prescriptionService.CreatePrescription(fb);
                var temp = mapper.Map<Prescription>(fb);
                var createdFb = mapper.Map<PrescriptionResponseDTO>(temp);
                return CreatedAtRoute("PrescriptionById", new { id = createdFb.prescriptionId }, createdFb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrescription(int id)
        {
            try
            {
                var fb = prescriptionService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                prescriptionService.DeletePrescription(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
