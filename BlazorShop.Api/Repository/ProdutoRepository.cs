using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetProduto(int? id, string? nome)
        {
            if (id > 0)
            {
                var produto = await _context.Produto
                                            .Include(c => c.Categoria)
                                            .Where(e => e.Id == id)
                                            .ToListAsync();

                return produto;
            }
            else if (!String.IsNullOrEmpty(nome)) 
            {
                var produto = await _context.Produto
                                            .Include(c => c.Categoria)
                                            .Where(e => e.Nome.Contains(nome))
                                            .ToListAsync();

                return produto;
            }
            else
            {
                var produtos = await _context.Produto
                                             .Include(p => p.Categoria)
                                             .ToListAsync();
                return produtos;
                
            }
        }

        public async Task<IEnumerable<Produto>> GetProdutoCategoria(int id)
        {
            var produto = await _context.Produto
                          .Include(p => p.Categoria)
                          .Where(p => p.CategoriaId == id)
                          .ToListAsync();

            return produto;
        }
    }
}
