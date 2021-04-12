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
    public class CheckInBLL : BaseValidator<CheckIn>
    {
        CheckInDAL checkInDAL = new CheckInDAL();

        // Insere um check-in
        public Response Insert(CheckIn checkIn)
        {
            Response response = Validate(checkIn);
            if (response.Success)
            {
                return checkInDAL.Insert(checkIn);
            }
            return response;
        }

        // Pega todos os check-ins
        public QueryResponse<CheckIn> GetAll()
        {
            QueryResponse<CheckIn> response = checkInDAL.GetAll();
            return response;
        }

        // Pega um check-in pelo ID
        public SingleResponse<CheckIn> GetById(int id)
        {
            SingleResponse<CheckIn> response = checkInDAL.GetById(id);
            return response;
        }

        // Recebe e valida um check-in
        public override Response Validate(CheckIn checkIn)
        {
            AddError(checkIn.DataSaidaPrevista.VerificaDatas());

            return base.Validate(checkIn);
        }
    }
}
