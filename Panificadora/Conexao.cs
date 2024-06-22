using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Panificadora
{
    internal class Conexao
    {
        // parametros para conexão com o banco.
        private String servidor = "localhost";
        private String banco = "estoque";
        private String usuario = "root";
        private String senha = "";

        private String data_source;

        // Construção da conexão em uma String.
        public Conexao()
        {
            data_source = $"server={servidor};Database={banco};username={usuario};password={senha}";
        }

        // Estabelece a conexao.
        public MySqlConnection GetSqlConnection()
        {
            return new MySqlConnection(data_source);
        }

        // Metodo que execução de comandos SQL
        public void SetSqlCommand(String solicitacao)
        {
            using (MySqlConnection conexao = GetSqlConnection())
            {
                conexao.Open();
                using (MySqlCommand cmd = new MySqlCommand(solicitacao, conexao))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Retorna um extrutura de dados do C# DataTable, ideal pra preence os gridViews do windows forms
        public DataTable GetDataTable(String solicitacao)
        {
            try
            {
                using (MySqlConnection conexao = GetSqlConnection())
                {
                    conexao.Open();

                    using (MySqlCommand cmd = new MySqlCommand(solicitacao, conexao))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            

        }

        // metodo que retorna valores da tabela
        public MySqlDataReader GetDataReader (String solicitacao)
        {
            MySqlConnection conexao = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(solicitacao, conexao);

            try
            {
                conexao.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                conexao.Close();
                throw;
            }
        }
       
    }
}