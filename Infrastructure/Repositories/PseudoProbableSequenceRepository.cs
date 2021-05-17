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

        public PseudoProbableSequence PostAll(PseudoProbableSequence sequence)
        {
            var pseudoProbableSequence = _context.PseudoProbableSequences.Add(sequence);
            
            _context.SaveChanges();

            return pseudoProbableSequence.Entity;
        }

        public IEnumerable<PseudoProbableSequence> GetAllPseudo(string userId, bool isAdmin)
        {
            if (isAdmin)
            {
                var pseudoSequencesAdmin = _context.PseudoProbableSequences;

                return pseudoSequencesAdmin;
            }

            var pseudoSequencesUser = _context.PseudoProbableSequences.Where(ps => ps.UserId == userId);

            return pseudoSequencesUser;
        }

        public PseudoProbableSequence GetPseudoById(int pseudoId)
        {
            var pseudoSequence = _context.PseudoProbableSequences.FirstOrDefault(ps => ps.Id == pseudoId);
            return pseudoSequence;
        }

        public void DeletePseudo(PseudoProbableSequence sequence)
        {
            _context.PseudoProbableSequences.Remove(sequence);

            _context.SaveChanges();
        }
    }
}
