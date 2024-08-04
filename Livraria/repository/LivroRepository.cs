using Livraria.DTO.Input;
using Livraria.Models;

namespace Livraria.repository
{
    public interface ILivroRepository
    {
        Task<List<Livro>> getAllAscync();
        Task<Livro> GetLivroByIdAscync(int id);
        Task<Livro> CreateLivroAscync(LivroInputDTO livro);
        Task<Livro> UpdateLivroAscync(Livro livro, LivroInputDTO livroInputDTO);
        Task DeleteLivroAscync(int id);
        Task DesassociarAutorLivro(int autorId, int livroId);
        Task AssociarAutorLivro(int autorId, int livroId);
        
    }
}
