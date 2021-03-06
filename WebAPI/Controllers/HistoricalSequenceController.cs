using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoricalSequenceController : ControllerBase
    {
        private readonly IHistoricalSequenceService _historicalSequenceService;

        public HistoricalSequenceController(IHistoricalSequenceService historicalSequenceService)
        {
            _historicalSequenceService = historicalSequenceService;
        }

        [SwaggerOperation(Summary= "Gets whole history of Eurojackpot draws")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var sequences = _historicalSequenceService.GetAllHistoricalSequences();
            
            return Ok(sequences);
        }

        [SwaggerOperation(Summary = "Gets draw by ordinal number")]
        [HttpGet("{sn}")]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int sn)
        {
            var sequence = _historicalSequenceService.GetHistoricalSequenceById(sn);
            
            if (sequence is null)
                return NotFound();
            
            return Ok(sequence);
        }
    }
}
