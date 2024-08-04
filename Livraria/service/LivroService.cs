using AutoMapper;
using Livraria.DataContext;
using Livraria.DTO.Input;
using Livraria.Exceptions;
using Livraria.Models;
using Livraria.repository;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium.DevTools.V123.Page;
using System.ComponentModel;
using System.Net;

namespace Livraria.service
{
    public class LivroService : ILivroRepository
    {
        readonly ApplicationDbContext _context;
        readonly IMapper _mapper;
        readonly IAutorRepository _repository;

        public LivroService(ApplicationDbContext context, IMapper mapper, IAutorRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }



        public async Task<Livro> CreateLivroAscync(LivroInputDTO livro)
        {
            Livro livroAdicionado = new Livro
            {
                Titulo = livro.Titulo,
                AnoPublicacao = livro.anoPublicacao

            };
            await _context.Livro.AddAsync(livroAdicionado);
            foreach (var item in livro.AutorInputIdDTO.AutoresIds)
            {
                Autor autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == item);
                if (autor == null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "autor não encontrado");
                }

                LivroAutor livroAutor = new LivroAutor
                {
                    Autor = autor,
                    Livro = livroAdicionado,
                    AutorId = item,
                    LivroId = livroAdicionado.Id,
                };
                
               await _context.LivroAutor.AddAsync(livroAutor);

            }
           await  _context.SaveChangesAsync();

            return livroAdicionado;
            }

       

 
            
        

        public async Task DeleteLivroAscync(int id)
        {
            Livro livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Livro>> getAllAscync()
        {
            return await _context.Livro.Include(livro => livro.Autores).ThenInclude(la => la.Autor).
                ToListAsync();
        }

        public async Task<Livro> GetLivroByIdAscync(int id)
        {
            
                Livro livro = await _context.Livro.FindAsync(id);

            if (livro != null)
            {

                return livro;
            }
            else
            {
                throw  new HttpStatusCodeException(HttpStatusCode.NotFound, "Livro não encontrado");
            }
            
            
            
        }

       public async Task<Livro> UpdateLivroAscync(Livro livro, LivroInputDTO livroInputDTO)
        {
            var livroAtual = await _context.Livro.Include(l => l.Autores)
                                          .FirstOrDefaultAsync(l => l.Id == livro.Id);

            livroAtual.AnoPublicacao = livroInputDTO.anoPublicacao;
            livroAtual.Titulo = livroInputDTO.Titulo;
            livroAtual.Autores.Clear();
            foreach (var autorId in livroInputDTO.AutorInputIdDTO.AutoresIds)
            {
                // Verifica se o autor existe no banco de dados
                var autorExistente = await _context.Autor.FirstOrDefaultAsync(a => a.Id == autorId);
                if (autorExistente == null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Autor com ID {autorId} não encontrado!");
                }

                // Adicionar a associação LivroAutor
                livroAtual.Autores.Add(new LivroAutor
                {
                    LivroId = livroAtual.Id,
                    AutorId = autorExistente.Id
                });
            }

            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task AssociarAutorLivro(int autorId, int livroId)
        {
           var autor = await _context.Autor.FindAsync(autorId);
            var livro = await _context.Livro.FindAsync(livroId);
            if (autor == null || livro == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "autor ou livro não encontrado!");
            }
            try
            {
                LivroAutor livronovo = new LivroAutor
                {
                    AutorId = autorId,
                    LivroId = livroId
                };
                _context.LivroAutor.Add(livronovo);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Autor já está vinculado a este livro!");

            }

            }
            public async Task DesassociarAutorLivro(int autorId, int livroId)
        {
            var livroAtual = await _context.Livro.Include(l => l.Autores)
                                          .FirstOrDefaultAsync(l => l.Id == livroId);
            if (livroAtual == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Livro com ID {livroId} não encontrado.");
            }
            var livroAutor = await _context.LivroAutor.FirstOrDefaultAsync(la => la.AutorId == autorId && la.LivroId == livroId);
            if (livroAutor == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Associação entre autor com ID {autorId} e livro com ID {livroId} não encontrada.");
            }
            livroAtual.Autores.Remove(livroAutor);
            await _context.SaveChangesAsync();
        }
        

        }
       
    }

