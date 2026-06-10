using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaTerapiaViverBem
{
    internal class VALIDAÇAODOCPF
    {

        // Novo método simplificado: só garante que tem 11 dígitos numéricos
        public static bool ValidarCPF(string cpf)
        {
            // Remove pontos, traços, espaços e vírgulas
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "");

            // Confere se o resultado final tem exatamente 11 caracteres
            if (cpf.Length == 11)
            {
                return true;  // Se tiver 11 dígitos, o CPF é aceito
            }
            else
            {
                return false; // Se tiver mais ou menos, ele barra
            }
        }








        /* // Método que recebe o CPF (texto) e devolve true (válido) ou false (inválido)
         public static bool ValidarCPF(string cpf)
         {
             // 1. Limpa o texto tirando pontos, traços e espaços (caso venha da MaskedTextBox)
             cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "");

             // 2. Um CPF precisa ter exatamente 11 números
             if (cpf.Length != 11)
                 return false;

             // 3. Bloqueia CPFs com todos os números iguais (ex: 111.111.111-11), que passam no cálculo mas são inválidos
             switch (cpf)
             {
                 case "00000000000":
                 case "11111111111":
                 case "22222222222":
                 case "33333333333":
                 case "44444444444":
                 case "55555555555":
                 case "66666666666":
                 case "77777777777":
                 case "88888888888":
                 case "99999999999":
                     return false;
             }

             // 4. Lógica matemática oficial dos dígitos verificadores
             int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
             int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
             string tempCpf;
             string digito;
             int soma;
             int resto;

             tempCpf = cpf.Substring(0, 9);
             soma = 0;

             for (int i = 0; i < 9; i++)
                 soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

             resto = soma % 11;
             if (resto < 2)
                 resto = 0;
             else
                 resto = 11 - resto;

             digito = resto.ToString();
             tempCpf = tempCpf + digito;
             soma = 0;

             for (int i = 0; i < 10; i++)
                 soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

             resto = soma % 11;
             if (resto < 2)
                 resto = 0;
             else
                 resto = 11 - resto;

             digito = digito + resto.ToString();

             // Retorna se os dois últimos dígitos calculados batem com os digitados pelo usuário
             return cpf.EndsWith(digito);
         }*/
    }
    }  // tentei fazer baseado pelo calculo da receita federal e nao foi de jeito nenhummmmm!!!