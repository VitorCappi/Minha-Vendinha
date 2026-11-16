using System;
using System.Collections.Generic;
using Vendinha.Negocio.Contratos;
using Vendinha.Negocio.Entidades;

namespace Vendinha.Negocio.Servicos
{
    public class DividaServico
    {
        private readonly IDividaRepositorio repositorioDivida;

        public DividaServico(IDividaRepositorio repositorioDivida)
        {
            this.repositorioDivida = repositorioDivida;
        }

        public List<Divida> ListarPorCliente(int clienteId)
        {
            return repositorioDivida.ListarPorCliente(clienteId);
        }

        public bool TryCadastrar(Divida divida, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (divida == null || divida.ClienteId <= 0)
            {
                mensagemErro = "O cliente da dívida é obrigatório.";
                return false;
            }

            if (divida.Valor <= 0)
            {
                mensagemErro = "O valor da dívida deve ser maior que zero.";
                return false;
            }

            divida.Situacao = SituacaoDivida.Aberta;
            divida.DataCriacao = DateTime.Now;
            divida.DataPagamento = null;
            repositorioDivida.Inserir(divida);
            return true;
        }

        public bool TryMarcarComoPaga(int id, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            Divida divida = repositorioDivida.ObterPorId(id);

            if (divida == null)
            {
                mensagemErro = "Dívida não encontrada.";
                return false;
            }

            if (divida.Situacao == SituacaoDivida.Paga)
            {
                mensagemErro = "Esta dívida já está paga.";
                return false;
            }

            divida.Situacao = SituacaoDivida.Paga;
            divida.DataPagamento = DateTime.Now;
            repositorioDivida.Atualizar(divida);
            return true;
        }
    }
}
