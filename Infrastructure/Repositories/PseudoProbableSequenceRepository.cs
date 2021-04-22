﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PseudoProbableSequenceRepository : IPseudoProbableSequenceRepository
    {
        private readonly ColectivaDbContext _context;

        public PseudoProbableSequenceRepository(ColectivaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HistoricalSequence> GetAll()
        {
            var historicalSequences = _context.HistoricalSequences;
            return historicalSequences;
        }
    }
}