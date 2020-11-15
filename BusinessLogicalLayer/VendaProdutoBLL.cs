using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class VendaProdutoBLL : BaseValidator<VendaProduto>
    {
        VendaProdutoDAL vendaProdutoDAL = new VendaProdutoDAL();
        public Response InsertVenda(VendaProduto venda)
        {
            Response response = Validate(venda);
            if (response.Success)
            {
                venda.DataVenda = DateTime.Now;
                venda.Valor = venda.Itens.Sum(w => w.Valor * w.Quantidade);
                using (TransactionScope scope = new TransactionScope())
                {
                    SingleResponse<VendaProduto> responseEntrada = vendaProdutoDAL.InsertVenda(venda);
                    if (responseEntrada.Success)
                    {
                        foreach (ItensVenda item in venda.Itens)
                        {
                            ItensVendaBLL itensVendaBLL = new ItensVendaBLL();
                            SingleResponse<VendaProduto> responseEntradaID = vendaProdutoDAL.GetVendaID(venda);
                            item.VendaID = responseEntradaID.Data.ID;
                            Response responseItensEntrada = itensVendaBLL.InsertItem(item);
                            if (responseItensEntrada.Success)
                            {
                                vendaProdutoDAL.AtualizaEstoque(item.ProdutoID, item.Quantidade);
                            } else
                            {
                                return responseItensEntrada;
                            }
                        }
                    }
                    scope.Complete();
                }
            }
            return response;
        }

        public SingleResponse<VendaProduto> GetVendaID(VendaProduto venda)
        {
            SingleResponse<VendaProduto> response = vendaProdutoDAL.GetVendaID(venda);
            return response;
        }


        public override Response Validate(VendaProduto venda)
        {
            AddError(venda.Itens.ListaEstaVazia());

            return base.Validate(venda);
        }
    }
}
