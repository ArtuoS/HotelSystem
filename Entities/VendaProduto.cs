using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VendaProduto
    {
        public int ID { get; set; }
        public DateTime DataVenda { get; set; }
        public double Valor { get; set; }
        public int FornecedorID { get; set; }
        public int FuncionarioID { get; set; }
        public List<ItensVenda> Itens { get; set; }
        public VendaProduto()
        {
            this.Itens = new List<ItensVenda>();
        }
    }
}
