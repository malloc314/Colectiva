using Application.Dto;
using Application.Interfaces;
using Application.Models;
using Application.Validators;
using Infrastructure.Identity;
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

        [SwaggerOperation(Summary = "Draw pseudo-probable sequences from 1 to 16")]
        [ValidateFilter]
        [Authorize(Roles = UserRoles.User)]
        [HttpGet("{Qty}")]
        public IActionResult Get([FromRoute] PseudoProbableSequenceQuantity quantity)
        {
            var sequences = _pseudoProbableSequenceService.DrawPseudoProbableSequences(quantity);

            return Ok(sequences);
        }

        [SwaggerOperation(Summary = "Add pseudo-probable sequence")]
        [ValidateFilter]
        [Authorize(Roles = UserRoles.User)]
        [HttpPost]
        public IActionResult Post(PseudoProbableSequenceDto dto)
        {
            var sequences = _pseudoProbableSequenceService.PostPseudoProbableSequence(dto, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Created($"api/PseudoProbableSequence/{sequences.Id}", sequences);
        }

        [SwaggerOperation(Summary = "Get pseudo-probable sequences")]
        //[ValidateFilter]
        [Authorize(Roles = UserRoles.UserOrAdmin)]
        [HttpGet]
        public IActionResult Get()
        {
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);

            var pseudoSequencesDto = _pseudoProbableSequenceService.GetPseudoProbableSequences(User.FindFirstValue(ClaimTypes.NameIdentifier), isAdmin);

            return Ok(pseudoSequencesDto);
        }
        
        [SwaggerOperation(Summary = "Get pseudo-probable sequences by id")]
        //[ValidateFilter]
        [Authorize(Roles = UserRoles.User)]
        [HttpGet("id/{pseudoId}")]
        public IActionResult GetById([FromRoute] int pseudoId)
        {
            var userOwnsPseudo = _pseudoProbableSequenceService.UserOwnsPseudoProbableSequence(pseudoId, User.FindFirstValue(ClaimTypes.NameIdentifier));

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

        [SwaggerOperation(Summary = "Delete pseudo-probable sequence by id")]
        //[ValidateFilter]
        [Authorize(Roles = UserRoles.UserOrAdmin)]
        [HttpDelete("delete/{pseudoId}")]
        public IActionResult Delete([FromRoute] int pseudoId)
        {
            var userOwnsPseudo = _pseudoProbableSequenceService.UserOwnsPseudoProbableSequence(pseudoId, User.FindFirstValue(ClaimTypes.NameIdentifier));
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);

            if (!isAdmin && !userOwnsPseudo)
            {
                return BadRequest(new Response<bool>()
                {
                    Succeeded = false,
                    Message = "You don't own this pseudo-probable sequence"
                });
            }

            _pseudoProbableSequenceService.DeletePseudoProbableSequence(pseudoId);

            return NoContent();
        }
    }
}
