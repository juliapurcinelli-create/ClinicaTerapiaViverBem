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
    public partial class Form14 : Form
    {
        DAOProntuario dao;
        public Form14()
        {
            InitializeComponent();

            this.dao = new DAOProntuario();

            ChamarMetodo(retornarData());
        } // fim do cosntrutor 

        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); //Configuro a estrutura
            NomeColunas(datagrid);        //Configuro os nomes
            AdicionarDados(datagrid);     //Adiciono os dados da DAO
        }//fim do método

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Nº Prontuário";
            dataGrid.Columns[1].Name = "Descrição / Histórico";
            dataGrid.Columns[2].Name = "Data do Registro";
            dataGrid.Columns[3].Name = "ID Paciente";
        }//fim do método

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.ColumnCount = 4;
        }// fim do configurar

        public void AdicionarDados(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            this.dao.PreencherVetor();

            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.idProntuario[i],
                    this.dao.evolucaoPaciente[i],
                    this.dao.anotacoesClinicas[i]
                    
                );
            }//fim do for
        }//fim do adicionarDados

        public DataGridView retornarData()
        {
            return dataGridView1;
        }











        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ChamarMetodo(retornarData());
                return;
            }

            try
            {
                int idProcurado = Convert.ToInt32(textBox1.Text);
                bool encontrado = false;

                DataGridView tabela = retornarData();
                tabela.Rows.Clear(); // Limpa a tabela para mostrar o resultado

                this.dao.PreencherVetor();

                // Varre o vetor buscando o ID do prontuário digitado
                for (int i = 0; i < this.dao.contar; i++)
                {
                    if (this.dao.idProntuario[i] == idProcurado)
                    {
                        tabela.Rows.Add(
                            this.dao.idProntuario[i],
                            this.dao.evolucaoPaciente[i],
                            this.dao.anotacoesClinicas[i]
                           
                        );
                        encontrado = true;
                        break; // Como o ID do prontuário é único, pode parar o laço
                    }
                }//fim do for

                if (!encontrado)
                {
                    MessageBox.Show("Prontuário não encontrado!");
                    ChamarMetodo(retornarData()); // Se não achar nenhum, lista tudo de novo
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira um código numérico válido para pesquisar.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao filtrar dados: {erro.Message}");
            }
        }


    }// fim do botao consultar prontuario
    }

