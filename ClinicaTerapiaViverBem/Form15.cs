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
    public partial class Form15 : Form
    {
        DAOFinanceiro dao;
        public Form15()
        {
            InitializeComponent();

            this.dao = new DAOFinanceiro();

            ChamarMetodo(retornarData());

        }

        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); // Monta a estrutura de colunas
            NomeColunas(datagrid);        // Define os títulos
            AdicionarDados(datagrid);     // Puxa as linhas da DAO
        }//fim do método

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Cód. Pagamento";
            dataGrid.Columns[1].Name = "Valor";
            dataGrid.Columns[2].Name = "Data";
            dataGrid.Columns[3].Name = "Status";
            dataGrid.Columns[4].Name = "ID Agendamento";
        }//fim do método

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.ColumnCount = 5; // 5 colunas criadas
        }//fim do configurar

        public void AdicionarDados(DataGridView dataGrid)
        {
            try
            {
                dataGrid.Rows.Clear();
                this.dao.PreencherVetor(); // Abastece os vetores da memória

                for (int i = 0; i < this.dao.contar; i++)
                {
                    dataGrid.Rows.Add(
                        this.dao.idFinanceiro[i], 
                        this.dao.valorPago[i], 
                        this.dao.dataPagamento[i], 
                        this.dao.formaPagamento[i], 
                        this.dao.statusPagamento[i]
                    );
                }//fim do for
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao listar pagamentos: {erro.Message}");
            }
        }//fim do adicionarDados

        public DataGridView retornarData()
        {
            return dataGridView1; // Retorna a tabela verde padrão do seu design
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }








        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botao sair 

        private void CONSULTAR_Click(object sender, EventArgs e)
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
                tabela.Rows.Clear(); // Limpa para renderizar apenas o filtro do ID

                this.dao.PreencherVetor();

                // Varre os vetores buscando o código digitado
                for (int i = 0; i < this.dao.contar; i++)
                {
                    if (this.dao.idFinanceiro[i] == idProcurado)
                    {
                        tabela.Rows.Add(
                            this.dao.idFinanceiro[i],
                            this.dao.valorPago[i],
                            this.dao.dataPagamento[i],
                            this.dao.formaPagamento[i],
                            this.dao.statusPagamento[i]
                        );
                        encontrado = true;
                        break; // Como o ID é chave primária (único), pode parar o loop
                    }
                }//fim do for

                if (!encontrado)
                {
                    MessageBox.Show("Registro financeiro não encontrado!");
                    ChamarMetodo(retornarData()); // Se não achar nada, recarrega a lista original
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, digite um número de código válido para pesquisar.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao filtrar dados: {erro.Message}");
            }
        }





    }// fim do consultar 
    }

