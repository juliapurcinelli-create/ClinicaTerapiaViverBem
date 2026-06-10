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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // validacao do cpf 

                // Pega o texto da caixa  do CPF
                string cpfDigitado = maskedTextBox1.Text;

                // Chama a validação simplificada
                if (VALIDAÇAODOCPF.ValidarCPF(cpfDigitado) == false)
                {
                    MessageBox.Show("O CPF deve conter exatamente 11 números! Verifique o preenchimento.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Barra o avanço se não tiver 11 números
                }



                // 1. Coleta os dados dos campos de texto 
                int idPaciente = Convert.ToInt32(textBox2.Text);
                string nome = textBox1.Text;
                string dataNascimento = maskedTextBox2.Text.Split('/')[2] + "-" + maskedTextBox2.Text.Split('/')[1] + "-" + maskedTextBox2.Text.Split('/')[0]; // Formato AAAA-MM-DD
                long CPF = Convert.ToInt64(maskedTextBox1.Text.Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "")); // bigint no MySQL vira long no C#
                string telefone = textBox3.Text;
                string email = textBox4.Text;

                //  Instancia a DAO e envia as variáveis idênticas
                DAOPaciente daoPaciente = new DAOPaciente();
                daoPaciente.AtualizarPaciente(idPaciente, nome, dataNascimento, CPF, telefone, email);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro na interface: {erro.Message}");
            }


           

            
            


        }// fim do botao atualizar
    }
}
