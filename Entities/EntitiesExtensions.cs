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

        private static object CreateByTypeName(string typeName)
        {
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from t in assembly.GetTypes()
                        where t.Name == typeName
                        select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Type not found");

            return Activator.CreateInstance(type);
        }
    }
}
