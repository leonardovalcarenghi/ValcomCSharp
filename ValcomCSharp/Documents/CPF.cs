using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valcom.Documents
{
    public class CPF
    {
        /// <summary>
        /// Validar CPF / CNPJ
        /// </summary>
        /// <param name="value">CPF ou CNPJ (com ou sem máscara)</param>
        /// <returns>True = Válido / False = Inválido</returns>
        public static bool Validate(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                value = value.RemoveWhiteSpace();
                RemoveMask(ref value);
                if (value.Length == 11) { return ValidateCPF(value); }
                if (value.Length == 14) { return ValidateCNPJ(value); }
                return false;
            }
            catch (Exception Ex) { throw Ex; }
        }

        #region Validate

        private static bool ValidateCPF(string value)
        {
            try
            {
                if (value.Length != 11) { return false; }
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                tempCpf = value.Substring(0, 9);
                soma = 0;
                for (int i = 0; i < 9; i++) { soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i]; }
                resto = soma % 11;
                if (resto < 2) { resto = 0; } else { resto = 11 - resto; }
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++) { soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i]; }
                resto = soma % 11;
                if (resto < 2) { resto = 0; } else { resto = 11 - resto; }
                digito = digito + resto.ToString();
                return value.EndsWith(digito);
            }
            catch (Exception Ex) { throw Ex; }
        }

        private static bool ValidateCNPJ(string value)
        {
            try
            {
                if (value.Length != 14) { return false; }
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;
                tempCnpj = value.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++) { soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i]; }
                resto = (soma % 11);
                if (resto < 2) { resto = 0; } else { resto = 11 - resto; }
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++) { soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i]; }
                resto = (soma % 11);
                if (resto < 2) { resto = 0; } else { resto = 11 - resto; }
                digito = digito + resto.ToString();
                return value.EndsWith(digito);
            }
            catch (Exception Ex) { throw Ex; }
        }

        #endregion

        #region Mask

        /// <summary>
        /// Atribuir máscara no CPF ou CNPJ.
        /// </summary>
        /// <param name="value">CPF ou  CNPJ</param>
        /// <returns>Retorno do CPF / CNPJ com máscara.</returns>
        public static string Mask(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                if (!Validate(value)) { throw new Exception("Valor não é válido."); }
                value = value.RemoveWhiteSpace();
                value = value.RemoveSpecialCharacters();
                value = value.PadLeft(11, '0');
                string _value = value.Reverse().Substring(0, 11);
                value = _value.Reverse();
                value = value.Substring(0, 3) + "." + value.Substring(3, 3) + "." + value.Substring(6, 3) + "-" + value.Substring(9, 2);
                return value;
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Atribuir máscara no CPF ou CNPJ.
        /// </summary>
        /// <param name="value">Referência da string onde está o CPF / CNPJ</param>
        public static void Mask(ref string value)
        {
            try
            {
                value = Mask(value);
            }
            catch (Exception Ex) { throw Ex; }
        }

        #endregion

        #region RemoveMask

        /// <summary>
        /// Remover máscara do CPF / CNPJ.
        /// </summary>
        /// <param name="value">CPF ou CNPJ</param>
        /// <returns>Retorno somente dos números do CPF/CNPJ</returns>
        public static string RemoveMask(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                value = value.Replace(".", "").Replace("-", "").Replace("/", "");
                return value;
            }
            catch (Exception Ex) { throw Ex; }
        }


        /// <summary>
        /// Remover máscara do CPF / CNPJ.
        /// </summary>
        /// <param name="value">Referencia de onde está o CPF / CNPJ</param>
        public static void RemoveMask(ref string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                value = RemoveMask(value);
            }
            catch (Exception Ex) { throw Ex; }
        }

        #endregion

    }

}
