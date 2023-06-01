using IDentyfica.Model;
using Microsoft.EntityFrameworkCore;

namespace IDentyfica.Data
{
    public class IDentyficaDbContext : DbContext
    {
        public IDentyficaDbContext(DbContextOptions<IDentyficaDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
