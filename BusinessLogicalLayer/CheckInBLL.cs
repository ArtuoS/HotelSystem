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
        CheckIn_Cliente checkInCliete = new CheckIn_Cliente();
        public Response Insert(CheckIn checkIn)
        {
            Response response = Validate(checkIn);
            if (response.Success)
            {
                return checkInDAL.Insert(checkIn);
            }
            return response;
        }

        public Response Delete(CheckIn checkIn)
        {
            return checkInDAL.Delete(checkIn);
        }

        public QueryResponse<CheckIn> GetAll()
        {
            QueryResponse<CheckIn> response = checkInDAL.GetAll();
            return response;
        }

        
        public override Response Validate(CheckIn checkIn)
        {
            AddError(checkIn.DataSaidaPrevista.VerificaDatas());

            return base.Validate(checkIn);
        }
    }
}
