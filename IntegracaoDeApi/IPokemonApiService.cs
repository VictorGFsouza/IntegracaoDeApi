namespace IntegracaoDeApi
{
    public interface IPokemonApiService
    {
        public Task<IEnumerable<Pokemon>> GetPokemonsAsync(string? Name);
    }

    public class PokemonResponse
    {
        public IEnumerable<Pokemon> Results { get; set; }
    }
}
