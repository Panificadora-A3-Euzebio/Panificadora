using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panificadora
{
    public partial class Cadastro : Form
    {
        Conexao conexao = new Conexao();

        public Cadastro()
        {
            InitializeComponent();
            inserirDadosNoDataGridView1();
        }
        
        private void inserirDadosNoDataGridView1()
        {   
            // Insere a tabela de produtos no data GridView;
            try
            {
                String solicitacao = "SELECT * FROM produtos;";

                DataTable dataTable = conexao.GetDataTable(solicitacao);

                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void Cadastro_Click(object sender, EventArgs e)
        {
            // verificação se o nome do produto está vazio.
            if (String.IsNullOrWhiteSpace(produtoText.Text))
            {
                produtoText.Clear();
                MessageBox.Show("Não é aceito caracters vazios.\nComo nome de produto.");
                return;
            }
            // verificação se a unidade de venda esta vazia.
            if (String.IsNullOrEmpty(undVenda.Text))
            {
                MessageBox.Show("Selelicione alguma unidade de venda.");
                return;
            }
            String nomeProduto = produtoText.Text;
            String undDeVenda = undVenda.Text;
            int qtdProduto;

            // verificação se quantidade é um número inteiro positivo.
            bool validacao = int.TryParse(qtdText.Text, out qtdProduto);

            if (validacao)
            {
                
                if (qtdProduto >= 0)
                {
                    
                    produtoText.Clear();
                    qtdText.Clear();
                    undVenda.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Insira um numero válido.\nsó são aceitos números inteiros positivos.");
                    qtdText.Clear();
                }
            }
            else
            {
                MessageBox.Show("São aceitos apenas números para quantidade de um intem.");
                qtdText.Clear();
            }



            try
            {
                // Faz o cadastro dos dados no banco


                String solicitacao = $"INSERT INTO produtos (NomeProduto, quantidade, UnidadeDePeso)" +
                                     $"VALUES" +
                                     $"('{nomeProduto}',{qtdProduto},'{undDeVenda}')";

                conexao.SetSqlCommand(solicitacao);

                inserirDadosNoDataGridView1();
                MessageBox.Show("Cadastro bem sucedido!!!");
                
            }
            catch (Exception es) { Console.WriteLine("" + es); }
        }

        

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void produtoText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Voltar_Click(object sender, EventArgs e)
        {   
            // implementa a função de voltar para dashboard.
                
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
