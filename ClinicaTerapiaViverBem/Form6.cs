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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)


        {
            try
            {
                // validaçao do cpf com os 11 digitos 

                // Pega o texto da caixa do CPF
                string cpfDigitado = maskedTextBox2.Text;

                // Chama a validação simplificada
                if (VALIDAÇAODOCPF.ValidarCPF(cpfDigitado) == false)
                {
                    MessageBox.Show("O CPF deve conter exatamente 11 números! Verifique o preenchimento.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Barra o avanço se não tiver 11 números
                }



                //  Instanciar a  classe DAO
                DAOPaciente dao = new DAOPaciente();

                //  Chamar o método Inserir passando o que o usuário digitou nas caixas de texto
                // Seguindo a ordem que esta no banco de dados 
                dao.Inserir(
                    textBox1.Text,
                    maskedTextBox1.Text,
                    maskedTextBox2.Text,
                    textBox2.Text,
                   textBox3.Text
                );

                // 3. Limpar os campos após cadastrar
                LimparCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao salvar no formulário: {erro.Message}");
            }



        }

            public void LimparCampos()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus(); // Coloca o cursor de volta no nome







        } // fim do botao cadastrar 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}






 
    

