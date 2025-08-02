using Microsoft.AspNetCore.Mvc;

namespace IntegracaoDeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {
        private readonly IPokemonApiService _pokemonApiService;

        public PokeController(IPokemonApiService pokemonApiService)
        {
            _pokemonApiService = pokemonApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? Name)
        {
            try
            {
                var pokemons = await _pokemonApiService.GetPokemonsAsync(Name);
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
