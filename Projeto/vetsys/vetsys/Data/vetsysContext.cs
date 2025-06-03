using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;
using Vetsys.Models;
using vetsys.Models;

namespace vetsys.Data
{
    public class vetsysContext : DbContext
    {
        public vetsysContext(DbContextOptions<vetsysContext> options)
            : base(options)
        {
        }

        public DbSet<Gato> Gato { get; set; } = default!;
        public DbSet<Cachorro> Cachorro { get; set; } = default!;
        public DbSet<Passaros> Passaros { get; set; } = default!;
        public DbSet<Roedores> Roedores { get; set; } = default!;
        public DbSet<Oferta> Oferta { get; set; } = default!;
        public DbSet<vetsys.Models.TelaPagamento> TelaPagamento { get; set; } = default!;
        public DbSet<vetsys.Models.Sacola> Sacola { get; set; } = default!;
        public DbSet<vetsys.Models.Pesquisar> Pesquisar { get; set; } = default!;
        public DbSet<vetsys.Models.Cadastro> Cadastro { get; set; } = default!;
        public DbSet<vetsys.Models.Login> Login { get; set; } = default!;
    }
}
