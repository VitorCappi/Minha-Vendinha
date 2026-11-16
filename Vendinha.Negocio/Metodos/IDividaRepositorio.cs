using System.Collections.Generic;
using Vendinha.Negocio.Entidades;

namespace Vendinha.Negocio.Contratos
{
    public interface IDividaRepositorio
    {
        List<Divida> ListarPorCliente(int clienteId);
        Divida ObterPorId(int id);
        bool ExisteAberta(int clienteId);
        void Inserir(Divida divida);
        void Atualizar(Divida divida);
    }
}
