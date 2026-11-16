namespace Vendinha.Desktop
{
    partial class FormsNovaDivida
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.NumericUpDown numericUpDownValor;
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
            labelValor = new System.Windows.Forms.Label();
            numericUpDownValor = new System.Windows.Forms.NumericUpDown();
            buttonSalvar = new System.Windows.Forms.Button();
            buttonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownValor).BeginInit();
            SuspendLayout();
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Location = new System.Drawing.Point(20, 20);
            labelValor.Name = "labelValor";
            labelValor.Size = new System.Drawing.Size(39, 15);
            labelValor.TabIndex = 0;
            labelValor.Text = "Valor:";
            // 
            // numericUpDownValor
            // 
            numericUpDownValor.DecimalPlaces = 2;
            numericUpDownValor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownValor.Location = new System.Drawing.Point(20, 40);
            numericUpDownValor.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownValor.Name = "numericUpDownValor";
            numericUpDownValor.Size = new System.Drawing.Size(160, 23);
            numericUpDownValor.TabIndex = 1;
            numericUpDownValor.ThousandsSeparator = true;
            // 
            // buttonSalvar
            // 
            buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonSalvar.Location = new System.Drawing.Point(120, 90);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new System.Drawing.Size(85, 30);
            buttonSalvar.TabIndex = 2;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += buttonSalvar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonCancelar.Location = new System.Drawing.Point(215, 90);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new System.Drawing.Size(85, 30);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // FormsNovaDivida
            // 
            AcceptButton = buttonSalvar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancelar;
            ClientSize = new System.Drawing.Size(325, 150);
            MinimumSize = new System.Drawing.Size(325, 150);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSalvar);
            Controls.Add(numericUpDownValor);
            Controls.Add(labelValor);
            Name = "FormsNovaDivida";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Nova dívida";
            ((System.ComponentModel.ISupportInitialize)numericUpDownValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
