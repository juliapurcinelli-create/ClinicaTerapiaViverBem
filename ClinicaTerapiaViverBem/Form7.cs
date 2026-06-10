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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // instancia a classe daoagendamento 
            try
            {
                DAOAgendamento dao = new DAOAgendamento();

                int idPaciente = Convert.ToInt32(textBox3.Text);
                int idTerapeuta = Convert.ToInt32(textBox4.Text);

                // chamar ometodo inserir 

                dao.Inserir(
                maskedTextBox1.Text,
               maskedTextBox2.Text,
                textBox1.Text,
                textBox2.Text,
                   idPaciente,
                   idTerapeuta);


                LimparCampos();
            }

            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha todos os campos. Lembre-se de que os campos de Código aceitam apenas números!", "Erro de Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado no formulário: {erro.Message}");
            }



        }

        public void LimparCampos()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Focus(); // Devolve o foco para o primeiro campo
        }// fim do botao agendar sessoes 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }// fim do botao sair 
    }

