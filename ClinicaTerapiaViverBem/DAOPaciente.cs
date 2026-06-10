using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaTerapiaViverBem
{
    internal class DAOPaciente
    {
        private DAOConexaoBD daoConexao = new DAOConexaoBD();

        public MySqlConnection conexao; // Criando a variável que representa o banco
        public string dados;
        public string comando;

        // vetores para armazenar os dados dos pacientes
        public int[] idPaciente;
        public string[] nome;
        public string[] dataNascimento;
        public string[] cpf;
        public string[] telefone;
        public string[] email;
        public int i;
        public int contar;
        public string msg;


        public DAOPaciente()
        {
            try
            {
                // 2. Usamos o método GetConnection() que você criou na sua DAO de conexão
                this.conexao = daoConexao.GetConnection();
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao conectar via DAOConexaoBD: {erro.Message}");
            }
        }


        // inserir paciente no banco 

        public void Inserir(string nome, string dataNascimento, string cpf, string telefone, string email)
        {
            try
            {

                DateTime dataConvertida = Convert.ToDateTime(dataNascimento); // pega a data e reorganiza no padrao que o MYsql exige 
                string dataFormatadaParaBD = dataConvertida.ToString("yyyy-MM-dd"); // ano - mes- dia 


                string cpfApenasNumeros = cpf.Replace(".", "").Replace("-", "").Replace(",", "");


                this.dados = $"('{nome}','{dataFormatadaParaBD}','{cpfApenasNumeros}','{telefone}','{email}')";


                this.comando = $"Insert into paciente(nome, dataNascimento, CPF, telefone, email) values{this.dados}";

                // Preparar o executor do comando
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);

                // Mandar para o MySQL executar 
                string resultado = "" + sql.ExecuteNonQuery();

                // Mostrar o aviso na tela 
                MessageBox.Show($"Paciente cadastrado com sucesso! \n\n{resultado}");
            }
            catch (FormatException)
            {
                // Caso o usuário digite uma data inválida ou incompleta
                MessageBox.Show("Por favor, insira uma data de nascimento válida no formato DD/MM/AAAA.");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado ao cadastrar paciente \n\n {erro.Message}");
            }
        }

        public void PreencherVetor()
        {
            string query = "select * from paciente"; // Buscando todos os dados da tabela paciente

            // Instanciar os vetores com tamanho 100 
            this.idPaciente = new int[100];
            this.nome = new string[100];
            this.dataNascimento = new string[100];
            this.cpf = new string[100];
            this.telefone = new string[100];
            this.email = new string[100];

            // Preencher os vetores 
            for (i = 0; i < 100; i++)
            {
                this.idPaciente[i] = 0;
                this.nome[i] = "";
                this.dataNascimento[i] = "";
                this.cpf[i] = "";
                this.telefone[i] = "";
                this.email[i] = "";
            }

            // Executar o comando do SQL
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // Leitura do dado no banco
            MySqlDataReader leitura = coletar.ExecuteReader(); // Percorre o banco e traz os dados

            // Zerar o contador
            i = 0;
            this.contar = 0;
            while (leitura.Read())
            {
                this.idPaciente[i] = Convert.ToInt32(leitura["idPaciente"]);
                this.nome[i] = leitura["nome"] + "";
                // Converte a data para exibir apenas o formato curto (DD/MM/AAAA)
                this.dataNascimento[i] = Convert.ToDateTime(leitura["dataNascimento"]).ToShortDateString();
                this.cpf[i] = leitura["CPF"] + "";
                this.telefone[i] = leitura["telefone"] + "";
                this.email[i] = leitura["email"] + "";
                i++;
                this.contar++; // Informar quantos dados tem no banco
            }

            leitura.Close(); // Encerrando o processo de busca
        }

        public void AtualizarPaciente(int idPaciente, string nome, string dataNascimento, long CPF, string telefone, string email)
        {
            try
            {

                string query = $"update paciente set nome = '{nome}', dataNascimento = '{dataNascimento}', CPF = {CPF}, telefone = '{telefone}', email = '{email}' where idPaciente = {idPaciente}";

                MySqlCommand comandoAtualizar = new MySqlCommand(query, this.conexao);


                comandoAtualizar.ExecuteNonQuery();

                MessageBox.Show("Cadastro do paciente atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao atualizar paciente : {erro.Message}");
            }
        }


        public void ExcluirPaciente(int idPaciente)
        {
            try
            {
                // deleta o registro baseado apenas na chave primária
                string query = $"delete from paciente where idPaciente = {idPaciente}";

                MySqlCommand comandoExcluir = new MySqlCommand(query, this.conexao);


                comandoExcluir.ExecuteNonQuery();

                MessageBox.Show("Paciente excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir paciente: {erro.Message}");
            }


        }

    }
}


