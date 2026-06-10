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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idTerapeuta = Convert.ToInt32(textBox1.Text);
                string nome = textBox2.Text;
                string abordagemClinica = textBox3.Text;
                string CRP = textBox4.Text;
                string telefone = textBox5.Text;
                string email = textBox6.Text;

               
                DAOTerapeuta daoTerapeuta = new DAOTerapeuta();
                daoTerapeuta.AtualizarTerapeuta(idTerapeuta, nome, abordagemClinica, CRP, telefone, email);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha todos os campos ");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro  tentar atualizar terapeuta: {erro.Message}");
            }


        } // fim do botao atualizar 
    }
}
