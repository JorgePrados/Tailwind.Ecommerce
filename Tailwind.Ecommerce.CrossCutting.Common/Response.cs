using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Ecommerce.CrossCutting.Common
{
    public class Response<T>: IResponse<T>
    {
        public T data { get; set; }
        public int codeMessage { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public int rowsAffected { get; set; }
    }
}
