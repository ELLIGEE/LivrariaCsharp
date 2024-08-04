using Livraria.DTO.Input;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDeTestes
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5200") // Substitua pela URL da sua API
            };

            CarregarLivros();
            CarregarAutores();
        }
        private async void btnCadastrarLivro_Click(object sender, EventArgs e)
        {
            try
            {
                var livroInputDto = new LivroInputDTO
                {
                    Titulo = txtTitulo.Text,
                    anoPublicacao = int.Parse(txtAno.Text),


                    AutorInputIdDTO = new AutorInputIdDTO { AutoresIds = new List<int> { int.Parse(txtAutorId.Text) } }
                };

                var response = await _httpClient.PostAsJsonAsync("/api/livro", livroInputDto);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Livro cadastrado com sucesso!");
                CarregarLivros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar livro: {ex.Message}");
            }
        }

        private async void btnBuscarLivros_Click(object sender, EventArgs e)
        {
            CarregarLivros();
        }

        private async void CarregarLivros()
        {
            try
            {
                var livros = await _httpClient.GetFromJsonAsync<Livro[]>("/api/livro");
                dgvLivros.DataSource = livros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar livros: {ex.Message}");
            }
        }

        private async void CarregarAutores()
        {
            try
            {
                var autores = await _httpClient.GetFromJsonAsync<Autor[]>("/api/autor");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar autores: {ex.Message}");
            }
        }
    }
}
