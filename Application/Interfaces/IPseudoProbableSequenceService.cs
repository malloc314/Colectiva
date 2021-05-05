﻿using Application.Dto;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPseudoProbableSequenceService
    {
        public IEnumerable<PseudoProbableSequenceDto> DrawPseudoProbableSequences(PseudoProbableSequenceQuantity quantity);
        public PseudoProbableSequenceDto PostPseudoProbableSequence(PseudoProbableSequenceDto dto, string userId);
        public IEnumerable<PseudoProbableSequenceDto> GetPseudoProbableSequences();
    }
}
