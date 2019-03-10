using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S00190492_Creche.Model
{
    public class CrecheContext:DbContext
    {
        public CrecheContext(DbContextOptions<CrecheContext> options)
            :base(options)
        { }

        public DbSet<Student> Students { get; set; }
    }
}
