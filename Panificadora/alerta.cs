using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Panificadora
{
    public partial class alerta : Form
    {
        public bool Okpress { get; set; }
        public alerta()
        {
            InitializeComponent();
            preencherDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Okpress = true;
            this.Close();
        }

        private void preencherDataGridView()
        {
            String tabela = "produtos";
            String solicitacao1 = $"SELECT * FROM {tabela} WHERE NomeProduto = 'Lenhas para o forno de pizza' AND quantidade < 250";
            String solicitacao2 = $"SELECT * FROM {tabela} WHERE NomeProduto = 'Sacos de trigo' AND quantidade < 250";

            Conexao conexao = new Conexao();
            
            String qtdLenha = "";
            String qtdTrigo = "";
            String lenhaStr = "";
            String trigoStr = "";
            String undMedidaLenhaStr = "";
            String uncMedidaTrigoStr = "";

            try
            {
                using (MySqlDataReader ler = conexao.GetDataReader(solicitacao2))
                {
                    if (ler.Read())
                    {
                        qtdTrigo = ler["quantidade"].ToString();
                        trigoStr = ler["NomeProduto"].ToString();
                        uncMedidaTrigoStr = ler["UnidadeDePeso"].ToString();
                        Console.WriteLine($"{qtdTrigo} + {trigoStr} + {uncMedidaTrigoStr}");
                    }
                }

                using (MySqlDataReader ler = conexao.GetDataReader(solicitacao1))
                {
                    if (ler.Read())
                    {
                        qtdLenha = ler["quantidade"].ToString();
                        lenhaStr = ler["NomeProduto"].ToString();
                        undMedidaLenhaStr = ler["UnidadeDePeso"].ToString();
                    }
                    
                }

                dataGridView1.Rows.Add(lenhaStr, undMedidaLenhaStr, qtdLenha);
                dataGridView1.Rows.Add(trigoStr, uncMedidaTrigoStr, qtdTrigo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
