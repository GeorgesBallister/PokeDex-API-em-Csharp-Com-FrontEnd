using System.Data;

namespace Pokedex.Entities.Models
{
    public class Pokemon
    {
        public Pokemon()
        {
            IsDeleted = false;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string nome, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
