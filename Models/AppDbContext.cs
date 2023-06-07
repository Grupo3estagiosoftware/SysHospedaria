using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        
        }


        //public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Preco> Precos { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Check> Check { get; set; }
    }
}
