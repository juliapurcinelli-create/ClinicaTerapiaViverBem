using Google.Protobuf.WellKnownTypes;
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
    public partial class Form11 : Form
    {
        DAOPaciente dao;
        public Form11()
        {

            InitializeComponent();
            this.dao = new DAOPaciente();

            ChamarMetodo(dataGridView1);



        }

        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); // Configuro a estrutura
            NomeColunas(datagrid);        // Configuro os nomes
            AdicionarDados(datagrid);     // Adiciono os dados
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "CPF";
            dataGrid.Columns[3].Name = "Telefone";
            dataGrid.Columns[4].Name = "E-mail";
        }

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;    // Não permito que o usuário adicione linhas manualmente
            dataGrid.AllowUserToDeleteRows = false;  // Não permito deletar direto na tabela
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;


            dataGrid.ColumnCount = 5;
        }

        public void AdicionarDados(DataGridView dataGrid)
        {
            // Limpa as linhas antes de preencher para evitar duplicações
            dataGrid.Rows.Clear();

            // Primeira coisa será: PREENCHER O VETOR
            this.dao.PreencherVetor();

            // Laço FOR varrendo os vetores da DAOPaciente conforme a regra do professor
            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.idPaciente[i],
                    this.dao.nome[i],
                    this.dao.cpf[i],
                    this.dao.telefone[i],
                    this.dao.email[i]
                );
            }


        }

        public DataGridView retornarData()
        {
            return dataGridView1;
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento de clique na tabela caso queira usar futuramente
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Se a caixinha de texto estiver vazia
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ChamarMetodo(retornarData());
                return;
            }

            try
            {
                // Converte o código digitado para número
                int idProcurado = Convert.ToInt32(textBox1.Text);
                bool encontrado = false;

                //  Pega a tabela (dataGridView1) e limpa as linhas para exibir só o resultado
                DataGridView tabela = retornarData();
                tabela.Rows.Clear();

                //  Manda a DAO atualizar os vetores com os dados do banco
                this.dao.PreencherVetor();

                //  Varre os vetores procurando o código 
                for (int i = 0; i < this.dao.contar; i++)
                {
                    if (this.dao.idPaciente[i] == idProcurado)
                    {
                        // Se encontrou o ID, adiciona apenas essa linha na tabela verde
                        tabela.Rows.Add(
                            this.dao.idPaciente[i],
                            this.dao.nome[i],
                            this.dao.cpf[i],
                            this.dao.telefone[i],
                            this.dao.email[i]
                        );
                        encontrado = true;
                        break; // Encontrou o paciente, pode parar o laço FOR
                    }
                }//fim do for

                // 5. Se rodou o vetor inteiro e não achou o número
                if (!encontrado)
                {
                    MessageBox.Show("Paciente não encontrado!");
                    ChamarMetodo(retornarData()); // Mostra todos de volta para não deixar a tabela vazia
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


        }// fim do botao consultar paciente

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                ChamarMetodo(retornarData());
                return;
            }

            try
            {
               
                string nomeProcurado = textBox2.Text.ToLower();
                bool encontrado = false;

               
                DataGridView tabela = retornarData();
                tabela.Rows.Clear();

                
                this.dao.PreencherVetor();

              
                for (int i = 0; i < this.dao.contar; i++)
                {
                    // O .ToLower() e o .Contains() garantem que ache o nome mesmo se digitar só um pedaço
                    if (this.dao.nome[i].ToLower().Contains(nomeProcurado))
                    {
                        tabela.Rows.Add(
                            this.dao.idPaciente[i],
                            this.dao.nome[i],
                            this.dao.cpf[i],
                            this.dao.telefone[i],
                            this.dao.email[i]
                        );
                        encontrado = true; // Achou pelo menos um!
                    }
                }//fim do for

                //  Se percorreu o laço todinho e nao achou nada 
                if (!encontrado)
                {
                    MessageBox.Show("Nenhum paciente com esse nome foi encontrado!");
                    ChamarMetodo(retornarData()); // Recarrega todos os dados de volta 
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao filtrar por nome: {erro.Message}");
            }


        } // fim do botao consultar por nome 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        } // fim do botao sair 
    }   


}
