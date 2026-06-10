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
    public partial class Form19 : Form
    {
        public Form19()
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
               
                int idProntuario = Convert.ToInt32(textBox1.Text);
                string evoluçãoPaciente = textBox2.Text;
                string anotaçoesClinicas = textBox3.Text;

                
                DAOProntuario daoProntuario = new DAOProntuario();
                daoProntuario.AtualizarProntuario(idProntuario, evoluçãoPaciente, anotaçoesClinicas);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha todos os campos ");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao tentar atualizar prontuário: {erro.Message}");
            }


        }// fim do botao atualizar 
    }
}
