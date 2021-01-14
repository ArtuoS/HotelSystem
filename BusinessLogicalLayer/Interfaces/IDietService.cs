using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer.Interfaces
{
    interface IDietService : IEntityCRUD<Diet>
    {
        SingleResponse<Diet> GetByName(Diet item);
    }
}
