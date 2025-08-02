namespace IntegracaoDeApi
{
    public class PokemonApiService : IPokemonApiService
    {
        private readonly HttpClient _httpClient;

        public PokemonApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync(string? Name)
        {
            var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var pokemonResponse = System.Text.Json.JsonSerializer.Deserialize<PokemonResponse>(content, options);

            var pokemons = pokemonResponse?.Results ?? Enumerable.Empty<Pokemon>();

            if (Name != null)
                pokemons = pokemons.Where(p => p.Name.ToLower().Contains(Name.ToLower()));

            return pokemons;
        }
    }
}
