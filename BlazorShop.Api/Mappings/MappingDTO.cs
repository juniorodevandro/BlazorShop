using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOS;

namespace BlazorShop.Api.Mappings
{
    public static class MappingDTO
    {
        public static IEnumerable<CategoriaDTO> ConverterCategoriaDTO(this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDTO
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        IconCSS = categoria.IconCSS
                    }).ToList();
        }

        public static IEnumerable<ProdutoDTO> ConverterProdutosDTO(this IEnumerable<Produto> produtos)
        {
            return (from produto in produtos
                    select new ProdutoDTO
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        ImagemUrl = produto.ImagemUrl,
                        Preco = produto.Preco,
                        Quantidade = produto.Quantidade,
                        CategoriaId = produto.Categoria.Id,
                        CategoriaNome = produto.Categoria.Nome
                    }).ToList();
        }

        public static ProdutoDTO ConverterProdutoDTO(this Produto produto)
        {
            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.Categoria.Id,
                CategoriaNome = produto.Categoria.Nome
            };
        }

        public static IEnumerable<CarrinhoItemDTO> ConverterCarrinhoItemDTO(this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDTO
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoImagemURL = produto.ImagemUrl,
                        Preco = produto.Preco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = carrinhoItem.Quantidade,
                        PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                    }).ToList();
        }

        public static CarrinhoItemDTO ConverterCarrinhoItemDTO(this CarrinhoItem carrinhoItem, Produto produto)
        {
            return new CarrinhoItemDTO
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.Nome,
                ProdutoDescricao = produto.Descricao,
                ProdutoImagemURL = produto.ImagemUrl,
                Preco = produto.Preco,
                CarrinhoId = carrinhoItem.CarrinhoId,
                Quantidade = carrinhoItem.Quantidade,
                PrecoTotal = produto.Preco * carrinhoItem.Quantidade
            };
        }
    }
}
