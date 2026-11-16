using System.Collections.Generic;
using Vendinha.Negocio.Entidades;

namespace Vendinha.Negocio.Contratos
{
    public interface IClienteRepositorio
    {
        List<Cliente> Listar();
        Cliente ObterPorId(int id);
        Cliente ObterPorCpf(string cpf);
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int id);
    }
}
