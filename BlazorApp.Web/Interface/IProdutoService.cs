using BlazorShop.Models.DTOS;

namespace BlazorApp.Web.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProduto(int? id);
        Task<IEnumerable<CategoriaDTO>> GetProdutoCategoria();
        Task<IEnumerable<ProdutoDTO>> GetProdutoCategoria(int categoriaId);
    }
}
