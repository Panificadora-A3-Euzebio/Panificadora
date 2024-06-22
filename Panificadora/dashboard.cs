using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panificadora
{
    public partial class dashboard : Form
    {
        private int idProduto;
        private int valorCell;
        private Conexao conexao = new Conexao();


        public dashboard()
        {
            InitializeComponent();
            inserirDadosNoDataGridView1();

            // Configuração do DataGridView
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;

            // Adiciona o evento SelectionChanged
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
        }
        
        private int validarEntradaDeDado()
        {
            int qtdTxtBoxEntrada;

            bool valiedacao = int.TryParse(valorTxt.Text, out qtdTxtBoxEntrada);

            if (valiedacao)
            {
                if (qtdTxtBoxEntrada > 0) 
                { 
                    valorTxt.Clear(); 
                    return qtdTxtBoxEntrada; 
                }
                else 
                { 
                    MessageBox.Show("entrada invalida."); 
                    valorTxt.Clear(); 
                }
                
            }

            return 0;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void adicionar_Click(object sender, EventArgs e)
        {
            int adicaoBanco = valorCell + validarEntradaDeDado();

            try
            {
                String solicitacao = $"UPDATE produtos SET quantidade = {adicaoBanco} WHERE id_produto = {idProduto};";
                conexao.SetSqlCommand(solicitacao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            // atualiza o dataGridView após a alteração
            inserirDadosNoDataGridView1();
        }

        private void remover_Click(object sender, EventArgs e)
        {
            int subtracaoBanco = valorCell - validarEntradaDeDado();

            try
            {
                String solicitacao = $"UPDATE produtos SET quantidade = {subtracaoBanco} WHERE id_produto = {idProduto};";
                conexao.SetSqlCommand(solicitacao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            // atualiza o dataGridView após a alteração
            inserirDadosNoDataGridView1();
        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();

            cadastro.Show();

            this.Hide();
        }

        private void inserirDadosNoDataGridView1()
        {
            try
            {
                String solicitacao = "SELECT * FROM produtos;";

                DataTable dataTable =  conexao.GetDataTable(solicitacao);

                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                DataGridViewRow linhaSelecionada = dataGridView1.SelectedRows[0];

                List<int> lista = new List<int>();

                foreach (DataGridViewCell celula in linhaSelecionada.Cells)
                {
                    if (int.TryParse(celula.Value?.ToString(), out int valorCelula))
                    {
                        lista.Add(valorCelula);
                    }
                }
                idProduto = lista[0];
                valorCell = lista[1];

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
