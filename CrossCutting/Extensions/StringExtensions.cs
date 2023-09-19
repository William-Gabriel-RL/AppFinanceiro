using System.Text.RegularExpressions;

namespace CrossCutting.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extract the numbers of a string
        /// </summary>
        /// <param name="texto">Numbers,as string, with special symbols or letters</param>
        /// <returns>Only the numbers, without letters or special chars</returns>
        public static string ExtractNumbers(this string text)
        {
            return Regex.Replace(text, @"[^\d]", "");
        }

        public static bool IsValidCPF(this string text)
        {
            var cpf = new string(text.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int primeiroDigito = 11 - (soma % 11);
            if (primeiroDigito >= 10)
                primeiroDigito = 0;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            int segundoDigito = 11 - (soma % 11);
            if (segundoDigito >= 10)
                segundoDigito = 0;

            return cpf.EndsWith(primeiroDigito.ToString() + segundoDigito.ToString());
        }

        public static bool IsValidCNPJ(this string text)
        {
            var CNPJ = new string(text.Where(char.IsDigit).ToArray());

            if (CNPJ.Length != 14)
                return false;

            string ftmt = "6543298765432";

            int[] digitos = new int[14];
            int[] soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            int[] resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;

            bool[] CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;


            for (int nrDig = 0; nrDig < 14; nrDig++)
            {
                digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));

                if (nrDig <= 11)
                    soma[0] += digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1));

                if (nrDig <= 12)
                    soma[1] += digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1));
            }

            for (int nrDig = 0; nrDig < 2; nrDig++)
            {
                resultado[nrDig] = (soma[nrDig] % 11);

                if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);

                else
                    CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
            }
            return CNPJOk[0] && CNPJOk[1];

        }
    }
}
