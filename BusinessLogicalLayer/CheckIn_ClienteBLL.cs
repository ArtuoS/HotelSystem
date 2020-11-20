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
    public class CheckIn_ClienteBLL : BaseValidator<CheckIn_Cliente>
    {
        CheckIn_ClienteDAL checkIn_ClienteDAL = new CheckIn_ClienteDAL();

        // Pega informações to check-in + clientes obs: inner join
        public QueryResponse<CheckIn_Cliente> GetData()
        {
            QueryResponse<CheckIn_Cliente> response = checkIn_ClienteDAL.GetData();
            return response;
        }
    }
}
