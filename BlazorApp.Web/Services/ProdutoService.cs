using BlazorShop.Models.DTOS;
using System.Net.Http.Json;
using System.Net;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient;
        public ILogger<ProdutoService> _logger;

        public ProdutoService(HttpClient httpClient,
            ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProduto(int? id)
        {
            try
            {
                HttpResponseMessage response;

                if (id > 0)
                {
                    response = await _httpClient.GetAsync($"api/Produto/{id}");
                }
                else
                {
                    response = await _httpClient.GetAsync($"api/Produto");               
                }

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProdutoDTO>(); ;
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id = {id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter produto pelo id={id}");
                throw;
            }
        }

        public async Task<IEnumerable<CategoriaDTO>> GetProdutoCategoria()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Produto/GetProdutoCategoria");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CategoriaDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutoCategoria(int categoriaId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Produto/{categoriaId}/GetProdutoCategoria");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProdutoDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }
    }
}
