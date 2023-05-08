using Pokedex.Entities.Models;

namespace Pokedex.Percistence
{
    public class PokeDexDbContext
    {
        public List<Pokemon> Pokemons { get; set; }
        public PokeDexDbContext() {
            Pokemons = new List<Pokemon>();
        }
    }
}
