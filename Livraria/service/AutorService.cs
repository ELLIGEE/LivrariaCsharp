using AutoMapper;
using Livraria.DataContext;
using Livraria.Exceptions;
using Livraria.Models;
using Livraria.repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Livraria.service
{
    public class AutorService : IAutorRepository
    {
        readonly ApplicationDbContext _context;
        readonly IMapper _mapper;

        public AutorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async  Task<Autor> CreateAutorAscync(Autor autor)
        {
            if(autor != null)
            {
              await  _context.AddAsync(autor);
                await _context.SaveChangesAsync();
                return autor;
            }else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Dados invalidos para Autor!");
            }
        }

        public async  Task DeleteAutorAscync(int id)
        {
            var Autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == id);
            if(Autor == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Autor não existe!");
            }

             _context.Remove(Autor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Autor>> GetAllAscync()
        {
            return await _context.Autor.ToListAsync();
        }

        public async Task<Autor> GetAutorByIdAscync(int id)
        {
            
                Autor autor = await _context.Autor.FindAsync(id);
                if(autor == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Autor não encontrado");
            }
            return autor;
            
            
            
        }

        public async  Task<Autor> UpdateAutorAscync(Autor autor, int id)
        {
            Autor AutorAtual = await  GetAutorByIdAscync(id);
                _mapper.Map(autor, AutorAtual);
               await  _context.SaveChangesAsync();
                return AutorAtual;
            

        }
    }
}
