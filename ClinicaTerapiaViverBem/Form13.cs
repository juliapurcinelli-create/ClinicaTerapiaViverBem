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
    public partial class Form13 : Form
    {
        DAOTerapeuta dao;
        public Form13()
        {
            InitializeComponent();

            this.dao = new DAOTerapeuta();
            ChamarMetodo(retornarData());



        }

        //Chamar Método
        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); //Configuro a estrutura
            NomeColunas(datagrid);        //Configuro os nomes
            AdicionarDados(datagrid);     //Adiciono os dados puxados da DAO
        }//fim do método

        //Nome Colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Nome do Terapeuta";
            dataGrid.Columns[2].Name = "Especialidade";
            dataGrid.Columns[3].Name = "Telefone";
        }//fim do método

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;

            // 4 colunas para os dados do Terapeuta
            dataGrid.ColumnCount = 4;
        }//fim do configurar

        public void AdicionarDados(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            this.dao.PreencherVetor();

            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.idTerapeuta[i],
                    this.dao.nome[i],
                    this.dao.abordagemClinica[i],
                    this.dao.telefone[i]
                );
            }//fim do for
        }//fim do adicionarDados

        public DataGridView retornarData()
        {
            return dataGridView1;
        }










        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ChamarMetodo(retornarData());
                return;
            }

            try
            {
                string nomeProcurado = textBox1.Text.ToLower();
                bool encontrado = false;

                DataGridView tabela = retornarData();
                tabela.Rows.Clear();

                this.dao.PreencherVetor();

                for (int i = 0; i < this.dao.contar; i++)
                {
                    if (this.dao.nome[i].ToLower().Contains(nomeProcurado))
                    {
                        tabela.Rows.Add(
                            this.dao.idTerapeuta[i],
                            this.dao.nome[i],
                            this.dao.abordagemClinica[i],
                            this.dao.telefone[i]
                        );
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("Nenhum terapeuta encontrado com esse nome!");
                    ChamarMetodo(retornarData());
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro: {erro.Message}");
            }
        }// fim do botao consultar pro nome 

   

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                ChamarMetodo(retornarData()); // Se vazio, mostra todos de volta
                return;
            }

            try
            {
                int idProcurado = Convert.ToInt32(textBox2.Text);
                bool encontrado = false;

                DataGridView tabela = retornarData();
                tabela.Rows.Clear();

                this.dao.PreencherVetor();

                for (int i = 0; i < this.dao.contar; i++)
                {
                    if (this.dao.idTerapeuta[i] == idProcurado)
                    {
                        tabela.Rows.Add(
                            this.dao.idTerapeuta[i],
                            this.dao.nome[i],
                            this.dao.abordagemClinica[i],
                            this.dao.telefone[i]
                        );
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("Terapeuta não encontrado!");
                    ChamarMetodo(retornarData());
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro: {erro.Message}");
            }
        }


    }// fim do botao consultar por codigo 
    }

