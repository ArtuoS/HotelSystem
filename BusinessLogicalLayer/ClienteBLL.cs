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
    public class ClienteBLL : BaseValidator<Cliente>
    {
        private ClienteDAL clienteDAL = new ClienteDAL();
        public Response Insert(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (response.Success)
            {
                return clienteDAL.Insert(cliente);
            }
            return response;
        }

        public Response Update(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (response.Success)
            {
                return clienteDAL.Update(cliente);
            }
            return response;
        }

        public Response Delete(Cliente cliente)
        {
            return clienteDAL.Delete(cliente);
        }

        public Response DesativaCliente(Cliente cliente)
        {
            return clienteDAL.DesativaCliente(cliente);
        }

        public QueryResponse<Cliente> GetAll()
        {
            QueryResponse<Cliente> responseClientes = clienteDAL.GetAll();
            List<Cliente> temp = responseClientes.Data;
            foreach (Cliente item in temp)
            {
                item.CPF = item.CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }

            foreach (Cliente item in temp)
            {
                item.RG = item.RG.Insert(3, ".").Insert(7, ".").Insert(10, "-");
            }

            foreach (Cliente item in temp)
            {
                item.TelefoneCelular = item.TelefoneCelular.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(11, "-");
            }

            foreach (Cliente item in temp)
            {
                item.TelefoneFixo = item.TelefoneFixo.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(9, "-");
            }
            return responseClientes;
        }

        public SingleResponse<Cliente> GetById(Cliente cliente)
        {
            SingleResponse<Cliente> response = clienteDAL.GetById(cliente);
            return response;
        }

        public SingleResponse<Cliente> GetByCpf(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                cpf = cpf.Replace(".", "").Replace("-", "");
            }
            SingleResponse<Cliente> response = clienteDAL.GetByCpf(cpf);
            if (!string.IsNullOrEmpty(cpf))
            {
                cpf = cpf.Replace(".", "").Replace("-", "");
            }
            return response;
        }

        public override Response Validate(Cliente cliente)
        {
            AddError(cliente.Nome.ValidaNome());

            AddError(cliente.CPF.ValidadorCPF());

            AddError(cliente.Email.ValidadorEmail());

            AddError(clienteDAL.IsEmailUnique(cliente).Message);

            if (!string.IsNullOrEmpty(cliente.CPF))
            {
                cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
            }

            if (!string.IsNullOrEmpty(cliente.RG))
            {
                cliente.RG = cliente.RG.Replace(".", "").Replace("-", "");
            }

            AddError(clienteDAL.IsCPFUnique(cliente).Message);

            AddError(clienteDAL.IsRGUnique(cliente).Message);

            if (!string.IsNullOrEmpty(cliente.TelefoneCelular))
            {
                cliente.TelefoneCelular = cliente.TelefoneCelular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            }

            if (!string.IsNullOrEmpty(cliente.TelefoneFixo))
            {
                cliente.TelefoneFixo = cliente.TelefoneFixo.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            }

            AddError(cliente.TelefoneCelular.ValidaTelefone(0));

            AddError(cliente.TelefoneFixo.ValidaTelefone(1));

            return base.Validate(cliente);
        }
    }
}
