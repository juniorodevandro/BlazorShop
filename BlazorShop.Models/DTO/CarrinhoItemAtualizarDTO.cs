using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOS
{
    public class CarrinhoItemAtualizarDTO
    {
        public int CarrinhoItemId { get; set; }
        public int Quantidade { get; set; }
    }
}
