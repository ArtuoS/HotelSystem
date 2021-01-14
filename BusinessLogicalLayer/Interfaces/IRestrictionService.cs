using BusinessLogicalLayer.Interfaces;
using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    interface IRestrictionService : IEntityCRUD<Restriction>
    {
        SingleResponse<Restriction> GetByName(Restriction item);
    }
}
