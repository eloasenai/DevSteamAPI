using devSteamAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace devSteamAPI.Data
{
    public class DevSteamAPIContext : IdentityDbContext
    {
        //Metodo construtor
        public DevSteamAPIContext(DbContextOptions<DevSteamAPIContext> options)
            : base(options)
        { }

        //definir as tabelas do banco de dados
        public DbSet<jogo> Jogos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        //Sobrescrever o metodo OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<jogo>().ToTable("Jogos");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");

        }
        public DbSet<devSteamAPI.Models.Carrinho> Carrinho { get; set; } = default!;
        public DbSet<devSteamAPI.Models.ItemCarrinho> ItemCarrinho { get; set; } = default!;
    }
}
