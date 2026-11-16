namespace Vendinha.Desktop
{
    partial class FormsDividas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelNomeCliente;
        private System.Windows.Forms.Label labelTotalAberto;
        private System.Windows.Forms.DataGridView dataGridViewDividas;
        private System.Windows.Forms.Button buttonNovaDivida;
        private System.Windows.Forms.Button buttonMarcarComoPaga;

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
            labelNomeCliente = new System.Windows.Forms.Label();
            labelTotalAberto = new System.Windows.Forms.Label();
            dataGridViewDividas = new System.Windows.Forms.DataGridView();
            buttonNovaDivida = new System.Windows.Forms.Button();
            buttonMarcarComoPaga = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDividas).BeginInit();
            SuspendLayout();
            // 
            // labelNomeCliente
            // 
            labelNomeCliente.AutoSize = true;
            labelNomeCliente.Location = new System.Drawing.Point(20, 20);
            labelNomeCliente.Name = "labelNomeCliente";
            labelNomeCliente.Size = new System.Drawing.Size(108, 15);
            labelNomeCliente.TabIndex = 0;
            labelNomeCliente.Text = "Cliente: Nenhum";
            // 
            // labelTotalAberto
            // 
            labelTotalAberto.AutoSize = true;
            labelTotalAberto.Location = new System.Drawing.Point(20, 45);
            labelTotalAberto.Name = "labelTotalAberto";
            labelTotalAberto.Size = new System.Drawing.Size(111, 15);
            labelTotalAberto.TabIndex = 1;
            labelTotalAberto.Text = "Total em aberto: R$ 0,00";
            // 
            // dataGridViewDividas
            // 
            dataGridViewDividas.AllowUserToAddRows = false;
            dataGridViewDividas.AllowUserToDeleteRows = false;
            dataGridViewDividas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewDividas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDividas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDividas.Location = new System.Drawing.Point(20, 80);
            dataGridViewDividas.MultiSelect = false;
            dataGridViewDividas.Name = "dataGridViewDividas";
            dataGridViewDividas.ReadOnly = true;
            dataGridViewDividas.RowHeadersVisible = false;
            dataGridViewDividas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDividas.Size = new System.Drawing.Size(760, 280);
            dataGridViewDividas.TabIndex = 2;
            dataGridViewDividas.Columns.Add("Id", "Id");
            dataGridViewDividas.Columns.Add("Valor", "Valor");
            dataGridViewDividas.Columns.Add("Situacao", "Situação");
            dataGridViewDividas.Columns.Add("DataCriacao", "Data de criação");
            dataGridViewDividas.Columns.Add("DataPagamento", "Data de pagamento");
            dataGridViewDividas.Columns[0].Visible = false;
            dataGridViewDividas.Columns[1].DefaultCellStyle.Format = "C2";
            // 
            // buttonNovaDivida
            // 
            buttonNovaDivida.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonNovaDivida.Location = new System.Drawing.Point(20, 380);
            buttonNovaDivida.Name = "buttonNovaDivida";
            buttonNovaDivida.Size = new System.Drawing.Size(120, 30);
            buttonNovaDivida.TabIndex = 3;
            buttonNovaDivida.Text = "Nova dívida";
            buttonNovaDivida.UseVisualStyleBackColor = true;
            buttonNovaDivida.Click += buttonNovaDivida_Click;
            // 
            // buttonMarcarComoPaga
            // 
            buttonMarcarComoPaga.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonMarcarComoPaga.Location = new System.Drawing.Point(150, 380);
            buttonMarcarComoPaga.Name = "buttonMarcarComoPaga";
            buttonMarcarComoPaga.Size = new System.Drawing.Size(150, 30);
            buttonMarcarComoPaga.TabIndex = 4;
            buttonMarcarComoPaga.Text = "Marcar como paga";
            buttonMarcarComoPaga.UseVisualStyleBackColor = true;
            buttonMarcarComoPaga.Click += buttonMarcarComoPaga_Click;
            // 
            // FormsDividas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(810, 440);
            MinimumSize = new System.Drawing.Size(810, 440);
            Controls.Add(buttonMarcarComoPaga);
            Controls.Add(buttonNovaDivida);
            Controls.Add(dataGridViewDividas);
            Controls.Add(labelTotalAberto);
            Controls.Add(labelNomeCliente);
            Name = "FormsDividas";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Dívidas do cliente";
            Load += FormsDividas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
