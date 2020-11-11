using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CheckIn_Cliente
    {
        public int ID { get; set; }
        public int QuartoID { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaidaPrevista { get; set; }

    }
}
