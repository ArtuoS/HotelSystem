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

        // Valida e insere um quarto
        public Response Insert(Quarto quarto)
        {
            Response response = Validate(quarto);
            if (response.Success)
            {
                return quartoDAL.Insert(quarto);
            }
            return response;
        }

        // Valida e atualiza um quarto
        public Response Update(Quarto quarto)
        {
            Response response = Validate(quarto);
            if (response.Success)
            {
                return quartoDAL.Update(quarto);
            }
            return response;
        }

        // Deleta um quarto
        public Response Delete(Quarto quarto)
        {
            return quartoDAL.Delete(quarto);
        }

        // Pega todos os quartos
        public QueryResponse<Quarto> GetAll()
        {
            QueryResponse<Quarto> response = quartoDAL.GetAll();
            return response;
        }

        // Pega todos os quartos não ocupados
        public QueryResponse<Quarto> GetNotOccupied()
        {
            QueryResponse<Quarto> response = quartoDAL.GetNotOccupied();
            return response;
        }

    
        // Pega um quarto pelo ID
        public SingleResponse<Quarto> GetById(int id)
        {
            SingleResponse<Quarto> response = quartoDAL.GetById(id);
            return response;
        }
        
        // Recebe um quarto e o valida
        public override Response Validate(Quarto quarto)
        {
            AddError(quarto.PessoasMaximas.ValidaPessoasMaximas());

            AddError(StringExtensions.ValidaValorQuarto(quarto.ValorNoite, (TipoQuartos)quarto.TipoQuarto));

            return base.Validate(quarto);
        }
    }
}
