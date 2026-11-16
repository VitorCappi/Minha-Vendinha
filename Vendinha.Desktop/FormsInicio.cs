using System;
using System.Windows.Forms;
using Vendinha.Negocio.Servicos;

namespace Vendinha.Desktop
{
    public partial class FormsInicio : Form
    {
        private readonly ClienteServico servicoCliente;
        private readonly DividaServico servicoDivida;

        public FormsInicio(ClienteServico servicoCliente, DividaServico servicoDivida)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            this.servicoDivida = servicoDivida;
            AjustarElementosAoRedimensionar();
        }

        private void FormsInicio_Resize(object sender, EventArgs e)
        {
            AjustarElementosAoRedimensionar();
        }

        private void AjustarElementosAoRedimensionar()
        {
            labelTitulo.Left = (ClientSize.Width - labelTitulo.Width) / 2;
            buttonAcessar.Left = (ClientSize.Width - buttonAcessar.Width) / 2;
            buttonAcessar.Top = (ClientSize.Height - buttonAcessar.Height) / 2;
        }

        private void buttonAcessar_Click(object sender, EventArgs e)
        {
            Hide();

            using (FormsPrincipal formsPrincipal = new FormsPrincipal(servicoCliente, servicoDivida))
            {
                formsPrincipal.ShowDialog(this);
            }

            Close();
        }
    }
}
