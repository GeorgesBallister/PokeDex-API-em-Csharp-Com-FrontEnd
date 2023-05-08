using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Entities.Models;
using Pokedex.Percistence;

namespace Pokedex.Controllers
{
    [Route("api/pokedex")]
    [ApiController]
    public class PokeDexController : ControllerBase
    {

        private readonly PokeDexDbContext _context;

        public PokeDexController(PokeDexDbContext context)
        {
            _context = context;
        }

        // api/pokedex GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var pokemons = _context.Pokemons.Where(d => !d.IsDeleted).ToList();
            
            return Ok(pokemons);
        }

        // api/pokedex/{ID} GET
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pokemons = _context.Pokemons.SingleOrDefault(d => d.Id == id);
            if(pokemons == null)
            {
                return NotFound();
            }
            return Ok(pokemons);
        }

        // api/pokedex/ POST
        [HttpPost]
        public IActionResult Post(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            return CreatedAtAction(nameof(GetById), new { id = pokemon.Id }, pokemon);
        }

        // api/pokedex/{ID} Put
        [HttpPut("{id}")]
        public IActionResult Update(int id,Pokemon input)
        {
            var pokemons = _context.Pokemons.SingleOrDefault(d => d.Id == id);
            if (pokemons == null)
            {
                return NotFound();
            }
            pokemons.Update(input.Nome, input.Tipo);

            return NoContent();

        }


        // api/pokedex/{ID} DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pokemons = _context.Pokemons.SingleOrDefault(d => d.Id == id);
            if (pokemons == null)
            {
                return NotFound();
            }
            pokemons.Delete();
            return NoContent();
        }
    }
}
