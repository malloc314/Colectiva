using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class HistoricalSequenceRepository : IHistoricalSequenceRepository
    {
        private readonly ColectivaDbContext _context;

        public HistoricalSequenceRepository(ColectivaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HistoricalSequence> GetAll()
        {
            return _context.HistoricalSequences;
        }

        public HistoricalSequence GetById(int sn)
        {
            return _context.HistoricalSequences.SingleOrDefault(x => x.Sn == sn);
        }
    }
}

