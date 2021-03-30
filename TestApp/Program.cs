using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valcom;
using Valcom.Entity;
using Valcom.Enums;

namespace TestApp
{
    class Program
    {

        static void Main(string[] args)
        {

            // Busca no Banco:
            UserDTO user = null; // -> Pode declarar null, o ValcomEntity cria a instância caso encontre resultados no banco.
            string query = "SELECT * FROM [sdoc].[Users] WHERE UserID = @ID";
            entity.AddParameter("ID", "40");
            entity.Read(ref user);

            // Serializar Objeto:
            string json = ValcomSerializer.Serialize(user);

            // Desseralizar Objeto:
            user = ValcomSerializer.Deserialize<UserDTO>(json);

         
            Console.WriteLine(json);
            Console.ReadKey();
        }


        public class UserDTO
        {
            [ColumnName("UserID")]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string CPF { get; set; }
        }

    }
}
