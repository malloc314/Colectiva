using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPseudoProbableSequenceRepository
    {
        public IEnumerable<HistoricalSequence> GetAll();
        public PseudoProbableSequence PostAll(PseudoProbableSequence sequence);
        public IEnumerable<PseudoProbableSequence> GetAllPseudo();
    }
}
