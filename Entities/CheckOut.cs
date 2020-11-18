using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CheckOut
    {
        public int ID { get; set; }
        public int QuartoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataSaida { get; set; }
        public double Valor { get; set; }
        public int CheckInID { get; set; }
    }
}
