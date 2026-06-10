using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaTerapiaViverBem
{
    internal class DAOAgendamento
    {

        private DAOConexaoBD daoConexao = new DAOConexaoBD();
        public MySqlConnection conexao;
        public string dados;
        public string comando;


        public int[] idAgendamento;
        public string[] dataSessao;
        public string[] horarioSessao;
        public string[] ValorSessao;
        public string[] statusSessao;
        public int[] idPaciente;
        public int[] idTerapeuta;

        public int i;
        public int contar;

        public DAOAgendamento()
        {
            try
            {
                this.conexao = daoConexao.GetConnection();
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao conectar: {erro.Message}");

            }
        }

        // metodo inserir tabela Agendamento 

        public void Inserir(string data, string hora, string valor, string status, int idPaciente, int idTerapeuta)
        {
            try
            {

                DateTime dataSessao = Convert.ToDateTime(data);
                string dataFormatada = dataSessao.ToString("yyyy-MM-dd");


                string valorFormatado = valor.Replace(",", ".");


                this.dados = $"('{dataFormatada}', '{hora}', '{valorFormatado}', '{status}')";

                this.comando = $"INSERT INTO agendamento (dataSessao, horarioSessao, ValorSessao, statusSessao) VALUES {this.dados}";

                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();

                MessageBox.Show($"Sessão agendada com sucesso! \n\n{resultado}");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao agendar sessão: \n\n {erro.Message}");
            }




        }

        public void PreencherVetor()
        {
            // Buscando os dados da tabela agendamento
            string query = "select * from agendamento";

            // Inicializando os vetores com tamanho 100
            this.idAgendamento = new int[100];
            this.dataSessao = new string[100];
            this.horarioSessao = new string[100];
            this.ValorSessao = new string[100];
            this.statusSessao = new string[100];
            this.idPaciente = new int[100];
            this.idTerapeuta = new int[100];

            for (i = 0; i < 100; i++)
            {
                this.idAgendamento[i] = 0;
                this.dataSessao[i] = "";
                this.horarioSessao[i] = "";
                this.ValorSessao[i] = "";
                this.statusSessao[i] = "";
                this.idPaciente[i] = 0;
                this.idTerapeuta[i] = 0;
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            // O laço lê o banco linha por linha e alimenta os vetores globais
            while (leitura.Read())
            {
                this.idAgendamento[i] = Convert.ToInt32(leitura["idAgendamento"]);
                this.dataSessao[i] = leitura["dataSessao"] + "";
                this.horarioSessao[i] = leitura["horarioSessao"] + "";
                this.ValorSessao[i] = leitura["ValorSessao"] + "";
                this.statusSessao[i] = leitura["statusSessao"] + "";

                this.contar++;
            }

            leitura.Close();
        }


        public void AtualizarAgendamento(int idAgendamento, string dataSessao, string horarioSessao, decimal ValorSessao, string statusSessao)
        {
            try
            {


                string query = $"update agendamento set dataSessao = '{dataSessao}', horarioSessao = '{horarioSessao}', ValorSessao = {ValorSessao.ToString(System.Globalization.CultureInfo.InvariantCulture)}, statusSessao = '{statusSessao}' where idAgendamento = {idAgendamento}";

                MySqlCommand comandoAtualizar = new MySqlCommand(query, this.conexao);


                comandoAtualizar.ExecuteNonQuery();

                MessageBox.Show("Agendamento atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao atualizar agendamento : {erro.Message}");
            }
        }

        public void ExcluirAgendamento(int idAgendamento)
        {
            try
            {
                // Query SQL para deletar a sessão baseada no código 
                string query = $"delete from agendamento where idAgendamento = {idAgendamento}";

                MySqlCommand comandoExcluir = new MySqlCommand(query, this.conexao);

                comandoExcluir.ExecuteNonQuery();

                MessageBox.Show("Agendamento excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir agendamento {erro.Message}");
            }


        }



    }
}