using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valcom.Entity
{
    /// <summary>
    /// Nome da Coluna para Leitura
    /// </summary>
    public class ColumnNameAttribute : System.Attribute
    {
        public string ColumnName;
        public ColumnNameAttribute(string value) { this.ColumnName = value; }
    }
}
