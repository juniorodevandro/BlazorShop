using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BlazorShop.Api.Context

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Carrinho>? Carrinho { get; set; }
        public DbSet<CarrinhoItem>? CarrinhoItem { get; set; }
        public DbSet<Produto>? Produto { get; set; }
        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //-- CRIAR PELO MENOS UM REGISTRO EM CADA TABELA PADRÃO
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 1,
                Nome = "Teclado Gamer",
                Descricao = "Tem um design mais robusto e durável, além de ser projetado para suportar uma utilização intensa, mesmo durante longas sessões de jogos",
                Quantidade = 1,
                Preco = 100,
                CategoriaId = 1
            });            
          
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Teclado",
                IconCSS = "fa-keyboard"
            });
            
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nome = "Evandro Junior"
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
