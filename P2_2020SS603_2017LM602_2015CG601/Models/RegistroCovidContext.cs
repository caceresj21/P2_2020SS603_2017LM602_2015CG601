using Microsoft.EntityFrameworkCore;

namespace P2_2020SS603_2017LM602_2015CG601.Models
{
    public class RegistroCovidContext : DbContext
    {

        public RegistroCovidContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<CasosReportados> CasosReportados { get; set; }

    }
}
