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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idTerapeuta = Convert.ToInt32(textBox1.Text);

        
                DAOTerapeuta daoTerapeuta = new DAOTerapeuta();
                daoTerapeuta.ExcluirTerapeuta(idTerapeuta);
            }
            catch (FormatException)
            {
                
                MessageBox.Show("Por favor,preencha o campo de código.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro  ao tentar excluir terapeuta: {erro.Message}");
            }

        }// fim do botao excluir  terapeuta 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
