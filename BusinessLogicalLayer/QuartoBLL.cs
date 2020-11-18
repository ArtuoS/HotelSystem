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
            QueryResponse<Quarto> response = quartoDAL.GetAll();
            return response;
        }

        public QueryResponse<Quarto> GetNotOccupied()
        {
            QueryResponse<Quarto> response = quartoDAL.GetNotOccupied();
            return response;
        }

        public SingleResponse<Quarto> GetById(int id)
        {
            SingleResponse<Quarto> response = quartoDAL.GetById(id);
            return response;
        }

        public override Response Validate(Quarto quarto)
        {
            AddError(quarto.PessoasMaximas.ValidaPessoasMaximas());

            AddError(StringExtensions.ValidaValorQuarto(quarto.ValorNoite, (TipoQuartos)quarto.TipoQuarto));

            return base.Validate(quarto);
        }
    }
}
