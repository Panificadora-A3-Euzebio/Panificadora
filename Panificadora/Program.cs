using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Panificadora
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>

        private static alerta alerta;
        
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login login = new login();
            Application.Run(login);

            if (login.loginBemSucedido)
            {
                Timer timer = new Timer();
                timer.Interval = 1000; // intervalo de 60 segundos
                timer.Tick += (sender, e) => verificaQuantidade();
                timer.Start();

                Application.Run(new dashboard());
            }
            

        }

        static void verificaQuantidade()
        {
            
            Conexao conexao = new Conexao();

            String tabela = "produtos";

            string solicitacao1 = $"SELECT quantidade FROM {tabela} WHERE NomeProduto = 'Lenhas para o forno de pizza' AND quantidade < 250";
            string solicitacao2 = $"SELECT quantidade FROM {tabela} WHERE NomeProduto = 'Sacos de trigo' AND quantidade < 250";

            int qtdLenha = 10000;
            int qtdTrigo = 10000;

            try
            {
                using (MySqlDataReader ler = conexao.GetDataReader(solicitacao1))
                {
                    if (ler.Read())
                    {
                        qtdLenha = Convert.ToInt32(ler["quantidade"]);
                        Console.WriteLine("Quantidade de lenha: " + qtdLenha);
                        alerta alerta = new alerta();
                    }
                }
                using (MySqlDataReader ler = conexao.GetDataReader(solicitacao2))
                {
                    if (ler.Read())
                    {
                        qtdTrigo = Convert.ToInt32(ler["quantidade"]);
                        Console.WriteLine("Quantidade de trigo: "+ qtdTrigo);
                    }
                }

                if (new alerta().Okpress)
                {
                    if (qtdLenha < 250 || qtdTrigo < 250)
                    {
                        if (alerta == null || alerta.IsDisposed)
                        {
                            alerta = new alerta();
                        }
                        alerta.Show();
                    }
                    else if (alerta != null && !alerta.IsDisposed)
                    {
                        alerta.Hide();
                    }
                }
                
            }
            catch (Exception ex) 
            { 
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
