const API_URL = 'http://localhost:5200/api';  // Atualize para o URL correto da sua API

        // Cadastro de Livro
        document.getElementById('cadastroLivroForm').addEventListener('submit', async function(e) {
            e.preventDefault();
            const titulo = document.getElementById('titulo').value;
            const anoPublicacao = parseInt(document.getElementById('anoPublicacao').value);
            const autorId = parseInt(document.getElementById('autorId').value);

            const novoLivro = {
                Titulo: titulo,
                anoPublicacao: anoPublicacao,
                AutorInputIdDTO: {
                    AutoresIds: [autorId]
                }
            };

            try {
                const response = await fetch(`${API_URL}/Livro`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(novoLivro)
                });

                if (response.ok) {
                    alert('Livro cadastrado com sucesso!');
                } else {
                    const error = await response.json();
                    alert(`Erro ao cadastrar livro: ${error.message}`);
                }
            } catch (error) {
                alert(`Erro ao cadastrar livro: ${error.message}`);
            }
        });

        // Buscar Livro
        document.getElementById('buscarLivroForm').addEventListener('submit', async function(e) {
            e.preventDefault();
            const livroId = parseInt(document.getElementById('buscarLivroId').value);

            try {
                const response = await fetch(`${API_URL}/livro/${livroId}`);

                if (response.ok) {
                    const livro = await response.json();
                    if (livro && livro.autores) {
                        document.getElementById('livroEncontrado').innerHTML = `
                            <p>Título: ${livro.titulo}</p>
                            <p>Ano de Publicação: ${livro.anoPublicacao}</p>
                            <p>Autor(es): ${livro.autores.map(a => a.nome).join(', ')}</p>
                        `;
                        document.getElementById('livroErro').innerHTML = '';
                    } else {
                        document.getElementById('livroEncontrado').innerHTML = '';
                        document.getElementById('livroErro').innerHTML = `<p>Erro ao buscar livro de ID ${livroId}: ${response.statusText}</p>`;
                    }
                } else {
                    alert(`Livro de ID ${livroId} não encontrado`);
                }
            } catch (error) {
                document.getElementById('livroEncontrado').innerHTML = '';
                document.getElementById('livroErro').innerHTML = `<p>Erro ao buscar livro: ${error.message}</p>`;
            }
        });

        // Listar Livros
        document.getElementById('listarLivrosBtn').addEventListener('click', async function() {
            try {
                const response = await fetch(`${API_URL}/livro`);

                if (response.ok) {
                    const livros = await response.json();
                    if (Array.isArray(livros) && livros.length > 0) {
                        document.getElementById('listaLivros').innerHTML = livros.map(livro => `
                            <div>
                                <p>ID: ${livro.id}</p>
                                <p>Título: ${livro.titulo}</p>
                                <p>Ano de Publicação: ${livro.anoPublicacao}</p>
                                <p>Autor(es): ${livro.autores.map(a => a.nome).join(', ')}</p>
                                <p></p>
                            </div>
                        `).join('');
                    } else {
                        document.getElementById('listaLivros').innerHTML = '<p>Nenhum livro encontrado.</p>';
                    }
                } else {
                    alert('Erro ao listar livros');
                }
            } catch (error) {
                alert(`Erro ao listar livros: ${error.message}`);
            }
        });