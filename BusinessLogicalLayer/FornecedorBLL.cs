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

        // Valida e insere um fornecedor
        public Response Insert(Fornecedor fornecedor)
        {
            Response response = Validate(fornecedor);
            if (response.Success)
            {
                return fornecedorDAL.Insert(fornecedor);
            }
            return response;
        }

        // Valida e atualiza um fornecedor
        public Response Update(Fornecedor fornecedor)
        {
            Response response = Validate(fornecedor);
            if (response.Success)
            {
                return fornecedorDAL.Update(fornecedor);
            }
            return response;

        }

        // Deleta um fornecedor
        public Response Delete(Fornecedor fornecedor)
        {
            return fornecedorDAL.Delete(fornecedor);
        }

        // Pega todos os fornecedores e adiciona máscaras
        public QueryResponse<Fornecedor> GetAll()
        {
            QueryResponse<Fornecedor> response = fornecedorDAL.GetAll();
            List<Fornecedor> temp = response.Data;
            foreach (Fornecedor item in temp)
            {
                item.CNPJ = item.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }

            foreach (Fornecedor item in temp)
            {
                item.TelefoneCelular = item.TelefoneCelular.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(10, "-");
            }

            return response;
        }

        // Pega um fornecedor pela razão social
        public SingleResponse<Fornecedor> GetByRazaoSocial(Fornecedor fornecedor)
        {
            SingleResponse<Fornecedor> response = fornecedorDAL.GetByRazaoSocial(fornecedor);
            if (!string.IsNullOrEmpty(fornecedor.CNPJ))
            {
                fornecedor.CNPJ = fornecedor.CNPJ.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
            }
            return response;
        }

        // Recebe e valida um fornecedor
        public override Response Validate(Fornecedor fornecedor)
        {
            AddError(fornecedor.Nome.ValidaNome());

            AddError(fornecedor.RazaoSocial.ValidaRazaoSocial());

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
