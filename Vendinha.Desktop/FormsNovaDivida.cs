using System;
using System.Windows.Forms;
using Vendinha.Negocio.Entidades;
using Vendinha.Negocio.Servicos;

namespace Vendinha.Desktop
{
    public partial class FormsNovaDivida : Form
    {
        private readonly int clienteId;
        private readonly DividaServico servicoDivida;

        public FormsNovaDivida(int clienteId, DividaServico servicoDivida)
        {
            InitializeComponent();
            this.clienteId = clienteId;
            this.servicoDivida = servicoDivida;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Divida divida = new Divida();
            divida.ClienteId = clienteId;
            divida.Valor = numericUpDownValor.Value;

            bool salvou = servicoDivida.TryCadastrar(divida, out string mensagemErro);
            if (!salvou)
            {
                MessageBox.Show(mensagemErro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
