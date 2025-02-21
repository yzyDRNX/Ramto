using Microsoft.EntityFrameworkCore;
using Ramto.Lib.Helpers;

namespace Ramto.Infraestructura.Data
{
    public class RamtoDataContext: DbContext
    {
        public RamtoDataContext()
        {
            
        }

        public class Usuario
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string? Nombre { get; set; }
            public DateTime? FechaCreacion { get; set; }
            public DateTime? UltimoAcceso { get; set; }
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public RamtoDataContext(DbContextOptions<RamtoDataContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuraciones.CadenaConexion, op =>
                {
                    op.EnableRetryOnFailure(5, new TimeSpan(0, 0, 10), null);
                });

            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
