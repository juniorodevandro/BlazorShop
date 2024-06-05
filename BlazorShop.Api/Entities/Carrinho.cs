namespace BlazorShop.Api.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }

        public required int UsuarioId { get; set; }

        public ICollection<CarrinhoItem> CarrinhoItem { get; set; } = [];
    }
}
