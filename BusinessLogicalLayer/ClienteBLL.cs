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

        // Valida e insere um cliente
        public Response Insert(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (response.Success)
            {
                return clienteDAL.Insert(cliente);
            }
            return response;
        }

        // Valida e atualiza um cliente
        public Response Update(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (response.Success)
            {
                return clienteDAL.Update(cliente);
            }
            return response;
        }

        // Deleta um cliente
        public Response Delete(Cliente cliente)
        {
            return clienteDAL.Delete(cliente);
        }

        // Pega todos os clientes e adiciona máscaras
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
                item.TelefoneCelular = item.TelefoneCelular.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(10, "-");
            }

            foreach (Cliente item in temp)
            {
                item.TelefoneFixo = item.TelefoneFixo.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(9, "-");
            }
            return responseClientes;
        }

        // Pega um cliente pelo ID
        public SingleResponse<Cliente> GetById(Cliente cliente)
        {
            SingleResponse<Cliente> response = clienteDAL.GetById(cliente);
            return response;
        }

        // Pega um cliente pelo CPF
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

        // Recebe e valida um cliente
        public override Response Validate(Cliente cliente)
        {
            AddError(cliente.Nome.ValidaNome());

            AddError(cliente.CPF.ValidadorCPF());

            if (!string.IsNullOrEmpty(cliente.CPF))
            {
                cliente.CPF = cliente.CPF.Replace(".", "").Replace("-", "");
            }

            if (!string.IsNullOrEmpty(cliente.RG))
            {
                cliente.RG = cliente.RG.Replace(".", "").Replace("-", "");
            }

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
