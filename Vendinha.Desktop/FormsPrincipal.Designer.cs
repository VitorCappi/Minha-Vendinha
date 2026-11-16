namespace Vendinha.Desktop
{
    partial class FormsPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxBusca;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Button buttonNovo;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonDividas;
        private System.Windows.Forms.Button buttonAnterior;
        private System.Windows.Forms.Button buttonProxima;
        private System.Windows.Forms.Label labelPagina;
        private System.Windows.Forms.Label labelBusca;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxBusca = new System.Windows.Forms.TextBox();
            buttonBuscar = new System.Windows.Forms.Button();
            buttonAtualizar = new System.Windows.Forms.Button();
            dataGridViewClientes = new System.Windows.Forms.DataGridView();
            buttonNovo = new System.Windows.Forms.Button();
            buttonEditar = new System.Windows.Forms.Button();
            buttonExcluir = new System.Windows.Forms.Button();
            buttonDividas = new System.Windows.Forms.Button();
            buttonAnterior = new System.Windows.Forms.Button();
            buttonProxima = new System.Windows.Forms.Button();
            labelPagina = new System.Windows.Forms.Label();
            labelBusca = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // labelBusca
            // 
            labelBusca.AutoSize = true;
            labelBusca.Location = new System.Drawing.Point(20, 2);
            labelBusca.Name = "labelBusca";
            labelBusca.Size = new System.Drawing.Size(91, 15);
            labelBusca.TabIndex = 11;
            labelBusca.Text = "Busque por Nome";
            // 
            // textBoxBusca
            // 
            textBoxBusca.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            textBoxBusca.Location = new System.Drawing.Point(20, 20);
            textBoxBusca.Name = "textBoxBusca";
            textBoxBusca.Size = new System.Drawing.Size(300, 23);
            textBoxBusca.TabIndex = 0;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new System.Drawing.Point(330, 19);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new System.Drawing.Size(90, 25);
            buttonBuscar.TabIndex = 1;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // buttonAtualizar
            // 
            buttonAtualizar.Location = new System.Drawing.Point(430, 19);
            buttonAtualizar.Name = "buttonAtualizar";
            buttonAtualizar.Size = new System.Drawing.Size(100, 25);
            buttonAtualizar.TabIndex = 2;
            buttonAtualizar.Text = "Atualizar";
            buttonAtualizar.UseVisualStyleBackColor = true;
            buttonAtualizar.Click += buttonAtualizar_Click;
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.AllowUserToAddRows = false;
            dataGridViewClientes.AllowUserToDeleteRows = false;
            dataGridViewClientes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Location = new System.Drawing.Point(20, 60);
            dataGridViewClientes.MultiSelect = false;
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersVisible = false;
            dataGridViewClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.Size = new System.Drawing.Size(760, 320);
            dataGridViewClientes.TabIndex = 3;
            dataGridViewClientes.Columns.Add("Id", "Id");
            dataGridViewClientes.Columns.Add("Nome", "Nome");
            dataGridViewClientes.Columns.Add("Idade", "Idade");
            dataGridViewClientes.Columns.Add("TotalDividas", "Total de dívidas");
            dataGridViewClientes.Columns[0].Visible = false;
            dataGridViewClientes.Columns[3].DefaultCellStyle.Format = "C2";
            // 
            // buttonNovo
            // 
            buttonNovo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonNovo.Location = new System.Drawing.Point(20, 400);
            buttonNovo.Name = "buttonNovo";
            buttonNovo.Size = new System.Drawing.Size(90, 30);
            buttonNovo.TabIndex = 4;
            buttonNovo.Text = "Novo";
            buttonNovo.UseVisualStyleBackColor = true;
            buttonNovo.Click += buttonNovo_Click;
            // 
            // buttonEditar
            // 
            buttonEditar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonEditar.Location = new System.Drawing.Point(120, 400);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new System.Drawing.Size(90, 30);
            buttonEditar.TabIndex = 5;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = true;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // buttonExcluir
            // 
            buttonExcluir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonExcluir.Location = new System.Drawing.Point(220, 400);
            buttonExcluir.Name = "buttonExcluir";
            buttonExcluir.Size = new System.Drawing.Size(90, 30);
            buttonExcluir.TabIndex = 6;
            buttonExcluir.Text = "Excluir";
            buttonExcluir.UseVisualStyleBackColor = true;
            buttonExcluir.Click += buttonExcluir_Click;
            // 
            // buttonDividas
            // 
            buttonDividas.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonDividas.Location = new System.Drawing.Point(320, 400);
            buttonDividas.Name = "buttonDividas";
            buttonDividas.Size = new System.Drawing.Size(100, 30);
            buttonDividas.TabIndex = 7;
            buttonDividas.Text = "Dívidas";
            buttonDividas.UseVisualStyleBackColor = true;
            buttonDividas.Click += buttonDividas_Click;
            // 
            // buttonAnterior
            // 
            buttonAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonAnterior.Location = new System.Drawing.Point(520, 400);
            buttonAnterior.Name = "buttonAnterior";
            buttonAnterior.Size = new System.Drawing.Size(100, 30);
            buttonAnterior.TabIndex = 8;
            buttonAnterior.Text = "Anterior";
            buttonAnterior.UseVisualStyleBackColor = true;
            buttonAnterior.Click += buttonAnterior_Click;
            // 
            // buttonProxima
            // 
            buttonProxima.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonProxima.Location = new System.Drawing.Point(680, 400);
            buttonProxima.Name = "buttonProxima";
            buttonProxima.Size = new System.Drawing.Size(100, 30);
            buttonProxima.TabIndex = 9;
            buttonProxima.Text = "Próxima";
            buttonProxima.UseVisualStyleBackColor = true;
            buttonProxima.Click += buttonProxima_Click;
            // 
            // labelPagina
            // 
            labelPagina.AutoSize = true;
            labelPagina.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelPagina.Location = new System.Drawing.Point(690, 35);
            labelPagina.Name = "labelPagina";
            labelPagina.Size = new System.Drawing.Size(44, 15);
            labelPagina.TabIndex = 10;
            labelPagina.Text = "Página 1 de 1";
            // 
            // FormsPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(810, 450);
            MinimumSize = new System.Drawing.Size(810, 450);
            Controls.Add(labelPagina);
            Controls.Add(buttonProxima);
            Controls.Add(buttonAnterior);
            Controls.Add(buttonDividas);
            Controls.Add(buttonExcluir);
            Controls.Add(buttonEditar);
            Controls.Add(buttonNovo);
            Controls.Add(dataGridViewClientes);
            Controls.Add(buttonAtualizar);
            Controls.Add(buttonBuscar);
            Controls.Add(textBoxBusca);
            Controls.Add(labelBusca);
            Name = "FormsPrincipal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Vendinha - Clientes";
            Load += FormsPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

