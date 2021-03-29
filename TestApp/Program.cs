using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valcom.DataBase;

namespace TestApp
{
    class Program
    {

     

        static void Main(string[] args)
        {
            UserDTO user = null;
            string query = "SELECT * FROM [sdoc].[Users] WHERE CPF = @CPF";
            Connection connection = new Connection(ConnectionString, query);
            connection.AddParameter("CPF", "03659993000");
            connection.Read(ref user, true);

            string json = Valcom.JSON.Serialize(user);
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
