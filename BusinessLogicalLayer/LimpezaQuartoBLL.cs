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
    public class LimpezaQuartoBLL : BaseValidator<LimpezaQuarto>
    {
        LimpezaQuartoDAL limpezaQuartoDAL = new LimpezaQuartoDAL();
        public Response Insert(LimpezaQuarto limpeza)
        {
            Response response = Validate(limpeza);
            if (response.Success)
            {
                return limpezaQuartoDAL.Insert(limpeza);
            }
            return response;
        }

        public override Response Validate(LimpezaQuarto item)
        {
            return base.Validate(item);
        }
    }
}
