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
    /*
    public class ULTRAFuncionarioBLL : BaseValidator<Funcionario>
    {
        private ULTRAFuncionarioDAL funcionarioDAL = new ULTRAFuncionarioDAL();
        public Response Insert(Funcionario item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return funcionarioDAL.Insert(item);
            }
            return response;
        }
        public Response Update(Funcionario item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return funcionarioDAL.Update(item);
            }
            return response;
        }
        public override Response Validate(Funcionario funcionario)
        {
            if(string.IsNullOrEmpty(funcionario.Nome))
            {
                AddError("Preencher o campo Nome!");
            } else if (funcionario.Nome.Length < 3 || funcionario.Nome.Length > 70)
            {
                AddError("O nome deve ter entre 3 e 70 caractéres!");
            }

            AddError(funcionario.Email.IsValidEmail());

            return base.Validate(funcionario);
        }
     }
    */
}
