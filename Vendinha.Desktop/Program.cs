using System;
using System.Windows.Forms;
using Vendinha.Dados.Banco;
using Vendinha.Dados.Repositorios;
using Vendinha.Negocio.Servicos;

namespace Vendinha.Desktop
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BancoDados banco = new BancoDados();
            banco.CriarEstrutura();

            ClienteRepositorio repositorioCliente = new ClienteRepositorio(banco);
            DividaRepositorio repositorioDivida = new DividaRepositorio(banco);
            ClienteServico servicoCliente = new ClienteServico(repositorioCliente, repositorioDivida);
            DividaServico servicoDivida = new DividaServico(repositorioDivida);

            Application.Run(new FormsInicio(servicoCliente, servicoDivida));
        }
    }
}
