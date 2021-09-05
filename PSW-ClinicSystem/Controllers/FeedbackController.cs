using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_ClinicSystem.IServices;

namespace PSW_ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase   // Default
    {
        private IFeedbackService feedbackService;
        private IMapper mapper; // mapping Db entities to DTOs

        public FeedbackController(IFeedbackService feedbackS, IMapper maper)
        {
            mapper = maper;
            feedbackService = feedbackS;
        }

        [HttpGet]
        public IActionResult GetAllFeedback()
        {
            try
            {
                var feedbacks = feedbackService.GetFeedbacks();
                //var feedbacksResult = mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }

        }

        [HttpGet("{id}", Name = "FeedbackById")]
        public IActionResult GetFeedbackById(int id)
        {
            try
            {
                var fb = feedbackService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                else
                {
                    //var temp = mapper.Map<Feedback>(fb);
                    //var fbResult = mapper.Map<FeedbackDTO>(temp);
                    return Ok(fb);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error");
            }
         }


        [HttpPost]
        public IActionResult CreateFeedback([FromBody] FeedbackDTO fb)
        {
            try
            {
                if (fb == null)
                {
                    return BadRequest("Feedback object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                //var fbEntity = mapper.Map<Feedback>(fb);
                feedbackService.CreateFeedback(fb);
                var temp = mapper.Map<Feedback>(fb);
                var createdFb = mapper.Map<FeedbackResponseDTO>(temp);
                return CreatedAtRoute("FeedbackById", new { id = createdFb.FeedbackId }, createdFb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeedback(int id)
        {
            try
            {
                var fb = feedbackService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                feedbackService.DeleteFeedback(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
         }

        
        [HttpPut("share/{id}")]   // put nije implementiran u repou
        public IActionResult ShareFeedback(int id)
        {
            try
            {
                var fb = feedbackService.GetById(id);
                if (fb == null)
                {
                    return NotFound();
                }
                feedbackService.ShareFeedback(id);
                return Ok();  // ako ne radi vrati taj fb
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("published")]  
        public IActionResult GetPublished()
        {
            try
            {
                var feedbacks = feedbackService.GetPublished();
                //var feedbacksResult = mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }
        }

        [HttpGet("unpublished")]
        public IActionResult GetUnpublished()
        {
            try
            {
                var feedbacks = feedbackService.GetUnpublished();
                //var feedbacksResult = mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, kontroler");
            }
        }
    }
}

