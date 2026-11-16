namespace Vendinha.Desktop
{
    partial class FormsCadastroCliente
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCPF;
        private System.Windows.Forms.Label labelDataNascimento;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataNascimento;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCancelar;

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
            labelNome = new System.Windows.Forms.Label();
            textBoxNome = new System.Windows.Forms.TextBox();
            labelCPF = new System.Windows.Forms.Label();
            maskedTextBoxCPF = new System.Windows.Forms.MaskedTextBox();
            labelDataNascimento = new System.Windows.Forms.Label();
            dateTimePickerDataNascimento = new System.Windows.Forms.DateTimePicker();
            labelEmail = new System.Windows.Forms.Label();
            textBoxEmail = new System.Windows.Forms.TextBox();
            buttonSalvar = new System.Windows.Forms.Button();
            buttonCancelar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new System.Drawing.Point(20, 20);
            labelNome.Name = "labelNome";
            labelNome.Size = new System.Drawing.Size(43, 15);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            textBoxNome.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxNome.Location = new System.Drawing.Point(20, 40);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new System.Drawing.Size(340, 23);
            textBoxNome.TabIndex = 1;
            // 
            // labelCPF
            // 
            labelCPF.AutoSize = true;
            labelCPF.Location = new System.Drawing.Point(20, 80);
            labelCPF.Name = "labelCPF";
            labelCPF.Size = new System.Drawing.Size(31, 15);
            labelCPF.TabIndex = 2;
            labelCPF.Text = "CPF:";
            // 
            // maskedTextBoxCPF
            // 
            maskedTextBoxCPF.Location = new System.Drawing.Point(20, 100);
            maskedTextBoxCPF.Mask = "000\\.000\\.000-00";
            maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            maskedTextBoxCPF.Size = new System.Drawing.Size(140, 23);
            maskedTextBoxCPF.TabIndex = 3;
            // 
            // labelDataNascimento
            // 
            labelDataNascimento.AutoSize = true;
            labelDataNascimento.Location = new System.Drawing.Point(20, 140);
            labelDataNascimento.Name = "labelDataNascimento";
            labelDataNascimento.Size = new System.Drawing.Size(113, 15);
            labelDataNascimento.TabIndex = 4;
            labelDataNascimento.Text = "Data de nascimento:";
            // 
            // dateTimePickerDataNascimento
            // 
            dateTimePickerDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateTimePickerDataNascimento.Location = new System.Drawing.Point(20, 160);
            dateTimePickerDataNascimento.MaxDate = System.DateTime.Today;
            dateTimePickerDataNascimento.Name = "dateTimePickerDataNascimento";
            dateTimePickerDataNascimento.Size = new System.Drawing.Size(140, 23);
            dateTimePickerDataNascimento.TabIndex = 5;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new System.Drawing.Point(20, 200);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(44, 15);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "E-mail:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxEmail.Location = new System.Drawing.Point(20, 220);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(340, 23);
            textBoxEmail.TabIndex = 7;
            // 
            // buttonSalvar
            // 
            buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonSalvar.Location = new System.Drawing.Point(180, 270);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new System.Drawing.Size(85, 30);
            buttonSalvar.TabIndex = 8;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += buttonSalvar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonCancelar.Location = new System.Drawing.Point(275, 270);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new System.Drawing.Size(85, 30);
            buttonCancelar.TabIndex = 9;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // FormsCadastroCliente
            // 
            AcceptButton = buttonSalvar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancelar;
            ClientSize = new System.Drawing.Size(390, 330);
            MinimumSize = new System.Drawing.Size(390, 330);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSalvar);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Controls.Add(dateTimePickerDataNascimento);
            Controls.Add(labelDataNascimento);
            Controls.Add(maskedTextBoxCPF);
            Controls.Add(labelCPF);
            Controls.Add(textBoxNome);
            Controls.Add(labelNome);
            Name = "FormsCadastroCliente";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Novo cliente";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
