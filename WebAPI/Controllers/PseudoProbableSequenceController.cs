using Application.Dto;
using Application.Interfaces;
using Application.Models;
using Application.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Attributes;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PseudoProbableSequenceController : ControllerBase
    {
        private readonly IPseudoProbableSequenceService _pseudoProbableSequenceService;

        public PseudoProbableSequenceController(IPseudoProbableSequenceService pseudoProbableSequenceService)
        {
            _pseudoProbableSequenceService = pseudoProbableSequenceService;
        }

        [ValidateFilter]
        [SwaggerOperation(Summary = "Draw pseudo-probable sequences from 1 to 16")]
        [HttpGet("{Qty}")]
        public IActionResult Get([FromRoute] PseudoProbableSequenceQuantity quantity)
        {
            var sequences = _pseudoProbableSequenceService.DrawPseudoProbableSequences(quantity);

            return Ok(sequences);
        }

        [ValidateFilter]
        [SwaggerOperation(Summary = "Add pseudo-probable sequence")]
        [HttpPost]
        public IActionResult Post(PseudoProbableSequenceDto dto)
        {
            var sequences = _pseudoProbableSequenceService.PostPseudoProbableSequence(dto, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Created($"api/PseudoProbableSequence/{sequences.Id}", sequences);
        }

        //[ValidateFilter]
        [SwaggerOperation(Summary = "Get pseudo-probable sequences")]
        [HttpGet]
        public IActionResult Get()
        {
            var pseudoSequencesDto = _pseudoProbableSequenceService.GetPseudoProbableSequences(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(pseudoSequencesDto);
        }
        //[ValidateFilter]
        [SwaggerOperation(Summary = "Get pseudo-probable sequences by id")]
        [HttpGet("id/{pseudoId}")]
        public IActionResult GetById([FromRoute] int pseudoId)
        {
            var userOwnsPseudo = _pseudoProbableSequenceService.UserOwnsPseudo(pseudoId, User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!userOwnsPseudo)
            {
                return BadRequest(new Response<bool>() 
                { 
                    Succeeded = false,
                    Message = "You don't own this pseudo-probable sequence"
                });
            }

            var pseudoSequencesDto = _pseudoProbableSequenceService.GetPseudoProbableSequenceById(pseudoId);

            return Ok(pseudoSequencesDto);
        }

        ////[ValidateFilter]
        //[SwaggerOperation(Summary = "Delete pseudo-probable sequence by id")]
        //[HttpDelete]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    var pseudoSequence = _pseudoProbableSequenceService.DeletePseudoProbableSequence(id);

        //    return Ok(pseudoSequencesDto);
        //}
    }
}
