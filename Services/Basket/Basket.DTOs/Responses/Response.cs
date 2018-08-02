using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.DTOs.Responses
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Result {get;set;}
    }
}
