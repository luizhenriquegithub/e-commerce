using ApiGateway.Data.Map;
using ApiGateway.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.Data
{
    public class MyDBContext :DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) :base(options) 
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //....

            base.OnModelCreating(modelBuilder);
        }
    }
}
