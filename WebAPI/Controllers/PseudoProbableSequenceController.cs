using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [SwaggerOperation(Summary = "Get pseudo-probable sequences from 1 to 16")]
        [HttpGet("{qty}")]
        public IActionResult Get([FromRoute] PseudoProbableSequenceQuantity quantity)
        {
            //var validator = new PseudoProbableSequenceQuantity();
            //var result = validator.Validate(quantity);


            var sequences = _pseudoProbableSequenceService.GetPseudoProbableSequences(quantity);

            return Ok(sequences);
        }
    }
}
