using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ColectivaDbContext : IdentityDbContext<ApplicationUser>
    {
        public ColectivaDbContext(DbContextOptions<ColectivaDbContext> options) : base(options)
        {
        }

        public DbSet<HistoricalSequence> HistoricalSequences { get; set; }
        public DbSet<PseudoProbableSequence> PseudoProbableSequences { get; set; }
    }
}
