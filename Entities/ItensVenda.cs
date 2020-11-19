using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ItensVenda
    {
        public int VendaID { get; set; }
        public int ProdutoID { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int ClienteID { get; set; }
        public bool FoiPago { get; set; }
    }
}
