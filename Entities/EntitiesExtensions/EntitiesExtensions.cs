using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class EntitiesExtensions
    {
        // Converte para o tipo correto de variavel
        public static dynamic ConvertToType(this object obj)
        {
            return Convert.ChangeType(obj, obj.GetType());
        }
    }
}
