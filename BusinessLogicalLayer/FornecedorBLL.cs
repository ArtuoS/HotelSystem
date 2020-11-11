using BusinessLogicalLayer.Extensions;
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
    public class FornecedorBLL : BaseValidator<Fornecedor>
    {
        FornecedorDAL fornecedorDAL = new FornecedorDAL();
        public Response Insert(Fornecedor fornecedor)
        {
            Response response = Validate(fornecedor);
            if (response.Success)
            {
                return fornecedorDAL.Insert(fornecedor);
            }
            return response;
        }

        public Response Update(Fornecedor fornecedor)
        {
            Response response = Validate(fornecedor);
            if (response.Success)
            {
                return fornecedorDAL.Update(fornecedor);
            }
            return response;

        }

        public Response Delete(Fornecedor fornecedor)
        {
            return fornecedorDAL.Delete(fornecedor);
        }
        /*
        public Response Disable(Fornecedor fornecedor)
        {
            return fornecedorDAL.Disable(fornecedor);
        }
        */
        public QueryResponse<Fornecedor> GetAll()
        {
            QueryResponse<Fornecedor> response = fornecedorDAL.GetAll();
            List<Fornecedor> temp = response.Data;
            foreach (Fornecedor item in temp)
            {
                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }
            return response;
        }

        public SingleResponse<Fornecedor> GetByRazaoSocial(Fornecedor fornecedor)
        {
            SingleResponse<Fornecedor> response = fornecedorDAL.GetByRazaoSocial(fornecedor);
            if (!string.IsNullOrEmpty(fornecedor.CNPJ))
            {
                fornecedor.CNPJ = fornecedor.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }
            return response;
        }

        public override Response Validate(Fornecedor fornecedor)
        {
            AddError(fornecedor.Nome.ValidaNome());

            AddError(fornecedor.CNPJ.ValidadorCNPJ());

            AddError(fornecedor.Email.ValidadorEmail());

            if (!string.IsNullOrWhiteSpace(fornecedor.CNPJ))
            {
                fornecedor.CNPJ = fornecedor.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "");
            }

            if (!string.IsNullOrEmpty(fornecedor.TelefoneCelular))
            {
                fornecedor.TelefoneCelular = fornecedor.TelefoneCelular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            }

            AddError(fornecedor.TelefoneCelular.ValidaTelefone(0));

            return base.Validate(fornecedor);
        }
    }
}
