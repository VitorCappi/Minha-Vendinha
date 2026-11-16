namespace Vendinha.Desktop
{
    partial class FormsInicio
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonAcessar;

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
            labelTitulo = new System.Windows.Forms.Label();
            buttonAcessar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitulo.Location = new System.Drawing.Point(185, 45);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(230, 45);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Minha Vendinha";
            // 
            // buttonAcessar
            // 
            buttonAcessar.Location = new System.Drawing.Point(250, 165);
            buttonAcessar.Name = "buttonAcessar";
            buttonAcessar.Size = new System.Drawing.Size(100, 35);
            buttonAcessar.TabIndex = 1;
            buttonAcessar.Text = "Acessar";
            buttonAcessar.UseVisualStyleBackColor = true;
            buttonAcessar.Click += buttonAcessar_Click;
            // 
            // FormsInicio
            // 
            AcceptButton = buttonAcessar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(600, 350);
            Controls.Add(buttonAcessar);
            Controls.Add(labelTitulo);
            MinimumSize = new System.Drawing.Size(400, 250);
            Name = "FormsInicio";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Minha Vendinha";
            Resize += FormsInicio_Resize;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
