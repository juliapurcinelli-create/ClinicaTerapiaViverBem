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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                int idAgendamento = Convert.ToInt32(textBox1.Text);
                string dataSessao = maskedTextBox1.Text.Split('/')[2] + "-" + maskedTextBox1.Text.Split('/')[1] + "-" + maskedTextBox1.Text.Split('/')[0];       // formato MySQL: AAAA-MM-DD
                string horarioSessao = maskedTextBox2.Text; //  formato MySQL: HH:MM:SS

                string valorTexto = textBox2.Text.Replace(".", ",");
                decimal ValorSessao = Convert.ToDecimal(textBox2.Text);

                string statusSessao = textBox3.Text;

           
                DAOAgendamento daoAgendamento = new DAOAgendamento();
                daoAgendamento.AtualizarAgendamento(idAgendamento, dataSessao, horarioSessao, ValorSessao, statusSessao);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha todos os dados .");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro  ao tentar atualizar agendamento: {erro.Message}");
            }

        }// fim do botao atualizar 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
