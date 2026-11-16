using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Vendinha.Dados.Banco
{
    public class BancoDados
    {
        private readonly string caminhoBanco;

        public BancoDados(string caminhoBanco = "")
        {
            if (string.IsNullOrWhiteSpace(caminhoBanco))
            {
                string pastaBanco = Path.Combine(AppContext.BaseDirectory, "database");
                Directory.CreateDirectory(pastaBanco);
                this.caminhoBanco = Path.Combine(pastaBanco, "vendinha.db");
            }
            else
            {
                this.caminhoBanco = caminhoBanco;
                string pasta = Path.GetDirectoryName(caminhoBanco);
                if (!string.IsNullOrWhiteSpace(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }
            }
        }

        public SqliteConnection CriarConexao()
        {
            SqliteConnection conexao = new SqliteConnection("Data Source=" + caminhoBanco);
            conexao.Open();

            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "PRAGMA foreign_keys = ON;";
                comando.ExecuteNonQuery();
            }

            return conexao;
        }

        public void CriarEstrutura()
        {
            using (SqliteConnection conexao = CriarConexao())
            using (SqliteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = CarregarSchema();
                comando.ExecuteNonQuery();
            }
        }

        private string CarregarSchema()
        {
            string caminhoSchema = Path.Combine(
            AppContext.BaseDirectory,
            "database",
            "schema.sql");

            if (!File.Exists(caminhoSchema))
            {
                throw new FileNotFoundException(
                    "O arquivo schema.sql não foi encontrado.",
                    caminhoSchema);
            }

            return File.ReadAllText(caminhoSchema);
        }
    }
}
