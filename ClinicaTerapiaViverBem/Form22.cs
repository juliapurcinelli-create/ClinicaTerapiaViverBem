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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //  Coleta o código do agendamento do campo do código 
                int idAgendamento = Convert.ToInt32(textBox1.Text);

               
                DAOAgendamento daoAgendamento = new DAOAgendamento();
                daoAgendamento.ExcluirAgendamento(idAgendamento);
            }
            catch (FormatException)
            {
                // Caso o usuário deixe o campo vazio 
                MessageBox.Show("Por favor, preencha o campo com o código.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro  ao tentar excluir a  sessão: {erro.Message}");
            }

        }// fim do botao excluir 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
