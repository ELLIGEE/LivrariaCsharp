using Livraria.Models;

namespace Livraria.repository
{
    public interface IAutorRepository
    {

        Task<List<Autor>> GetAllAscync();
        Task<Autor> GetAutorByIdAscync(int id);
        Task<Autor> CreateAutorAscync(Autor autor);
        Task<Autor> UpdateAutorAscync(Autor autor, int id);
        Task DeleteAutorAscync(int id); 
    }
}
