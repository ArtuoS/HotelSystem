using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class CheckOutBLL : BaseValidator<CheckOut>
    {
        CheckOutDAL checkOutDAL = new CheckOutDAL();
        /*
        public Response Insert(CheckOut checkOut)
        {
            Response response = Validate(checkOut);
            if(response.Success)
            {
                return checkOutDAL.Insert(checkOut);
            }
            return response;
        }
        */
        public Response Insert(CheckOut checkOut)
        {
            Response response = Validate(checkOut);
            if (response.Success)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    Itens_ConsumidosBLL itensConsumidosBLL = new Itens_ConsumidosBLL();
                    QueryResponse<Itens_Consumidos> responseItens = itensConsumidosBLL.GetItensConsumidosByCliente(checkOut.ClienteID);
                    if (responseItens.Success)
                    {
                        checkOut.Valor = responseItens.Data.Sum(c => checkOut.Valor + c.ValorTotal);
                    }
                    else
                    {
                        return responseItens;
                    }
                    scope.Complete();
                }
                return checkOutDAL.Insert(checkOut);
            }
            return response;
        }

        public QueryResponse<CheckOut> GetAll()
        {
            QueryResponse<CheckOut> response = checkOutDAL.GetAll();
            return response;
        }

        public override Response Validate(CheckOut checkOut)
        {
            return base.Validate(checkOut);
        }
    }
}
