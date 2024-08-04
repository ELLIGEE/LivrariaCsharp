using Livraria.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net;

namespace Livraria.Models
{
    public class Livro
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

       
        public string Titulo { get; set; }

        [Column("ano_publicacao")]
        public int AnoPublicacao { get; set; }

        [NotNull]
        public virtual List<LivroAutor> Autores { get; set; } = new List<LivroAutor>();

        

            
        }
    }

