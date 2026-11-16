using System;
using System.Collections.Generic;
using Vendinha.Negocio.Contratos;
using Vendinha.Negocio.Entidades;
using Vendinha.Negocio.Validacoes;

namespace Vendinha.Negocio.Servicos
{
    public class ClienteServico
    {
        private readonly IClienteRepositorio repositorioCliente;
        private readonly IDividaRepositorio repositorioDivida;

        public ClienteServico(
            IClienteRepositorio repositorioCliente,
            IDividaRepositorio repositorioDivida)
        {
            this.repositorioCliente = repositorioCliente;
            this.repositorioDivida = repositorioDivida;
        }

        public List<Cliente> Listar()
        {
            return repositorioCliente.Listar();
        }

        public Cliente ObterPorId(int id)
        {
            return repositorioCliente.ObterPorId(id);
        }

        public bool TryCadastrar(Cliente cliente, out string mensagemErro)
        {
            mensagemErro = ValidarCliente(cliente);
            if (mensagemErro != string.Empty)
            {
                return false;
            }

            cliente.Cpf = ValidadorCpf.SomenteDigitos(cliente.Cpf);

            if (repositorioCliente.ObterPorCpf(cliente.Cpf) != null)
            {
                mensagemErro = "Já existe um cliente com este CPF.";
                return false;
            }

            repositorioCliente.Inserir(cliente);
            return true;
        }

        public bool TryAtualizar(Cliente cliente, out string mensagemErro)
        {
            mensagemErro = ValidarCliente(cliente);
            if (mensagemErro != string.Empty)
            {
                return false;
            }

            cliente.Cpf = ValidadorCpf.SomenteDigitos(cliente.Cpf);
            Cliente clienteComMesmoCpf = repositorioCliente.ObterPorCpf(cliente.Cpf);

            if (clienteComMesmoCpf != null && clienteComMesmoCpf.Id != cliente.Id)
            {
                mensagemErro = "Já existe outro cliente com este CPF.";
                return false;
            }

            repositorioCliente.Atualizar(cliente);
            return true;
        }

        public bool TryExcluir(int id, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (id <= 0)
            {
                mensagemErro = "Cliente inválido.";
                return false;
            }

            if (repositorioCliente.ObterPorId(id) == null)
            {
                mensagemErro = "Cliente não encontrado.";
                return false;
            }

            if (repositorioDivida.ExisteAberta(id))
            {
                mensagemErro = "Não é possível excluir um cliente com dívida em aberto.";
                return false;
            }

            repositorioCliente.Excluir(id);
            return true;
        }

        private string ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return "Cliente inválido.";
            }

            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                return "O nome é obrigatório.";
            }

            if (string.IsNullOrWhiteSpace(cliente.Cpf))
            {
                return "O CPF é obrigatório.";
            }

            if (!ValidadorCpf.EhValido(cliente.Cpf))
            {
                return "O CPF informado é inválido.";
            }

            if (cliente.DataNascimento.Date > DateTime.Today)
            {
                return "A data de nascimento não pode ser futura.";
            }

            if (!string.IsNullOrWhiteSpace(cliente.Email) && !cliente.Email.Contains("@"))
            {
                return "O e-mail informado é inválido.";
            }

            return string.Empty;
        }
    }
}
