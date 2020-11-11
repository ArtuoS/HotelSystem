using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class QueryResponse<T> : Response
    {
        public List<T> Data { get; set; }
    }

    public class SingleResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
