using BullPerks.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullPerks.DAL
{
    public class TokenDbContext : DbContext
    {
        public DbSet<TokenData> TokenData { get; set; }

        public TokenDbContext(DbContextOptions<TokenDbContext> options)
            : base(options)
        {
        }
    }
}
