using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Negocio.Entidades;
using Vendinha.Negocio.Servicos;

namespace Vendinha.Desktop
{
    public partial class FormsDividas : Form
    {
        private readonly Cliente cliente;
        private readonly DividaServico servicoDivida;
        private List<Divida> dividas = new List<Divida>();

        public FormsDividas(Cliente cliente, DividaServico servicoDivida)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.servicoDivida = servicoDivida;
        }

        private void FormsDividas_Load(object sender, EventArgs e)
        {
            labelNomeCliente.Text = "Cliente: " + cliente.Nome;
            CarregarDividas();
        }

        private void buttonNovaDivida_Click(object sender, EventArgs e)
        {
            using var formsNovaDivida = new FormsNovaDivida(cliente.Id, servicoDivida);
            if (formsNovaDivida.ShowDialog(this) == DialogResult.OK)
            {
                CarregarDividas();
            }
        }

        private void buttonMarcarComoPaga_Click(object sender, EventArgs e)
        {
            int id = ObterIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione uma dívida.");
                return;
            }

            bool marcouComoPaga = servicoDivida.TryMarcarComoPaga(id, out string mensagemErro);
            if (!marcouComoPaga)
            {
                MessageBox.Show(mensagemErro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CarregarDividas();
        }

        private void CarregarDividas()
        {
            dividas = servicoDivida.ListarPorCliente(cliente.Id);
            dataGridViewDividas.Rows.Clear();

            foreach (Divida divida in dividas)
            {
                string dataPagamento = divida.DataPagamento.HasValue
                    ? divida.DataPagamento.Value.ToString("dd/MM/yyyy HH:mm")
                    : string.Empty;

                dataGridViewDividas.Rows.Add(
                    divida.Id,
                    divida.Valor,
                    divida.Situacao,
                    divida.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                    dataPagamento);
            }

            decimal totalAberto = dividas
                .Where(divida => divida.Situacao == SituacaoDivida.Aberta)
                .Sum(divida => divida.Valor);

            labelTotalAberto.Text = "Total em aberto: " + totalAberto.ToString("C2");
        }

        private int ObterIdSelecionado()
        {
            if (dataGridViewDividas.CurrentRow == null)
            {
                return 0;
            }

            return Convert.ToInt32(dataGridViewDividas.CurrentRow.Cells[0].Value);
        }
    }
}
