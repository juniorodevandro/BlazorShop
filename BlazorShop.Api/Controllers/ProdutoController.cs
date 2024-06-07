using BlazorShop.Api.Interface;
using BlazorShop.Api.Mappings;
using BlazorShop.Models.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProduto([FromQuery] int? id, string? nome)
        {
            try
            {
                var produtos = await _produtoRepository.GetProduto(id, nome);

                if (!produtos.Any())
                {
                    return BadRequest("Produto não encontrado."); 
                }              
                else
                {
                    var produtoDtos = produtos.ConverterProdutoDTO();
                    return Ok(produtoDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
        }

    }
}
