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

        public async Task<IEnumerable<Produto>> GetProduto()
        {
            var produto = await _context.Produto
                          .Include(c => c.Categoria)
                          .ToListAsync();

            return produto;
        }

        public async Task<Produto> GetProduto(int id)
        {
            var produto = await _context.Produto
                          .Include(c => c.Categoria)
                          .SingleOrDefaultAsync(c => c.Id == id);

            return produto;
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
