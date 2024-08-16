using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings){
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        public DbSet<Administrador> Administradores {get; set;} = default!;
        public DbSet<Veiculo> Veiculos {get; set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador {
                    Id = 1,
                    Email = "admin@teste.com",
                    Senha = "123456",
                    Perfil = "Admin"
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured){
                var stringConexao = _configuracaoAppSettings.GetConnectionString("ConexaoPadrao")?.ToString();
                
                if (!string.IsNullOrEmpty(stringConexao)){            
                    optionsBuilder.UseSqlServer(stringConexao);
                }
            }
        }
    }
}