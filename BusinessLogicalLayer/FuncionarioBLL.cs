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
    public class FuncionarioBLL : BaseValidator<Funcionario>
    {
        private FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
        public Response Insert(Funcionario funcionario)
        {
            Response response = Validate(funcionario);
            if (response.Success)
            {
                return funcionarioDAL.Insert(funcionario);
            }
            return response;
        }

        public Response Update(Funcionario funcionario)
        {
            Response response = Validate(funcionario);
            if (response.Success)
            {
                return funcionarioDAL.Update(funcionario);
            }
            return response;
        }

        public Response Delete(Funcionario funcionario)
        {
            return funcionarioDAL.Delete(funcionario);
        }

        public QueryResponse<Funcionario> GetAll()
        {
            QueryResponse<Funcionario> responseF = funcionarioDAL.GetAll();
            List<Funcionario> temp = responseF.Data;
            foreach (Funcionario item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(12, "-");
            }

            foreach (Funcionario item in temp)
            {
                item.RG = item.RG.Insert(3, ".").Insert(7, ".").Insert(10, "-");
            }

            foreach (Funcionario item in temp)
            {
                foreach (char ch in item.Senha)
                {
                    item.Senha = item.Senha.Replace(ch, '*');
                }
            }

            return responseF;
        }

        public SingleResponse<Funcionario> GetByLogin(Funcionario funcionario)
        {
            SingleResponse<Funcionario> response = funcionarioDAL.GetByLogin(funcionario);
            if (response.Success)
            {
                Common.Environments.FuncionarioLogado = response.Data;
            }
            return response;
        }

        public override Response Validate(Funcionario funcionario)
        {
            AddError(funcionario.Nome.ValidaNome());

            AddError(funcionario.CPF.ValidadorCPF());

            AddError(funcionario.Email.ValidadorEmail());

            AddError(funcionarioDAL.IsEmailUnique(funcionario).Message);

            AddError(StringExtensions.VerificaEndereco(funcionario.Rua, funcionario.Bairro, funcionario.NumeroCasa));

            if (!string.IsNullOrEmpty(funcionario.CPF))
            {
                funcionario.CPF = funcionario.CPF.Replace(".", "").Replace("-", "");
            }
            if (!string.IsNullOrEmpty(funcionario.RG))
            {
                funcionario.RG = funcionario.RG.Replace(".", "").Replace("-", "");
            }

            AddError(funcionarioDAL.IsCPFUnique(funcionario).Message);

            AddError(funcionarioDAL.IsRGUnique(funcionario).Message);

            return base.Validate(funcionario);
        }
    }
}
