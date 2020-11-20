using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LimpezaQuarto
    {
        public int ID { get; set; }
        public int QuartoID { get; set; }
        public int FuncionarioID { get; set; }
        public DateTime DataLimpeza { get; set; }
    }
}
