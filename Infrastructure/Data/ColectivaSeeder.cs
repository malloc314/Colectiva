using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ColectivaSeeder
    {
        private readonly ColectivaDbContext _context;

        public ColectivaSeeder(ColectivaDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.HistoricalSequences.Any())
                {
                    var historicalSequences = GetHistoricalSequences();
                    _context.HistoricalSequences.AddRange(historicalSequences); // incorrect data order
                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<HistoricalSequence> GetHistoricalSequences()
        {
            //var rootPath = Directory.GetCurrentDirectory();
            var rootPath = @"C:\Users\mmast\OneDrive\BOX\projects\programming\colectiva\Colectiva\Infrastructure\Data";
            var fileName = "HistoricalSequences.json";
            var filePath = $"{rootPath}\\{fileName}";
            List<HistoricalSequence> orderedSequence = new List<HistoricalSequence>();

            var jsonString = File.ReadAllText(filePath);

            var historicalSequences = JsonSerializer.Deserialize<IEnumerable<HistoricalSequence>>(jsonString).ToList();

            for (int i = 1; i <= historicalSequences.Count;)
            {
                foreach (var sequence in historicalSequences)
                {
                    if (sequence.Sn == i)
                    {
                        orderedSequence.Add(sequence);
                        i++;
                    }
                }
            }

            return orderedSequence;
        }
    }
}
