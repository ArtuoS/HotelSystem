using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class QuartoBLL : BaseValidator<Quarto>
    {
        private QuartoDAL quartoDAL = new QuartoDAL();
        public Response Insert(Quarto quarto)
        {
            Response response = Validate(quarto);
            if (response.Success)
            {
                return quartoDAL.Insert(quarto);
            }
            return response;
        }
        public Response Update(Quarto quarto)
        {
            Response response = Validate(quarto);
            if (response.Success)
            {
                return quartoDAL.Update(quarto);
            }
            return response;
        }
        public Response Delete(Quarto quarto)
        {
            return quartoDAL.Delete(quarto);
        }
        public QueryResponse<Quarto> GetAll()
        {
            QueryResponse<Quarto> responseQ = quartoDAL.GetAll();
            return responseQ;
        }
        public QueryResponse<Quarto> GetNotOccupied()
        {
            QueryResponse<Quarto> responseQ = quartoDAL.GetNotOccupied();
            return responseQ;
        }
        public override Response Validate(Quarto quarto)
        {
            AddError(quarto.PessoasMaximas.ValidaPessoasMaximas());
            AddError(StringExtensions.ValidaValorQuarto(quarto.ValorNoite, (TipoQuartos)quarto.TipoQuarto));
            return base.Validate(quarto);
        }
    }
}
