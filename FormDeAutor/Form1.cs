using Livraria.DTO.Input;
using Livraria.DTO.Modelo;
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

namespace FormDeAutor
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
            ListarAutores();




        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            var autor = new AutorInputDTO
            {
                Nome = txtNome.Text,
                Nacionalidade = txtId.Text,
                 
                
            };

            var response = await _httpClient.PostAsJsonAsync("/api/autor", autor);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Autor cadastrado com sucesso!");
                ListarAutores();
            }
            else
            {
                MessageBox.Show($"Erro ao cadastrar autor: {response.ReasonPhrase}");
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarAutorPorId(txtBuscarId.Text);
        }

        private async void buscarAutorPorId(string id)
        {
            if (!int.TryParse(id, out int idParaBuscar))
            {
                MessageBox.Show("ID inválido. Por favor, insira um número.");
                return;
            }

            try
            {
                var autor = await _httpClient.GetFromJsonAsync<AutorDTO>($"/api/autor/{idParaBuscar}");
                if (autor != null)
                {
                    var autores = new List<AutorDTO> { autor };
                    autoresDataGridView.DataSource = autores;
                }
                else
                {
                    MessageBox.Show($"Autor de ID {id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar autor: {ex.Message}");
            }
        }

        private async void ListarAutores()
        {
            try
            {
                var autores = await _httpClient.GetFromJsonAsync<List<AutorDTO>>("/api/autor");
                autoresDataGridView.DataSource = autores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar autores: {ex.Message}");
            }
        }
    }
}
    


