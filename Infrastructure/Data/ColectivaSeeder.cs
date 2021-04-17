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
                    foreach (var entity in historicalSequences)
                    {
                        _context.HistoricalSequences.Add(entity);
                        _context.SaveChanges();
                    }
                }
            }
        }

        public IEnumerable<HistoricalSequence> GetHistoricalSequences()
        {
            var rootPath = @"C:\Users\mmast\OneDrive\BOX\projects\programming\colectiva\Colectiva\Infrastructure\Data";
            var fileName = "HistoricalSequences.json";
            var filePath = $"{rootPath}\\{fileName}";
            List<HistoricalSequence> orderedSequence = new List<HistoricalSequence>();

            var jsonString = File.ReadAllText(filePath);

            var historicalSequences = JsonSerializer.Deserialize<IEnumerable<HistoricalSequence>>(jsonString).ToList();

            return historicalSequences.OrderBy(h => h.Sn).ToList();
        }
    }
}
