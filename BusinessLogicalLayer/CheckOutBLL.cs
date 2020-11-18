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
        public Response Insert(CheckOut checkOut)
        {
            Response response = Validate(checkOut);
            if (response.Success)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    CheckInBLL checkInBLL = new CheckInBLL();
                    SingleResponse<CheckIn> responseCheckIn = checkInBLL.GetById(checkOut.CheckInID);
                    if (responseCheckIn.Success)
                    {
                        QuartoBLL quartoBLL = new QuartoBLL();
                        SingleResponse<Quarto> responseQuarto = quartoBLL.GetById(checkOut.QuartoID);
                        if (responseQuarto.Success)
                        {
                            Itens_ConsumidosBLL itensConsumidosBLL = new Itens_ConsumidosBLL();
                            QueryResponse<Itens_Consumidos> responseItens = itensConsumidosBLL.GetItensConsumidosByCliente(checkOut.ClienteID);

                            checkOut.Valor = responseItens.Data.Sum(c => checkOut.Valor + c.ValorTotal);
                            checkOut.Valor += responseQuarto.Data.ValorNoite * Extensions.StringExtensions.SubtraiDatas(responseCheckIn.Data.DataEntrada, checkOut.DataSaida);
                        }
                    }
                    scope.Complete();
                    return checkOutDAL.Insert(checkOut);
                }
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
            //verifica se datasaidaprevista == datasaida
            //true = ok, false = multa
            return base.Validate(checkOut);
        }
    }
}
