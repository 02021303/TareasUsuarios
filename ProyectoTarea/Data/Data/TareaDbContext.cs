using Data.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entidades;

namespace Data.Data
{
    public class TareaDbContext : IdentityDbContext<UsuarioAplicacion>
    {
        public TareaDbContext(DbContextOptions<TareaDbContext> options) : base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }

    }
}
