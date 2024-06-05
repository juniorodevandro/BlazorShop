using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public required string Nome { get; set; }

        public Carrinho? Carrinho { get; set; }
    }
}
