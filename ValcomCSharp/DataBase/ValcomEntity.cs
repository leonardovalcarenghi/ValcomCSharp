using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Valcom.Entity;

namespace Valcom
{
    public class ValcomEntity
    {
        /// <summary>
        /// String de Conexão do Banco
        /// </summary>
        private string ConnectionString { get; set; }

        /// <summary>
        /// Texto de Comando
        /// </summary>
        private string CommandText { get; set; }

        /// <summary>
        /// Tipo de Comando
        /// </summary>
        private System.Data.CommandType CommandType { get; set; }

        /// <summary>
        /// Conexão SQL
        /// </summary>
        private SqlConnection ConnectionSQL { get; set; }

        /// <summary>
        /// Comando SQL
        /// </summary>
        private SqlCommand CommandSQL { get; set; }

        /// <summary>
        /// Conexão SQL
        /// </summary>
        /// <param name="connectionString">String de conexão com o banco.</param>
        /// <param name="commandText">Comando SQL</param>
        public ValcomEntity(string connectionString, string commandText, System.Data.CommandType type = System.Data.CommandType.Text)
        {
            // Setar propriedades:
            ConnectionString = connectionString;
            CommandText = commandText;
            CommandType = type;

            try
            {
                // Abrir Coenxão:
                ConnectionSQL = new SqlConnection(ConnectionString);
                CommandSQL = new SqlCommand(CommandText, ConnectionSQL);
                CommandSQL.CommandType = CommandType;
                ConnectionSQL.Open();
            }
            catch (SqlException sqlEx) { throw sqlEx; }
        }

        /// <summary>
        /// Fechar conexão.
        /// </summary>
        public void Close()
        {
            if (ConnectionSQL.State == System.Data.ConnectionState.Open) { ConnectionSQL.Close(); }
        }

        /// <summary>
        /// Adicionar parâmetro na conexão. 
        /// </summary>
        /// <param name="name">Nome do parâmetro (não é obrigatório incluir o '@')</param>
        /// <param name="value">Conteúdo</param>
        public void AddParameter(string name, object value)
        {
            name = name.Replace("@", ""); // limpar todos os possiveis @ adicionais q o dev possa ter adicionado.
            name = (name[0].ToString() == "@" ? name : "@" + name);
            value = (value == null ? DBNull.Value : value);
            SqlParameter parameter = new SqlParameter(name, value);
            CommandSQL.Parameters.Add(parameter);
        }

        /// <summary>
        /// Adicionar parâmetro(s) na conexão.
        /// </summary>
        /// <param name="obj">Objeto de parâmetro com os seus respectivos nomes e valores.</param>
        public void AddParameter(object obj)
        {
            var keys = obj.GetType().GetProperties();
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                var keyName = keys[i].Name;
                var propertyInfo = obj.GetType().GetProperty(keyName);
                var value = propertyInfo.GetValue(obj, null);
                AddParameter(keyName, value);
            }
        }

        /// <summary>
        /// Remover parâmetro.
        /// </summary>
        /// <param name="name">Nome do parâmetro</param>
        public void RemoveParameter(string name) => CommandSQL.Parameters.Remove(name);

        /// <summary>
        /// Executar comando.
        /// </summary>
        /// <returns>Resposta do banco de dados.</returns>
        public object Execute(bool closeConnection = true)
        {
            object db = CommandSQL.ExecuteScalar();
            if (ConnectionSQL.State == System.Data.ConnectionState.Open) { if (closeConnection) { ConnectionSQL.Close(); } }
            return db;
        }


        public T Read<T>(T obj, bool closeConnection = true)
        {
            try
            {
                SqlDataReader readDataBase = CommandSQL.ExecuteReader();
                while (readDataBase.Read())
                {
                    if (obj == null) { obj = Activator.CreateInstance<T>(); }

                    var keys = obj.GetType().GetProperties();
                    for (int i = 0; i < keys.Length; i++)
                    {
                        PropertyInfo key = keys[i];
                        string keyName = key.Name;
                        PropertyInfo prop = obj.GetType().GetProperty(keyName);
                        Type propType = key.PropertyType;

                        ColumnNameAttribute attr = key.GetCustomAttribute<ColumnNameAttribute>();
                        if (attr != null) { keyName = attr.ColumnName; }
                        var db = readDataBase[keyName].ToString();
                        object value = null;

                        // Números:
                        if (propType == typeof(int)) { value = Convert.ToInt32(db); }
                        if (propType == typeof(decimal)) { value = decimal.Parse(db); }
                        if (propType == typeof(double)) { value = double.Parse(db); }
                        if (propType == typeof(float)) { value = float.Parse(db); }
                        if (propType == typeof(long)) { value = long.Parse(db); }

                        // Texto:
                        if (propType == typeof(char)) { value = char.Parse(db); }
                        if (propType == typeof(string)) { value = db.ToString(); }

                        // Data:
                        if (propType == typeof(DateTime)) { value = DateTime.Parse(db); }

                        // Boleano:
                        if (propType == typeof(bool)) { value = bool.Parse(db); }


                        // Enum:
                        if (propType == typeof(Enum)) { value = null; }

                        /*to do: fazer validaão se o dado consegue fazer o pase para o tipo escolhido*/

                        prop.SetValue(obj, value, null);

                    }
                }
                return obj;
            }

            catch (SqlException Ex) { throw Ex; }
            catch (Exception Ex) { throw Ex; }
            finally { if (ConnectionSQL.State == System.Data.ConnectionState.Open) { if (closeConnection) { ConnectionSQL.Close(); } } }
        }

        /// <summary>
        /// Leitura
        /// </summary>
        public void Read<T>(ref T obj, bool closeConnection = true)
        {
            obj = Read<T>(obj, closeConnection);
        }



    }

}
