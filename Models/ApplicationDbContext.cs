using Microsoft.EntityFrameworkCore;

namespace Urgencias.Models
{
    public class ApplicationDbContext : DbContext
    {
     

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }


    }
}