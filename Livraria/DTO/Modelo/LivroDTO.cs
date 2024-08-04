namespace Livraria.DTO.Modelo
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string anoPublicacao { get; set; }
        public List<AutorDTO> Autores { get; set; }
    }
}
