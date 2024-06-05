using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOS
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? IconCSS { get; set; }
    }
}
