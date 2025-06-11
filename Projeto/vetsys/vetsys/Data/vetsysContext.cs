using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;
using vetsys.Models;
using Vetsys.Models;


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
        public DbSet<TelaPagamento> TelaPagamento { get; set; } = default!;
        public DbSet<Sacola> Sacola { get; set; } = default!;
        public DbSet<Cadastro> Cadastro { get; set; } = default!;
        public DbSet<Login> Login { get; set; } = default!;
        public DbSet<Produtos> Produto { get; set; } = default!;
        public DbSet<Automatico> Automatico { get; set; } = default!;
        public DbSet<Itens> Itens { get; set; } = default!;
    }
}
