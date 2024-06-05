using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProduto();
        Task<Produto> GetProduto(int id);
        Task<IEnumerable<Produto>> GetProdutoCategoria(int id);
    }
}
