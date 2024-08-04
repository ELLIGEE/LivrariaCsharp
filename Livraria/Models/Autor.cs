using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Livraria.Models
{
    public class Autor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string  Nome { get; set;}

        public string Nacionalidade { get; set;}

        public virtual  ICollection<LivroAutor> Livros { get; set; } = new List<LivroAutor>();


        

        
    }
}
