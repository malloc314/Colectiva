using Application.Interfaces;
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

        [SwaggerOperation(Summary = "Get pseudo-probable sequences")]
        [HttpGet]
        public IActionResult Get()
        {
            var sequences = _pseudoProbableSequenceService.GetPseudoProbableSequences();

            return Ok(sequences);
        }
    }
}
