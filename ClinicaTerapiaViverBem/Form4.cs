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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form20 menu = new Form20();
            menu.Show();
        }// fim do botao financeiro 

        private void Form4_Load(object sender, EventArgs e)
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
            Form16 menu = new Form16();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form17 menu = new Form17();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form18 menu = new Form18();
            menu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form19 menu = new Form19();
            menu.Show();
        }
    }
}
