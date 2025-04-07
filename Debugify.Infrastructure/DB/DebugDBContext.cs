using Debugify.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugify.Infrastructure.DB
{
    public class DebugDBContext :DbContext
    {
        public DebugDBContext(DbContextOptions options):base(options) { }

        public DbSet<DebugStepDetails> DebugStepDetails { get; set; }
    }
}
