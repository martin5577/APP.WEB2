using CMS.domain.Categorias;
using CMS.domain.Preguntas;
using CMS.domain.Respuestas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CMS.infraestructure.Data
{
    public class CMSContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public CMSContext(DbContextOptions<CMSContext>opciones) : base(opciones)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
