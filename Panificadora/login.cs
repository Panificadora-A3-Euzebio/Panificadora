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
    public partial class login : Form
    {
        

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String UserLogin = textBox1.Text;
            String senha = textBox2.Text;


            if (UserLogin.Equals("admin") && senha.Equals("admin"))
            {
                MessageBox.Show("Login realizado");
                dashboard dashboard = new dashboard();

                dashboard.Show(); 
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Senha incorreta");
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
