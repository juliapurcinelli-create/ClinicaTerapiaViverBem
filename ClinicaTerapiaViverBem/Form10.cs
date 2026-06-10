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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DAOFinanceiro dao = new DAOFinanceiro();

                dao.Inserir(
                 textBox2.Text,
                 maskedTextBox1.Text,
                textBox3.Text,
                 textBox4.Text
        );

                LimparCampos();


            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado no formulário financeiro: {erro.Message}");
            }
        }

        public void LimparCampos()
        {
            textBox1.Clear(); // Limpa o campo do código também para o usuário
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Focus(); // Coloca o cursor no valor
        }// fim do botao Registrar 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }// fim do botao sair 
    }

