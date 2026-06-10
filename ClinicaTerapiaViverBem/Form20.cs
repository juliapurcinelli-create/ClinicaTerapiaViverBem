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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idFinanceiro = Convert.ToInt32(textBox1.Text);

                decimal valorPago = Convert.ToDecimal(textBox4.Text);

                string dataPagamento = maskedTextBox1.Text.Split('/')[2] + "-" + maskedTextBox1.Text.Split('/')[1] + "-" + maskedTextBox1.Text.Split('/')[0]; // Formato esperado pelo MySQL: AAAA-MM-DD
                string formaPagamento = textBox2.Text;
                string statusPagamento = textBox3.Text;

               
                DAOFinanceiro daoFinanceiro = new DAOFinanceiro();
                daoFinanceiro.AtualizarFinanceiro(idFinanceiro, valorPago, dataPagamento, formaPagamento, statusPagamento);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao tentar atualizar financeiro: {erro.Message}");
            }



        }// fim do botao atualizar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
