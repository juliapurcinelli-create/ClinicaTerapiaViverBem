using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaTerapiaViverBem
{
    internal class DAOConexaoBD
    {
        const string servidor = "localhost";
        const string bancodados = "clinicaviverbem";
        const string usuario = "root";
        const string senha = "V1d30C@stM@oD4ta";

        private string connStr = $"server={servidor};database={bancodados};user={usuario};password={senha}";


        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        public bool TestarConexao()
        {
            using (MySqlConnection conn = GetConnection())

                try
                {
                    conn.Open();
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    return false;
                }
        }
    }

}
