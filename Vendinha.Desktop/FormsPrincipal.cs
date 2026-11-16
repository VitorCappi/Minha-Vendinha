using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Negocio.Entidades;
using Vendinha.Negocio.Servicos;

namespace Vendinha.Desktop
{
    public partial class FormsPrincipal : Form
    {
        private readonly ClienteServico servicoCliente;
        private readonly DividaServico servicoDivida;
        private List<Cliente> clientes = new List<Cliente>();
        private int paginaAtual = 1;
        private const int QuantidadePorPagina = 10;

        public FormsPrincipal(ClienteServico servicoCliente, DividaServico servicoDivida)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            this.servicoDivida = servicoDivida;
        }

        private void FormsPrincipal_Load(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            paginaAtual = 1;
            CarregarClientes();
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            // Busca novamente os dados no banco sem fechar a aplicação.
            CarregarClientes();
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            if (paginaAtual > 1)
            {
                paginaAtual--;
                CarregarClientes();
            }
        }

        private void buttonProxima_Click(object sender, EventArgs e)
        {
            int totalPaginas = CalcularTotalPaginas();

            if (paginaAtual < totalPaginas)
            {
                paginaAtual++;
                CarregarClientes();
            }
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            using var formsCadastroCliente = new FormsCadastroCliente(servicoCliente);
            if (formsCadastroCliente.ShowDialog(this) == DialogResult.OK)
            {
                paginaAtual = 1;
                CarregarClientes();
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            int id = ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            Cliente cliente = servicoCliente.ObterPorId(id);
            if (cliente == null)
            {
                MessageBox.Show("Cliente não encontrado.");
                return;
            }

            using var formsCadastroCliente = new FormsCadastroCliente(servicoCliente, cliente);
            if (formsCadastroCliente.ShowDialog(this) == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        private void buttonDividas_Click(object sender, EventArgs e)
        {
            int id = ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            Cliente cliente = servicoCliente.ObterPorId(id);
            if (cliente == null)
            {
                MessageBox.Show("Cliente não encontrado.");
                return;
            }

            FormsDividas formsDividas = new FormsDividas(cliente, servicoDivida);
            formsDividas.Show(this);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int id = ObterIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este cliente? As dívidas dele também serão excluídas.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                bool excluiu = servicoCliente.TryExcluir(id, out string mensagemErro);

                if (!excluiu)
                {
                    MessageBox.Show(mensagemErro, "Exclusão não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                paginaAtual = 1;
                CarregarClientes();
            }
        }

        private void CarregarClientes()
        {
            clientes = servicoCliente.Listar();

            string textoBusca = textBoxBusca.Text.Trim();
            if (textoBusca != string.Empty)
            {
                clientes = clientes
                    .Where(cliente => cliente.Nome.IndexOf(textoBusca, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            clientes = clientes
                .OrderByDescending(cliente => cliente.TotalDividas)
                .ThenBy(cliente => cliente.Nome)
                .ToList();

            int totalPaginas = CalcularTotalPaginas();
            if (paginaAtual > totalPaginas)
            {
                paginaAtual = totalPaginas;
            }

            List<Cliente> clientesDaPagina = clientes
                .Skip((paginaAtual - 1) * QuantidadePorPagina)
                .Take(QuantidadePorPagina)
                .ToList();

            dataGridViewClientes.Rows.Clear();

            foreach (Cliente cliente in clientesDaPagina)
            {
                dataGridViewClientes.Rows.Add(
                    cliente.Id,
                    cliente.Nome,
                    cliente.Idade,
                    cliente.TotalDividas);
            }

            labelPagina.Text = "Página " + paginaAtual + " de " + totalPaginas;
            buttonAnterior.Enabled = paginaAtual > 1;
            buttonProxima.Enabled = paginaAtual < totalPaginas;
        }

        private int CalcularTotalPaginas()
        {
            if (clientes.Count == 0)
            {
                return 1;
            }

            return (int)Math.Ceiling((double)clientes.Count / QuantidadePorPagina);
        }

        private int ObterIdSelecionado()
        {
            if (dataGridViewClientes.CurrentRow == null)
            {
                return 0;
            }

            return Convert.ToInt32(dataGridViewClientes.CurrentRow.Cells[0].Value);
        }
    }
}

