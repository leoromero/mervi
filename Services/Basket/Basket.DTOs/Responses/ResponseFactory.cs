using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.DTOs.Responses
{
    public static class ResponseFactory
    {
        public static Response<bool> GetBoolResponse(bool result, string message = "")
        {
            return new Response<bool> { Message = message, Result = result };
        }

        public static Response<CustomerBasketDTO> GetBasketResponse(CustomerBasketDTO result, string message = "")
        {
            return new Response<CustomerBasketDTO> { Message = message, Result = result };
        }
    }
}
