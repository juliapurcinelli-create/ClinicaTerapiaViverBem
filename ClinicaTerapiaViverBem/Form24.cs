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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                int idProntuario = Convert.ToInt32(textBox1.Text);

                //  Instancia a classe DAO e chama o método de exclusão
                DAOProntuario daoProntuario = new DAOProntuario();
                daoProntuario.ExcluirProntuario(idProntuario);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha o campo de código .");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao tentar excluir prontuário: {erro.Message}");
            }


        }// fim do botao exluir prontuario 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 
    }
}
