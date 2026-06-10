using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClinicaTerapiaViverBem
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Coleta apenas o código do paciente da caixinha de texto  correspondente
                int idPaciente = Convert.ToInt32(textBox1.Text);

                //  Instancia a DAO e dispara o método de exclusão
                DAOPaciente daoPaciente = new DAOPaciente();
                daoPaciente.ExcluirPaciente(idPaciente);
            }
            catch (FormatException)
            {
                // Se a caixinha do código estiver vazia ao clicar em Excluir
                MessageBox.Show("Por favor, preencha o campo com o código");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao tentar excluir: {erro.Message}");
            }

        }// fim do botao excluir paciente 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
