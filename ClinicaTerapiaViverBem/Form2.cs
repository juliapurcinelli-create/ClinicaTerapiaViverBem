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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show(); // voltar para a tela de menu      
        }// fim do botao voltar 

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 telaMenu = new Form6();
            telaMenu.Show();
        }// fim do botao cadastrar paciente 

        private void button2_Click(object sender, EventArgs e)
        {
           Form7 telaMenu = new Form7();
            telaMenu.Show();
        }// fim do botao sessoes 

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 telaMenu = new Form8();
            telaMenu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 telaMenu = new Form9();
            telaMenu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 telaMenu = new Form10();
            telaMenu.Show();
        } // fim do botao pagamento 
    }
}
