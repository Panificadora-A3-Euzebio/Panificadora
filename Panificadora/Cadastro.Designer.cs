namespace Panificadora
{
    partial class Cadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.produtoText = new System.Windows.Forms.TextBox();
            this.qtdText = new System.Windows.Forms.TextBox();
            this.cadastrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.undVenda = new System.Windows.Forms.ComboBox();
            this.Voltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unidade de venda";
            // 
            // produtoText
            // 
            this.produtoText.Location = new System.Drawing.Point(199, 240);
            this.produtoText.Name = "produtoText";
            this.produtoText.Size = new System.Drawing.Size(100, 20);
            this.produtoText.TabIndex = 3;
            this.produtoText.TextChanged += new System.EventHandler(this.produtoText_TextChanged);
            // 
            // qtdText
            // 
            this.qtdText.Location = new System.Drawing.Point(199, 272);
            this.qtdText.Name = "qtdText";
            this.qtdText.Size = new System.Drawing.Size(100, 20);
            this.qtdText.TabIndex = 4;
            // 
            // cadastrar
            // 
            this.cadastrar.Location = new System.Drawing.Point(353, 270);
            this.cadastrar.Name = "cadastrar";
            this.cadastrar.Size = new System.Drawing.Size(75, 23);
            this.cadastrar.TabIndex = 6;
            this.cadastrar.Text = "Cadastrar";
            this.cadastrar.UseVisualStyleBackColor = true;
            this.cadastrar.Click += new System.EventHandler(this.Cadastro_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(87, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(341, 196);
            this.dataGridView1.TabIndex = 7;
            // 
            // undVenda
            // 
            this.undVenda.FormattingEnabled = true;
            this.undVenda.Items.AddRange(new object[] {
            "",
            "50Kg",
            "50g",
            "1Kg",
            "5kg",
            "1L"});
            this.undVenda.Location = new System.Drawing.Point(199, 303);
            this.undVenda.Name = "undVenda";
            this.undVenda.Size = new System.Drawing.Size(100, 21);
            this.undVenda.TabIndex = 8;
            // 
            // Voltar
            // 
            this.Voltar.Location = new System.Drawing.Point(6, 12);
            this.Voltar.Name = "Voltar";
            this.Voltar.Size = new System.Drawing.Size(75, 23);
            this.Voltar.TabIndex = 9;
            this.Voltar.Text = "Voltar";
            this.Voltar.UseVisualStyleBackColor = true;
            this.Voltar.Click += new System.EventHandler(this.Voltar_Click);
            // 
            // Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 333);
            this.Controls.Add(this.Voltar);
            this.Controls.Add(this.undVenda);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cadastrar);
            this.Controls.Add(this.qtdText);
            this.Controls.Add(this.produtoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Cadastro";
            this.Text = "Cadastro de Itens";
            this.Load += new System.EventHandler(this.Cadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox produtoText;
        private System.Windows.Forms.TextBox qtdText;
        private System.Windows.Forms.Button cadastrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox undVenda;
        private System.Windows.Forms.Button Voltar;
    }
}