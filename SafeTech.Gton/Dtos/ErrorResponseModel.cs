using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos
{
    public class ErrorResponseModel
    {
        public string Message { get; private set; }
        public ErrorResponseModel(string message)
        {
            Message = message;
        }
    }
}
