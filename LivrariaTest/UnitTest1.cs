using Livraria.DTO.Input;
using Livraria.DTO.Modelo;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace LivrariaTest
{
    [TestFixture]
    public class Tests


    {

        private HttpClient _httpClient;
        
        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5200");
          
        }

        [Test]
        public async Task DeveCadastrarLivroNovo()
        {
            var NovoLivro = new LivroInputDTO
            {
                Titulo = "O pequeno Principe",
                anoPublicacao =  1990,
                AutorInputIdDTO = new AutorInputIdDTO
                {
                    AutoresIds = new List<int> { 1}
                }
            };
            var response = await _httpClient.PostAsJsonAsync("/api/livro", NovoLivro);
            response.EnsureSuccessStatusCode();

            var livroCriado = await response.Content.ReadFromJsonAsync<LivroInputDTO>();
            

            Assert.That(livroCriado, Is.Not.Null);
            Assert.That(NovoLivro.Titulo, Is.EqualTo(livroCriado.Titulo));
            
        }

        [Test]
        public async Task DeveBuscarLivroPorId()
        {
            int livroId = 1;
            var response = await _httpClient.GetAsync($"/api/livro/{livroId}");
            response.EnsureSuccessStatusCode();
            var livroBuscado = await response.Content.ReadFromJsonAsync<LivroDTO>();

            Assert.That(livroBuscado, Is.Not.Null);
            Assert.That("Dom qui",Is.EqualTo(livroBuscado.Titulo));


        }

        [Test]
        public async Task DeveFalharAoBuscarPorIdNaoExistente()
        {
            int livroId = 122;
            var response = await _httpClient.GetAsync($"/api/livro/{livroId}");
            Assert.That(HttpStatusCode.NotFound,Is.EqualTo(response.StatusCode));
            var livroNulo = await response.Content.ReadAsStringAsync();
            Assert.That(livroNulo.Contains("Livro não encontrado"));
           
           
        }


        [Test]
        public async Task DeveListarOsLivros()
        {
            var response = await _httpClient.GetAsync("/api/livro");
            response.EnsureSuccessStatusCode();
            var livrosBuscados = await response.Content.ReadFromJsonAsync<List<LivroDTO>>();
            Assert.That(livrosBuscados, Is.Not.Empty);
        }

        [Test]
        public async Task DeveFalharAoIncluirLivroComAutorInexistente()
        {
            var livroAutorInexistente = new LivroInputDTO
            {
                Titulo = "O pequeno principe",
                anoPublicacao = 1990,
                AutorInputIdDTO = new AutorInputIdDTO
                {
                    AutoresIds = new List<int> {1,22 }
                }
            };

            var response = await _httpClient.PostAsJsonAsync("/api/livro", livroAutorInexistente);
            

            var livroAutor = await response.Content.ReadAsStringAsync();
            Assert.That(HttpStatusCode.BadRequest,Is.EqualTo(response.StatusCode));
            Assert.That(livroAutor.Contains("autor não encontrado"));
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
            
        }
    }
}