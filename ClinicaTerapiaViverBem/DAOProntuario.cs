using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaTerapiaViverBem
{
    internal class DAOProntuario
    {

        private DAOConexaoBD daoConexao = new DAOConexaoBD();

        public MySqlConnection conexao;
        public string dados;
        public string comando;


        public int[] idProntuario;
        public string[] evolucaoPaciente;
        public string[] anotacoesClinicas;

        public int i;
        public int contar;
        public string msg;

        public DAOProntuario()
        {
            try
            {
                // Conecxao atraves da classe conexao
                this.conexao = daoConexao.GetConnection();
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao conectar via DAOConexaoBD: {erro.Message}");
            }


        }

        // Método Inserir focado na tabela prontuario
        public void Inserir(string evolucaoPaciente, string anotacoesClinicas)
        {
            try
            {

                this.dados = $"('{evolucaoPaciente}','{anotacoesClinicas}')";


                this.comando = $"Insert into prontuario(evoluçaoPaciente,anotaçoesClinicas) values{this.dados}";


                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);


                string resultado = "" + sql.ExecuteNonQuery();


                MessageBox.Show($"Prontuário cadastrado com sucesso! \n\n{resultado}");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado ao cadastrar o prontuário \n\n {erro.Message}");
            }
        }

        // Método para carregar os dados nos vetores
        public void PreencherVetor()
        {
            string query = "select * from prontuario";

            // Instanciar os vetores com tamanho 100
            this.idProntuario = new int[100];
            this.evolucaoPaciente = new string[100];
            this.anotacoesClinicas = new string[100];

            // Preencher os vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.idProntuario[i] = 0;
                this.evolucaoPaciente[i] = "";
                this.anotacoesClinicas[i] = "";
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;
            while (leitura.Read())
            {
                this.idProntuario[i] = Convert.ToInt32(leitura["idProntuario"]);
                evolucaoPaciente[i] = leitura["evoluçaoPaciente"] + "";
                anotacoesClinicas[i] = leitura["anotaçoesClinicas"] + "";
                i++;
                this.contar++;
            }

            leitura.Close();
        }


        public void AtualizarProntuario(int idProntuario, string evoluçaoPaciente, string anotaçoesClinicas)
        {
            try
            {

                string query = $"update prontuario set evoluçaoPaciente = '{evoluçaoPaciente}', anotaçoesClinicas = '{anotaçoesClinicas}' where idProntuario = {idProntuario}";

                MySqlCommand comandoAtualizar = new MySqlCommand(query, this.conexao);


                comandoAtualizar.ExecuteNonQuery();

                MessageBox.Show("Prontuário atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao atualizar prontuário : {erro.Message}");
            }
        }



        public void ExcluirProntuario(int idProntuario)
        {
            try
            {

                string query = $"delete from prontuario where idProntuario = {idProntuario}";

                MySqlCommand comandoExcluir = new MySqlCommand(query, this.conexao);


                comandoExcluir.ExecuteNonQuery();

                MessageBox.Show("Prontuário excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir prontuário: {erro.Message}");
            }
        }
    }
}
    

