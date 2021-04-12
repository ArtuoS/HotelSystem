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
    public class EntradaProdutoBLL : BaseValidator<EntradaProduto>
    {
        EntradaProdutoDAL entradaProdutoDAL = new EntradaProdutoDAL();
        ProdutoDAL produtoDAL = new ProdutoDAL();

        // Insere uma entrada + itens
        public Response InsertEntrada(EntradaProduto entrada)
        {
            Response response = Validate(entrada);
            if (response.Success)
            {
                entrada.DataEntrada = DateTime.Now;
                entrada.Valor = entrada.Itens.Sum(w => w.Valor * w.Quantidade);
                SingleResponse<EntradaProduto> responseEntrada = entradaProdutoDAL.InsertEntrada(entrada);
                using (TransactionScope scope = new TransactionScope())
                {
                    if (responseEntrada.Success)
                    {
                        foreach (ItensEntrada item in entrada.Itens)
                        {
                            SingleResponse<EntradaProduto> responseEntradaID = entradaProdutoDAL.GetEntradaID(entrada);
                            item.EntradaID = responseEntradaID.Data.ID;

                            ItensEntradaBLL itensEntradaBLL = new ItensEntradaBLL();
                            Response responseItensEntrada = itensEntradaBLL.InsertItem(item);

                            if (responseItensEntrada.Success)
                            {
                                produtoDAL.AtualizaPreco(item.ProdutoID, item.Valor, item.Quantidade);
                                produtoDAL.AtualizaEstoqueEntrada(item.ProdutoID, item.Quantidade);
                            }
                        }
                        entrada.Itens.Clear();
                    }
                    scope.Complete();
                }
                return responseEntrada;
            }
            return response;
        }

        // Pega o ID da entrada
        public SingleResponse<EntradaProduto> GetEntradaID(EntradaProduto entrada)
        {
            SingleResponse<EntradaProduto> response = entradaProdutoDAL.GetEntradaID(entrada);
            return response;
        }

        // Recebe e valida uma entrada
        public override Response Validate(EntradaProduto entrada)
        {
            AddError(entrada.Itens.ListaEstaVazia());

            return base.Validate(entrada);
        }
    }
}
