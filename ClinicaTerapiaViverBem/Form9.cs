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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DAOProntuario dao = new DAOProntuario();

                dao.Inserir(
              textBox1.Text,
             textBox2.Text);


                LimparCampos();
            }

            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado no formulário de prontuário: {erro.Message}");
            }






        }// fim do botao cadastrar prontuario 

        public void LimparCampos()
        {
            // Se quiser limpar o campo do código do paciente também:
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();

        }// fim do botao sair 
    }
}
