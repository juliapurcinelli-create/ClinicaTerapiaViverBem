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
    public partial class Form5 : Form
    {
        public Form5()
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
            menu.Show();
        }// fim do botao voltar 

        private void button1_Click(object sender, EventArgs e)
        {
            Form21 menu = new Form21();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form22 menu = new Form22();
            menu.Show();

        }// fim do botao excluir sessao 

        private void button3_Click(object sender, EventArgs e)
        {
            Form23 menu = new Form23();
            menu.Show();

        }// fim do botao excluir terapeuta 

        private void button4_Click(object sender, EventArgs e)
        {
            Form24 menu = new Form24();
            menu.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form25 menu = new Form25();
            menu.Show();

        }// fim do botao exluir pagamento 
    }
}
