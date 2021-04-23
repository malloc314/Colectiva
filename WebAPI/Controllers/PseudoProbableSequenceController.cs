using Application.Dto;
using Application.Interfaces;
using Application.Models;
using Application.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Attributes;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("api/PseudoProbableSequence")]
    [ApiController]
    public class PseudoProbableSequenceController : ControllerBase
    {
        private readonly IPseudoProbableSequenceService _pseudoProbableSequenceService;

        public PseudoProbableSequenceController(IPseudoProbableSequenceService pseudoProbableSequenceService)
        {
            _pseudoProbableSequenceService = pseudoProbableSequenceService;
        }

        [ValidateFilter]
        [SwaggerOperation(Summary = "Get pseudo-probable sequences from 1 to 16")]
        [HttpGet("{Qty}")]
        public IActionResult Get([FromRoute] PseudoProbableSequenceQuantity quantity)
        {
            var sequences = _pseudoProbableSequenceService.GetPseudoProbableSequences(quantity);

            return Ok(sequences);
        }

        [ValidateFilter]
        [SwaggerOperation(Summary = "Add pseudo-probable sequence")]
        [HttpPost]
        public IActionResult Post([FromQuery] PseudoProbableSequenceDto dto)
        {
            var sequences = _pseudoProbableSequenceService.PostPseudoProbableSequence(dto);

            return Created($"api/PseudoProbableSequence/{sequences.Id}", sequences);
        }
    }
}
