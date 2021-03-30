using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Valcom
{
    /// <summary>
    /// Serializador e Desseralizador de JSONs do Valcom.
    /// </summary>
    public struct ValcomSerializer
    {
        #region Serialize

        /// <summary>
        /// Serializar objeto (Converter objeto para JSON)
        /// </summary>
        /// <param name="value">Objeto</param>
        /// <returns>JSON em string.</returns>
        public static string Serialize(object value)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            JSS.MaxJsonLength = int.MaxValue;
            string json = JSS.Serialize(value);
            return json;
        }

        /// <summary>
        /// Serializar objeto (Converter objeto para JSON)
        /// </summary>
        /// <param name="value">Objeto</param>
        /// <param name="json">String para o retorno do JSON.</param>
        public static void Serialize(object value, ref string json)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            JSS.MaxJsonLength = int.MaxValue;
            json = JSS.Serialize(value);
        }

        #endregion

        #region Deserialize

        /// <summary>
        /// Desserializar JSON (Converter JSON para Objeto)
        /// </summary>
        /// <param name="value">JSON em String.</param>

        public static T Deserialize<T>(string value)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            JSS.MaxJsonLength = int.MaxValue;
            object obj = JSS.Deserialize<T>(value);
            return (T)obj;
        }

        /// <summary>
        /// Desserializar JSON (Converter JSON para Objeto)
        /// </summary>
        /// <param name="value">JSON em String.</param>
        /// <param name="obj">JSON em String.</param>
        public static void Deserialize<T>(string value, ref T obj)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            JSS.MaxJsonLength = int.MaxValue;
            obj = JSS.Deserialize<T>(value);
        }

        #endregion
    }
}
