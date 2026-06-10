using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaTerapiaViverBem
{
    internal class DAOFinanceiro
    {

        private DAOConexaoBD daoConexao = new DAOConexaoBD();

        public MySqlConnection conexao;
        public string dados;
        public string comando;

        public int[] idFinanceiro;
        public decimal[] valorPago;
        public string[] dataPagamento;
        public string[] formaPagamento;
        public string[] statusPagamento;

        public int i;
        public int contar;

        public DAOFinanceiro()
        {
            try
            {
                // Abre a conexão usando a DAOConexao BD
                this.conexao = daoConexao.GetConnection();
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao conectar via DAOConexaoBD: {erro.Message}");
            }
        }


        public void Inserir(string valorPago, string dataPagamento, string formaPagamento, string statusPagamento)
        {
            try
            {

                string valorFormatado = valorPago.Replace(",", ".");

                // 2. Tratamento da Data: Converte do formato BR (DD/MM/AAAA) para o MySQL (AAAA-MM-DD)
                DateTime dataConvertida = Convert.ToDateTime(dataPagamento);
                string dataFormatadaParaBD = dataConvertida.ToString("yyyy-MM-dd");


                this.dados = $"('{valorFormatado}','{dataFormatadaParaBD}','{formaPagamento}','{statusPagamento}')";


                this.comando = $"Insert into financeiro(valorPago, dataPagamento, formaPagamento, statusPagamento) values{this.dados}";


                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);


                string resultado = "" + sql.ExecuteNonQuery();


                MessageBox.Show($"Registro financeiro cadastrado com sucesso! \n\n{resultado}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira uma data de pagamento válida no formato DD/MM/AAAA.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado ao cadastrar o registro financeiro \n\n {erro.Message}");
            }
        }

        public void PreencherVetor()
        {
            string query = "select * from financeiro";

            // Instanciar os vetores com tamanho 100
            this.idFinanceiro = new int[100];
            this.valorPago = new decimal[100];
            this.dataPagamento = new string[100];
            this.formaPagamento = new string[100];
            this.statusPagamento = new string[100];

            // Preencher os vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.idFinanceiro[i] = 0;
                this.valorPago[i] = 0;
                this.dataPagamento[i] = "";
                this.formaPagamento[i] = "";
                this.statusPagamento[i] = "";
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;
            while (leitura.Read())
            {
                this.idFinanceiro[i] = Convert.ToInt32(leitura["idFinanceiro"]);
                this.valorPago[i] = Convert.ToDecimal(leitura["valorPago"]);
                this.dataPagamento[i] = Convert.ToDateTime(leitura["dataPagamento"]).ToShortDateString();
                this.formaPagamento[i] = leitura["formaPagamento"] + "";
                this.statusPagamento[i] = leitura["statusPagamento"] + "";
                i++;
                this.contar++;
            }

            leitura.Close();
        }



        public void AtualizarFinanceiro(int idFinanceiro, decimal valorPago, string dataPagamento, string formaPagamento, string statusPagamento)
        {
            try
            {

                string query = $"update financeiro set valorPago = {valorPago.ToString(System.Globalization.CultureInfo.InvariantCulture)}, dataPagamento = '{dataPagamento}', formaPagamento = '{formaPagamento}', statusPagamento = '{statusPagamento}' where idFinanceiro = {idFinanceiro}";

                MySqlCommand comandoAtualizar = new MySqlCommand(query, this.conexao);


                comandoAtualizar.ExecuteNonQuery();

                MessageBox.Show("Registro financeiro atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao atualizar financeiro : {erro.Message}");
            }
        }


        public void ExcluirFinanceiro(int idFinanceiro)
        {
            try
            {

                string query = $"delete from financeiro where idFinanceiro = {idFinanceiro}";

                MySqlCommand comandoExcluir = new MySqlCommand(query, this.conexao);


                comandoExcluir.ExecuteNonQuery();

                MessageBox.Show("Registro financeiro excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir financeiro : {erro.Message}");
            }
        }
    }
}


    
