using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
    public class LivroAutor
    {

        
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
       
    }
}
