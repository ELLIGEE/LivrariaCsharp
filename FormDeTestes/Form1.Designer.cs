namespace FormDeTestes
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtAutorId;
        private System.Windows.Forms.Button btnCadastrarLivro;
        private System.Windows.Forms.Button btnBuscarLivros;
        private System.Windows.Forms.DataGridView dgvLivros;
      

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitulo = new System.Windows.Forms.TextBox();
            txtAno = new System.Windows.Forms.TextBox();
            txtAutorId = new System.Windows.Forms.TextBox();
            btnCadastrarLivro = new System.Windows.Forms.Button();
            btnBuscarLivros = new System.Windows.Forms.Button();
            dgvLivros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLivros).BeginInit();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new System.Drawing.Point(12, 12);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Título do Livro";
            txtTitulo.Size = new System.Drawing.Size(200, 23);
            txtTitulo.TabIndex = 0;
            // 
            // txtAno
            // 
            txtAno.Location = new System.Drawing.Point(12, 38);
            txtAno.Name = "txtAno";
            txtAno.PlaceholderText = "Ano de Publicação";
            txtAno.Size = new System.Drawing.Size(200, 23);
            txtAno.TabIndex = 1;
            // 
            // txtAutorId
            // 
            txtAutorId.Location = new System.Drawing.Point(12, 64);
            txtAutorId.Name = "txtAutorId";
            txtAutorId.PlaceholderText = "ID do Autor";
            txtAutorId.Size = new System.Drawing.Size(200, 23);
            txtAutorId.TabIndex = 2;
            // 
            // btnCadastrarLivro
            // 
            btnCadastrarLivro.Location = new System.Drawing.Point(12, 90);
            btnCadastrarLivro.Name = "btnCadastrarLivro";
            btnCadastrarLivro.Size = new System.Drawing.Size(200, 23);
            btnCadastrarLivro.TabIndex = 3;
            btnCadastrarLivro.Text = "Cadastrar Livro";
            btnCadastrarLivro.UseVisualStyleBackColor = true;
            btnCadastrarLivro.Click += btnCadastrarLivro_Click;
            // 
            // btnBuscarLivros
            // 
            btnBuscarLivros.Location = new System.Drawing.Point(12, 119);
            btnBuscarLivros.Name = "btnBuscarLivros";
            btnBuscarLivros.Size = new System.Drawing.Size(200, 23);
            btnBuscarLivros.TabIndex = 4;
            btnBuscarLivros.Text = "Buscar Livros";
            btnBuscarLivros.UseVisualStyleBackColor = true;
            btnBuscarLivros.Click += btnBuscarLivros_Click;
            // 
            // dgvLivros
            // 
            dgvLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLivros.Location = new System.Drawing.Point(12, 148);
            dgvLivros.Name = "dgvLivros";
            dgvLivros.Size = new System.Drawing.Size(367, 254);
            dgvLivros.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(395, 461);
            Controls.Add(txtTitulo);
            Controls.Add(txtAno);
            Controls.Add(txtAutorId);
            Controls.Add(btnCadastrarLivro);
            Controls.Add(btnBuscarLivros);
            Controls.Add(dgvLivros);
            Name = "Form1";
            Text = "Livraria";
            ((System.ComponentModel.ISupportInitialize)dgvLivros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

