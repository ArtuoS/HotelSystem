using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class Itens_ConsumidosBLL : BaseValidator<Itens_Consumidos>
    {
        Itens_ConsumidosDAL itens_ConsumidosDAL = new Itens_ConsumidosDAL();
        public QueryResponse<Itens_Consumidos> GetItensConsumidosByCliente(int id)
        {
            QueryResponse<Itens_Consumidos> response = itens_ConsumidosDAL.GetItensConsumidosByCliente(id);
            return response;
        }
    }
}
