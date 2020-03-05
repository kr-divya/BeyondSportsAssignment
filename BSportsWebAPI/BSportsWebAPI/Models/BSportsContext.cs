using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BSportsWebAPI.Models
{
    public class BSportsContext : DbContext
    {
        public BSportsContext(DbContextOptions<BSportsContext> options)
           : base(options)
        {
        }

        public DbSet<BSportsItem> BSportsItems { get; set; }
    }
}
