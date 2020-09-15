using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valcom
{
    public struct DateAndTime
    {

        /// <summary>
        /// Checar se a string é do tipo data.
        /// </summary>
        /// <param name="value">String da data.</param>
        /// <returns>True = Sim / False = Não</returns>
        public static bool Check(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                try { DateTime.Parse(value); return true; } catch { return false; }
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Converter string para DateTime.
        /// </summary>
        /// <param name="value">String da data.</param>
        /// <returns>DateTime</returns>
        public static DateTime Parse(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                if (!Check(value)) { throw new Exception("Parâmetro inválido."); }
                DateTime date = DateTime.Parse(value);
                return date;
            }
            catch (Exception Ex) { throw Ex; }
        }


        #region InWord

        /// <summary>
        /// Obter a data como se lê. [c/ parse]
        /// </summary>
        /// <param name="value">String da data.</param>
        /// <param name="type">Tipo de leitura.</param>
        /// <returns>Texto da data como se lê.</returns>
        public static string InWord(string value, InWordDateType type = InWordDateType.Complete)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                if (!Check(value)) { throw new Exception("Parâmetro inválido."); }
                DateTime date = Parse(value);
                string inWord = InWord(date, type);
                return inWord;
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Obter a data como se lê.
        /// </summary>
        /// <param name="value">Datetime com a data para ler.</param>
        /// <param name="type">Tipo de leitura.</param>
        /// <returns>Texto da data como se lê.</returns>
        public static string InWord(DateTime value, InWordDateType type = InWordDateType.Complete)
        {
            try
            {
                string day = value.Day.ToString();
                string month = MonthName(value.Month);
                string year = value.Year.ToString();
                string dateWord = "";
                switch (type)
                {
                    case InWordDateType.Complete: dateWord = string.Concat(day, " de ", month, " de ", year); break;
                    case InWordDateType.DayAndMonth: dateWord = string.Concat(day, " de ", month); break;
                    case InWordDateType.MonthAndYear: dateWord = string.Concat(month, " de ", year); break;
                }
                return dateWord;
            }
            catch (Exception Ex) { throw Ex; }
        }

        public enum InWordDateType
        {
            Complete = 1,
            DayAndMonth = 2,
            MonthAndYear
        }

        #endregion


        #region MonthName

        /// <summary>
        /// Obter nome do mês. [c/ parse]
        /// </summary>
        /// <param name="value">String com a data</param>
        /// <returns>Nome do mês</returns>
        public static string MonthName(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                if (!Check(value)) { throw new Exception("Parâmetro inválido."); }
                DateTime date = Parse(value);
                string month = MonthName(date);
                return month;
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void MonthName(string value, ref string month)
        {
            month = MonthName(value);
        }

        /// <summary>
        /// Obter nome do mês.
        /// </summary>
        /// <param name="value">DateTime com a data</param>
        /// <returns>Nome do mês</returns>
        public static string MonthName(DateTime value)
        {
            try
            {
                string name = MonthName(value.Month);
                return name;
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Obter nome do mês.
        /// </summary>
        /// <param name="value">DateTime com a data</param>
        /// <returns>Nome do mês</returns>
        public static void MonthName(DateTime value, ref string month)
        {
            month = MonthName(value);
        }

        /// <summary>
        /// Obter nome do mês.
        /// </summary>
        /// <param name="value">Número de mês para obter nome (1 a 12)</param>
        /// <returns>Nome do mês</returns>
        public static string MonthName(int value)
        {
            try
            {
                if (value == 0 || value > 12) { throw new Exception("Mês inválido."); }
                string[] months = { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };
                string name = months[value - 1];
                return name;
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Obter nome do mês.
        /// </summary>
        /// <param name="value">Número de mês para obter nome (1 a 12)</param>
        /// <returns>Nome do mês</returns>
        public static void MonthName(int value, ref string month)
        {
            month = MonthName(value);
        }

        #endregion


        #region DayOfWeek

        /// <summary>
        /// Obter nome do dia  da semana. [c/ parse]
        /// </summary>
        /// <param name="value">String com a data.</param>
        /// <returns>Retornar dia da semana.</returns>
        public static string DayOfWeek(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                if (!Check(value)) { throw new Exception("Parâmetro inválido."); }
                DateTime date = Parse(value);
                string nameOfDay = DayOfWeek(date);
                return nameOfDay;
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void DayOfWeek(string value, ref string nameOfDay)
        {
            nameOfDay = DayOfWeek(value);
        }




        /// <summary>
        /// Obter nome do dia  da semana.
        /// </summary>
        /// <param name="value">DateTime com a data.</param>
        /// <returns>Retornar dia da semana.</returns>
        public static string DayOfWeek(DateTime value)
        {
            try
            {
                string[] days = { "domingo", "segunda", "terça", "quarta", "quinta", "sexta", "sábado" };
                string name = days[(int)value.DayOfWeek];
                return name;
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void DayOfWeek(DateTime value, ref string nameOfDay)
        {
            nameOfDay = DayOfWeek(value);
        }
        #endregion


    }
}
