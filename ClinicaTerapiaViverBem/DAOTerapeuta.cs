using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaTerapiaViverBem
{
    internal class DAOTerapeuta
    {

        private DAOConexaoBD daoConexao = new DAOConexaoBD();

        public MySqlConnection conexao;
        public string dados;
        public string comando;

        public int[] idTerapeuta; // vetores para armazenar os dados dos terapeutas 
        public string[] nome;
        public string[] abordagemClinica;
        public string[] crp;
        public string[] telefone;
        public string[] email;

        public int i;
        public int contar;
        public string msg;


        public DAOTerapeuta()
        {
            try
            {
                // Conectando através da classe conexaoBD
                this.conexao = daoConexao.GetConnection();
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao conectar via DAOConexaoBD: {erro.Message}");
            }
        }


        public void Inserir(string nome, string abordagemClinica, string crp, string telefone, string email)

        {
            try
            {
                // Estrutura dos valores (Omitindo o código terapeuta que é auto_increment)
                this.dados = $"('{nome}','{abordagemClinica}','{crp}','{telefone}','{email}')";

                // Montar a Query SQL completa batendo com as colunas do seu banco
                this.comando = $"Insert into terapeuta(nome, abordagemClinica, CRP, telefone, email) values{this.dados}";

                // Preparar o executor do comando
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);

                // Mandar para o MySQL executar de verdade
                string resultado = "" + sql.ExecuteNonQuery();

                // Mostrar o aviso na tela 
                MessageBox.Show($"Terapeuta cadastrado com sucesso! \n\n{resultado}");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado ao cadastrar terapeuta \n\n {erro.Message}");
            }
        }

        // metodo para preencher os vetores 
        public void PreencherVetor()
        {
            string query = "select * from terapeuta";

            // Instanciar os vetores com tamanho 100 
            this.idTerapeuta = new int[100];
            this.nome = new string[100];
            this.abordagemClinica = new string[100];
            this.crp = new string[100];
            this.telefone = new string[100];
            this.email = new string[100];


            for (i = 0; i < 100; i++)
            {
                this.idTerapeuta[i] = 0;
                this.nome[i] = "";
                this.abordagemClinica[i] = "";
                this.crp[i] = "";
                this.telefone[i] = "";
                this.email[i] = "";
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;
            while (leitura.Read())
            {
                this.idTerapeuta[i] = Convert.ToInt32(leitura["idTerapeuta"]);
                this.nome[i] = leitura["nome"] + "";
                this.abordagemClinica[i] = leitura["abordagemClinica"] + "";
                this.crp[i] = leitura["CRP"] + "";
                this.telefone[i] = leitura["telefone"] + "";
                this.email[i] = leitura["email"] + "";
                i++;
                this.contar++;
            }


            leitura.Close();

        }



        public void AtualizarTerapeuta(int idTerapeuta, string nome, string abordagemClinica, string CRP, string telefone, string email)
        {
            try
            {

                string query = $"update terapeuta set nome = '{nome}', abordagemClinica = '{abordagemClinica}', CRP = '{CRP}', telefone = '{telefone}', email = '{email}' where idTerapeuta = {idTerapeuta}";

                MySqlCommand comandoAtualizar = new MySqlCommand(query, this.conexao);


                comandoAtualizar.ExecuteNonQuery();

                MessageBox.Show("Cadastro do terapeuta atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao atualizar terapeuta na DAOTerapeuta: {erro.Message}");
            }
        }


        public void ExcluirTerapeuta(int idTerapeuta)
        {
            try
            {
                
                string query = $"delete from terapeuta where idTerapeuta = {idTerapeuta}";

                MySqlCommand comandoExcluir = new MySqlCommand(query, this.conexao);

        
                comandoExcluir.ExecuteNonQuery();

                MessageBox.Show("Terapeuta excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir terapeuta : {erro.Message}");
            }
        }
    }
}
    
