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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {   // instancia a classe daoterapeuta 
                DAOTerapeuta dao = new DAOTerapeuta();

            // chamar o metodo inserir 
            dao.Inserir(
            textBox1.Text,
            textBox2.Text,
         textBox3.Text,
            textBox4.Text,
            textBox5.Text       
        );

             LimparCampos();

            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado no formulário do terapeuta: {erro.Message}");
            }
        } // fim do botao cadastrar 

        public void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus(); // Coloca o cursor de volta no campo Nome
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 
    }
}
