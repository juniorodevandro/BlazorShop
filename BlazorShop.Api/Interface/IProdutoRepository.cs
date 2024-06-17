using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProduto(int? id, string? nome);
        Task<IEnumerable<Produto>> GetProdutoCategoria(int id);
    }
}
