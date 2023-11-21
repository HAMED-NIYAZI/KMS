using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.ViewModel.Response
{
    public class ResponseViewModel
    {
        public string Message { get; set; } = "";
        public object? Data { get; set; } = null;
        public int StatusCode { get; set; } = 500;
        public Result Result { get; set; } =Result.Failed;

    }

    public enum Result { 
    Success=1,
    Failed=2,
    NotFound=3,
    ExeptionError=4,
    ServerError=5
    }
}
