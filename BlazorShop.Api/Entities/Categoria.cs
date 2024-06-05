using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [MaxLength(300)]

        public required string Nome { get; set; }

        [MaxLength(200)]
        public string? IconCSS { get; set; }

        public ICollection<Produto> Produtos { get; set; } = [];
               
    }
}
