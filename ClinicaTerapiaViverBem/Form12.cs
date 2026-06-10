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
    public partial class Form12 : Form
    {
        DAOAgendamento dao;
        public Form12()
        {
            InitializeComponent();

            this.dao = new DAOAgendamento();

            ChamarMetodo(retornarData()); // Assim que a tela abre, ela já lista tudo na tabela automaticamente

        }
        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); 
            NomeColunas(datagrid);        
            AdicionarDados(datagrid);     
        }//fim do método

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "ID Agendamento";
            dataGrid.Columns[1].Name = "Data";
            dataGrid.Columns[2].Name = "Horário";
            dataGrid.Columns[3].Name = "Valor";
            dataGrid.Columns[4].Name = "Status";
            dataGrid.Columns[5].Name = "ID Paciente";
            dataGrid.Columns[6].Name = "ID Terapeuta";
        }//fim do método

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.ColumnCount = 7;
        }//fim do configurar

        public void AdicionarDados(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            this.dao.PreencherVetor(); // Puxa do banco agendamento linha por linha

            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.idAgendamento[i],
                    this.dao.dataSessao[i],
                    this.dao.horarioSessao[i],
                    this.dao.ValorSessao[i],
                    this.dao.statusSessao[i],
                    this.dao.idPaciente[i],
                    this.dao.idTerapeuta[i]
                );
            }//fim do for
        }//fim do adicionarDados

        public DataGridView retornarData()
        {
            // Retorna o componente padrão (mude para dataGridView2, etc, se o C# der outro número)
            return dataGridView1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                //  Convertero código digitado para número
                int idProcurado = Convert.ToInt32(textBox1.Text);
                bool encontrado = false;

                //   tabela (dataGridView1) e limpamos as linhas para exibir o filtro
                DataGridView tabela = retornarData();
                tabela.Rows.Clear();

                //   DAO preencher os vetores atualizados com os dados do MySQL
                this.dao.PreencherVetor();

                //  O laço FOR varre os vetores procurando o ID (Exatamente como o seu professor faz)
                for (int i = 0; i < this.dao.contar; i++)
                {
                    if (this.dao.idAgendamento[i] == idProcurado)
                    {
                        // Quando encontra o código, adiciona os dados correspondentes na tabela verde
                        tabela.Rows.Add(
                            this.dao.idAgendamento[i],
                            this.dao.dataSessao[i],
                            this.dao.horarioSessao[i],
                            this.dao.ValorSessao[i],
                            this.dao.statusSessao[i],
                            this.dao.idPaciente[i],
                            this.dao.idTerapeuta[i]
                        );
                        encontrado = true;
                        break; // Achou a sessão procurada, pode parar o laço FOR
                    }
                }//fim do for

                //Se o laço rodou inteiro e não encontrou o número digitado
                if (!encontrado)
                {
                    MessageBox.Show("Sessão não encontrada!");
                    ChamarMetodo(retornarData()); // Recarrega todos para a tabela não ficar totalmente em branco
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira um número de código válido para pesquisar.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao filtrar dados: {erro.Message}");
            }

        } // fim do botao consultar 
    }
}
