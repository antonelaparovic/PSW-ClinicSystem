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
    [Route("api/referral")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private IReferralService referralService;
        private IMapper mapper; // mapping Db entities to DTOs

        public ReferralController(IReferralService referralS, IMapper maper)
        {
            mapper = maper;
            referralService = referralS;
        }

        [HttpGet]
        public IActionResult GetAllReferral()
        {
            try
            {
                var referrals = referralService.GetReferrals();
                //var referralsResult = mapper.Map<IEnumerable<ReferralDTO>>(referrals);
                return Ok(referrals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }

        [HttpGet("{id}", Name = "ReferralById")]
        public IActionResult GetReferralById(int id)
        {
            try
            {
                var fb = referralService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                else
                {
                 //   var temp = mapper.Map<Referral>(fb);
                  //  var fbResult = mapper.Map<ReferralDTO>(temp);
                    return Ok(fb);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateReferral([FromBody] ReferralDTO fb)
        {
            try
            {
                if (fb == null)
                {
                    return BadRequest("Referral object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                //var fbEntity = mapper.Map<Referral>(fb);
                referralService.CreateReferral(fb);
                var temp = mapper.Map<Referral>(fb);
                var createdFb = mapper.Map<ReferralResponseDTO>(temp);
                return CreatedAtRoute("ReferralById", new { id = createdFb.referralId }, createdFb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReferral(int id)
        {
            try
            {
                var fb = referralService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                referralService.DeleteReferral(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
