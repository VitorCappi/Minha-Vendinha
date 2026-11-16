using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Vendinha.Negocio.Contratos;
using Vendinha.Negocio.Entidades;

namespace Vendinha.Dados.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Banco.BancoDados banco;

        public ClienteRepositorio(Banco.BancoDados banco)
        {
            this.banco = banco;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Id, Nome, Cpf, DataNascimento, Email FROM Clientes ORDER BY Nome";

                using (SqliteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Cliente cliente = CriarCliente(leitor);
                        cliente.Dividas = ListarDividas(conexao, cliente.Id);
                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public Cliente ObterPorId(int id)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Id, Nome, Cpf, DataNascimento, Email FROM Clientes WHERE Id = @id";
                comando.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        Cliente cliente = CriarCliente(leitor);
                        cliente.Dividas = ListarDividas(conexao, cliente.Id);
                        return cliente;
                    }
                }
            }

            return null;
        }

        public Cliente ObterPorCpf(string cpf)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Id, Nome, Cpf, DataNascimento, Email FROM Clientes WHERE Cpf = @cpf";
                comando.Parameters.AddWithValue("@cpf", cpf);

                using (SqliteDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return CriarCliente(leitor);
                    }
                }
            }

            return null;
        }

        public void Inserir(Cliente cliente)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"
                            INSERT INTO Clientes (Nome, Cpf, DataNascimento, Email)
                            VALUES (@nome, @cpf, @dataNascimento, @email);";
                AdicionarParametrosCliente(comando, cliente);
                comando.ExecuteNonQuery();
            }
        }

        public void Atualizar(Cliente cliente)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"UPDATE Clientes
                                        SET Nome = @nome, 
                                            Cpf = @cpf,
                                            DataNascimento = @dataNascimento, 
                                            Email = @email
                                        WHERE Id = @id;";
                comando.Parameters.AddWithValue("@id", cliente.Id);
                AdicionarParametrosCliente(comando, cliente);
                comando.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "DELETE FROM Clientes WHERE Id = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
        }

        private Cliente CriarCliente(SqliteDataReader leitor)
        {
            Cliente cliente = new Cliente();
            cliente.Id = leitor.GetInt32(0);
            cliente.Nome = leitor.GetString(1);
            cliente.Cpf = leitor.GetString(2);
            cliente.DataNascimento = DateTime.Parse(leitor.GetString(3));
            cliente.Email = leitor.IsDBNull(4) ? string.Empty : leitor.GetString(4);
            return cliente;
        }

        private List<Divida> ListarDividas(SqliteConnection conexao, int clienteId)
        {
            List<Divida> dividas = new List<Divida>();

            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"
                        SELECT Id, ClienteId, Valor, Situacao, DataCriacao, DataPagamento
                        FROM Dividas WHERE ClienteId = @clienteId ORDER BY DataCriacao DESC";
                comando.Parameters.AddWithValue("@clienteId", clienteId);

                using (SqliteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Divida divida = new Divida();
                        divida.Id = leitor.GetInt32(0);
                        divida.ClienteId = leitor.GetInt32(1);
                        divida.Valor = leitor.GetDecimal(2);
                        divida.Situacao = (SituacaoDivida)leitor.GetInt32(3);
                        divida.DataCriacao = DateTime.Parse(leitor.GetString(4));
                        divida.DataPagamento = leitor.IsDBNull(5) ? (DateTime?)null : DateTime.Parse(leitor.GetString(5));
                        dividas.Add(divida);
                    }
                }
            }

            return dividas;
        }

        private void AdicionarParametrosCliente(SqliteCommand comando, Cliente cliente)
        {
            comando.Parameters.AddWithValue("@nome", cliente.Nome);
            comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
            comando.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento.ToString("o"));
            comando.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(cliente.Email) ? (object)DBNull.Value : cliente.Email);
        }
    }
}
