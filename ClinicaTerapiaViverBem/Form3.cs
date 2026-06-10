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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
        }// fim do botao voltar 

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 telaMenu = new Form11();     
            telaMenu.Show();    
        }// fim do botao paciente 

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 telaMenu = new Form12();
            telaMenu.Show();


        } // fim do botao sessao 

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 telaMenu= new Form13();
            telaMenu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form14 telaMenu= new Form14();
            telaMenu.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form15 telaMenu= new Form15();
            telaMenu.Show();
        }
    }
}
