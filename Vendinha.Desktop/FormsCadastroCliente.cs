using System;
using System.Windows.Forms;
using Vendinha.Negocio.Entidades;
using Vendinha.Negocio.Servicos;

namespace Vendinha.Desktop
{
    public partial class FormsCadastroCliente : Form
    {
        private readonly ClienteServico servicoCliente;
        private readonly Cliente clienteEmEdicao;

        public FormsCadastroCliente(ClienteServico servicoCliente, Cliente cliente = null)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            clienteEmEdicao = cliente;

            if (clienteEmEdicao != null)
            {
                Text = "Editar cliente";
                PreencherCampos();
            }
        }

        private void PreencherCampos()
        {
            textBoxNome.Text = clienteEmEdicao.Nome;
            maskedTextBoxCPF.Text = clienteEmEdicao.Cpf;
            dateTimePickerDataNascimento.Value = clienteEmEdicao.DataNascimento;
            textBoxEmail.Text = clienteEmEdicao.Email;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = textBoxNome.Text.Trim();
            cliente.Cpf = maskedTextBoxCPF.Text;
            cliente.DataNascimento = dateTimePickerDataNascimento.Value.Date;
            cliente.Email = textBoxEmail.Text.Trim();

            bool salvou;
            string mensagemErro;

            if (clienteEmEdicao == null)
            {
                salvou = servicoCliente.TryCadastrar(cliente, out mensagemErro);
            }
            else
            {
                cliente.Id = clienteEmEdicao.Id;
                salvou = servicoCliente.TryAtualizar(cliente, out mensagemErro);
            }

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
