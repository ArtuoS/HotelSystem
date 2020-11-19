using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class EntitiesExtensions
    {
        public static dynamic ConvertToType(this object obj)
        {
            return Convert.ChangeType(obj, obj.GetType());
        }

        //public static ConvertToClass()
    }
}
