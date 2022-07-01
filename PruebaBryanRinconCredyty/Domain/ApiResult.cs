using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApiResult
    {
        public string Message { get; set; }
        public object Result { get; set; }
        public string Error { get; set; }
    }
}
