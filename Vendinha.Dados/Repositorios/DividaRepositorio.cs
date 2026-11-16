using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Vendinha.Negocio.Contratos;
using Vendinha.Negocio.Entidades;

namespace Vendinha.Dados.Repositorios
{
    public class DividaRepositorio : IDividaRepositorio
    {
        private readonly Banco.BancoDados banco;

        public DividaRepositorio(Banco.BancoDados banco)
        {
            this.banco = banco;
        }

        public List<Divida> ListarPorCliente(int clienteId)
        {
            List<Divida> dividas = new List<Divida>();

            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"SELECT Id, ClienteId, Valor, Situacao, DataCriacao, DataPagamento
                                        FROM Dividas WHERE ClienteId = @clienteId ORDER BY DataCriacao DESC";
                comando.Parameters.AddWithValue("@clienteId", clienteId);

                using (SqliteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        dividas.Add(CriarDivida(leitor));
                    }
                }
            }

            return dividas;
        }

        public Divida ObterPorId(int id)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"SELECT Id, ClienteId, Valor, Situacao, DataCriacao, DataPagamento
                                        FROM Dividas WHERE Id = @id";
                comando.Parameters.AddWithValue("@id", id);

                using (SqliteDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return CriarDivida(leitor);
                    }
                }
            }

            return null;
        }

        public bool ExisteAberta(int clienteId)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Dividas WHERE ClienteId = @clienteId AND Situacao = @situacao";
                comando.Parameters.AddWithValue("@clienteId", clienteId);
                comando.Parameters.AddWithValue("@situacao", (int)SituacaoDivida.Aberta);
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        public void Inserir(Divida divida)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"INSERT INTO Dividas
                                        (ClienteId, Valor, Situacao, DataCriacao, DataPagamento)
                                        VALUES (@clienteId, @valor, @situacao, @dataCriacao, @dataPagamento);";
                AdicionarParametros(comando, divida);
                comando.ExecuteNonQuery();
            }
        }

        public void Atualizar(Divida divida)
        {
            using (SqliteConnection conexao = banco.CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = @"UPDATE Dividas SET Situacao = @situacao,
                                        DataPagamento = @dataPagamento WHERE Id = @id;";
                comando.Parameters.AddWithValue("@id", divida.Id);
                comando.Parameters.AddWithValue("@situacao", (int)divida.Situacao);
                comando.Parameters.AddWithValue("@dataPagamento", divida.DataPagamento.HasValue
                    ? (object)divida.DataPagamento.Value.ToString("o") : DBNull.Value);
                comando.ExecuteNonQuery();
            }
        }

        private Divida CriarDivida(SqliteDataReader leitor)
        {
            Divida divida = new Divida();
            divida.Id = leitor.GetInt32(0);
            divida.ClienteId = leitor.GetInt32(1);
            divida.Valor = leitor.GetDecimal(2);
            divida.Situacao = (SituacaoDivida)leitor.GetInt32(3);
            divida.DataCriacao = DateTime.Parse(leitor.GetString(4));
            divida.DataPagamento = leitor.IsDBNull(5) ? (DateTime?)null : DateTime.Parse(leitor.GetString(5));
            return divida;
        }

        private void AdicionarParametros(SqliteCommand comando, Divida divida)
        {
            comando.Parameters.AddWithValue("@clienteId", divida.ClienteId);
            comando.Parameters.AddWithValue("@valor", divida.Valor);
            comando.Parameters.AddWithValue("@situacao", (int)divida.Situacao);
            comando.Parameters.AddWithValue("@dataCriacao", divida.DataCriacao.ToString("o"));
            comando.Parameters.AddWithValue("@dataPagamento", divida.DataPagamento.HasValue
                ? (object)divida.DataPagamento.Value.ToString("o") : DBNull.Value);
        }
    }
}
