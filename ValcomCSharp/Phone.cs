using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valcom
{
    public class Phone
    {

        public static string Mask(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static string RemoveMask(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Nenhum parâmetro fornecido."); }
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

    }
}
