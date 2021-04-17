using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ColectivaDbContext : DbContext
    {
        public ColectivaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<HistoricalSequence> HistoricalSequences { get; set; }
    }
}
