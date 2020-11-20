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
        ProdutoDAL produtoDAL = new ProdutoDAL();
        public Response InsertVenda(VendaProduto venda)
        {
            Response response = Validate(venda);
            if (response.Success)
            {
                venda.DataVenda = DateTime.Now;
                venda.Valor = venda.Itens.Sum(w => w.Valor * w.Quantidade);
                SingleResponse<VendaProduto> responseVenda = vendaProdutoDAL.InsertVenda(venda);
                using (TransactionScope scope = new TransactionScope())
                {
                    if (responseVenda.Success)
                    {
                        foreach (ItensVenda item in venda.Itens)
                        {
                            ItensVendaBLL itensVendaBLL = new ItensVendaBLL();
                            SingleResponse<VendaProduto> responseEntradaID = vendaProdutoDAL.GetVendaID(venda.ID);
                            item.VendaID = responseEntradaID.Data.ID;
                            Response responseItensVenda = itensVendaBLL.InsertItem(item);

                            if (responseItensVenda.Success)
                            {
                                produtoDAL.AtualizaEstoqueVenda(item.ProdutoID, item.Quantidade);
                            } else
                            {
                                return responseItensVenda;
                            }
                        }
                        venda.Itens.Clear();
                    }
                    scope.Complete();
                }
                return responseVenda;
            }
            return response;
        }

        public SingleResponse<VendaProduto> GetVendaID(int id)
        {
            SingleResponse<VendaProduto> response = vendaProdutoDAL.GetVendaID(id);
            return response;
        }

        public SingleResponse<VendaProduto> GetVendaById(int id)
        {
            SingleResponse<VendaProduto> response = vendaProdutoDAL.GetVendaById(id);
            return response;
        }

        public override Response Validate(VendaProduto venda)
        {
            AddError(venda.Itens.ListaEstaVazia());

            return base.Validate(venda);
        }
    }
}
