using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class CheckOutBLL : BaseValidator<CheckOut>
    {
        CheckOutDAL checkOutDAL = new CheckOutDAL();
        public Response Insert(CheckOut checkOut)
        {
            Response response = Validate(checkOut);
            if(response.Success)
            {
                return checkOutDAL.Insert(checkOut);
            }
            return response;
        }

        public QueryResponse<CheckOut> GetAll()
        {
            QueryResponse<CheckOut> response = checkOutDAL.GetAll();
            return response;
        }

        public override Response Validate(CheckOut checkOut)
        {
            return base.Validate(checkOut);
        }
    }
}
