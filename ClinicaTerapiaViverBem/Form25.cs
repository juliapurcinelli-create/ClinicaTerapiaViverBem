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
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                
                int idFinanceiro = Convert.ToInt32(textBox1.Text);

              
                DAOFinanceiro daoFinanceiro = new DAOFinanceiro();
                daoFinanceiro.ExcluirFinanceiro(idFinanceiro);
            }
            catch (FormatException)
            {
            
                MessageBox.Show("Por favor, preencha o campo do código.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao tentar excluir registro financeiro: {erro.Message}");
            }

        }// fim do botao excluir 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
