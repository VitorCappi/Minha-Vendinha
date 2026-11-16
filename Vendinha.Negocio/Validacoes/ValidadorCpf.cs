using System.Linq;

namespace Vendinha.Negocio.Validacoes
{
    public static class ValidadorCpf
    {
        public static string SomenteDigitos(string cpf)
        {
            if (cpf == null)
            {
                return string.Empty;
            }

            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        public static bool EhValido(string cpf)
        {
            string cpfSomenteDigitos = SomenteDigitos(cpf);

            if (cpfSomenteDigitos.Length != 11)
            {
                return false;
            }

            if (cpfSomenteDigitos.Distinct().Count() == 1)
            {
                return false;
            }

            int primeiroDigito = CalcularDigito(cpfSomenteDigitos, 9);
            int segundoDigito = CalcularDigito(cpfSomenteDigitos, 10);

            return cpfSomenteDigitos[9] - '0' == primeiroDigito
                && cpfSomenteDigitos[10] - '0' == segundoDigito;
        }

        private static int CalcularDigito(string cpf, int posicao)
        {
            int soma = 0;
            int peso = posicao + 1;

            for (int indice = 0; indice < posicao; indice++)
            {
                soma += (cpf[indice] - '0') * peso;
                peso--;
            }

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
