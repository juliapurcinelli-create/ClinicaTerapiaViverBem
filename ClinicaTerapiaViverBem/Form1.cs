using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaTerapiaViverBem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DAOConexaoBD dao = new DAOConexaoBD();

            if (dao.TestarConexao())
            {
                MessageBox.Show("CONEXÃO UM SUCESSO", "Status da Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("FALHA NA CONEXÃO", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }// fim do botao de teste para conexao com banco de dados 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente sair da aplicação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); // Fecha todo o programa
            }
        }// fim do botao sair tela "O que gostaria de  Fazer ?" 

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 telaMenu = new Form2();
            telaMenu.Show();
        } // fim do botao cadastrar 

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 telaMenu = new Form3();
            telaMenu.Show();
        }// fim do botao consultar 

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 telaMenu = new Form4();
            telaMenu.Show();
        }// fim do botao atualizar 

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 telaMenu = new Form5();
            telaMenu.Show();
        } // fim do botao excluir 
    }
}
