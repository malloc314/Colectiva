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
                    var orderHistoricalSequences = OrderHistoricalSequences();
                    foreach (var sequence in orderHistoricalSequences)
                    {
                        _context.HistoricalSequences.Add(sequence);
                        _context.SaveChanges();
                    }
                }

                if (CheckNewHistoricalSequence())
                {
                    var getNewHistoricalSequenceFromJsonFile = GetNewHistoricalSequence();
                    foreach (var sequence in getNewHistoricalSequenceFromJsonFile)
                    {
                        _context.HistoricalSequences.Add(sequence);
                        _context.SaveChanges();
                    }
                }
            }
        }
        public List<HistoricalSequence> GetJsonFile()
        {
            var rootPath = @"C:\Users\mmast\OneDrive\BOX\projects\programming\colectiva\Colectiva\Infrastructure\Data";
            var fileName = "HistoricalSequences.json";
            var filePath = $"{rootPath}\\{fileName}";

            var jsonString = File.ReadAllText(filePath);

            var historicalSequencesJson = JsonSerializer.Deserialize<IEnumerable<HistoricalSequence>>(jsonString).ToList();

            return historicalSequencesJson;
        }

        public IEnumerable<HistoricalSequence> OrderHistoricalSequences()
        {
            var historicalSequences = GetJsonFile();

            return historicalSequences.OrderBy(h => h.Sn).ToList();
        }

        public bool CheckNewHistoricalSequence()
        {
            var jsonFile = GetJsonFile();

            var historicalSequencesDb = _context.HistoricalSequences;

            if (historicalSequencesDb.Count() == jsonFile.Count())
            {
                return false;
            }

            return true;
        }

        public IEnumerable<HistoricalSequence> GetNewHistoricalSequence()
        {
            var jsonFile = GetJsonFile();
            var historicalSequences = _context.HistoricalSequences;

            var result = jsonFile.Count() - historicalSequences.Count();

            return jsonFile.Take(result).OrderBy(h => h.Sn).ToList();
        }
    }
}
