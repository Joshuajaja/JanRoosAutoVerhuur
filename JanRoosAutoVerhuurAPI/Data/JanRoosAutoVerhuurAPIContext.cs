using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JanRoosAutoVerhuurAPI.Models;

namespace JanRoosAutoVerhuurAPI.Data
{
    public class JanRoosAutoVerhuurAPIContext : DbContext
    {
        public JanRoosAutoVerhuurAPIContext (DbContextOptions<JanRoosAutoVerhuurAPIContext> options)
            : base(options)
        {
        }

        public DbSet<JanRoosAutoVerhuurAPI.Models.Accounts> Accounts { get; set; } = default!;
    }
}
