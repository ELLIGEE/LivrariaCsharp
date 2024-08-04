namespace FormDeAutor
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtBuscarId;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.DataGridView autoresDataGridView;
        private System.Windows.Forms.Button btnBuscar;
        

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
            txtNome = new System.Windows.Forms.TextBox();
            txtId = new System.Windows.Forms.TextBox();
            btnCadastrar = new System.Windows.Forms.Button();
            txtBuscarId = new System.Windows.Forms.TextBox();
            btnBuscar = new System.Windows.Forms.Button();
            autoresDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)autoresDataGridView).BeginInit();
            SuspendLayout();
            
            // config do nome

            txtNome.Location = new System.Drawing.Point(13, 88);
            txtNome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new System.Drawing.Size(233, 23);
            txtNome.TabIndex = 0;
            
            //config do id

            txtId.Location = new System.Drawing.Point(13, 148);
            txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Nacionalidade";
            txtId.Size = new System.Drawing.Size(233, 23);
            txtId.TabIndex = 1;
            
            //config de botao para cadastrar

            btnCadastrar.Location = new System.Drawing.Point(13, 224);
            btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new System.Drawing.Size(233, 27);
            btnCadastrar.TabIndex = 2;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            
            //config do buscar pelo id

            txtBuscarId.Location = new System.Drawing.Point(292, 27);
            txtBuscarId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtBuscarId.Name = "txtBuscarId";
            txtBuscarId.PlaceholderText = "Buscar por ID";
            txtBuscarId.Size = new System.Drawing.Size(116, 23);
            txtBuscarId.TabIndex = 3;
            
            //config do botao para buscar

            btnBuscar.Location = new System.Drawing.Point(420, 23);
            btnBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(88, 27);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
           
            //config do datagrid para listar 

            autoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            autoresDataGridView.Location = new System.Drawing.Point(292, 69);
            autoresDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            autoresDataGridView.Name = "autoresDataGridView";
            autoresDataGridView.Size = new System.Drawing.Size(271, 231);
            autoresDataGridView.TabIndex = 5;
           
            //dimensoes do forms

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(578, 327);
            Controls.Add(autoresDataGridView);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarId);
            Controls.Add(btnCadastrar);
            Controls.Add(txtId);
            Controls.Add(txtNome);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Gerenciamento de Autores";
            ((System.ComponentModel.ISupportInitialize)autoresDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }

    #endregion

  
}


