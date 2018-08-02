using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.BL.Interfaces;
using Basket.DTOs;
using Basket.DTOs.Requests;
using Basket.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService service;

        public BasketController(IBasketService service)
        {
            this.service = service;
        }
        [HttpPost]
        public ActionResult Checkout(BasketCheckoutRequest checkout)
        {
            var result = Task.Run(() => service.Checkout(checkout)).Result;
            if (!result.Result)
                return BadRequest(result);

            return Accepted(result);
        }

        [HttpGet]
        public ActionResult Get(string userId)
        {
            //get userId from token
            var result = Task.Run(() => service.GetBasketAsync(userId)).Result;

            var response = ResponseFactory.GetBasketResponse(result);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(CustomerBasketDTO basket)
        {
            var result = Task.Run(() => service.UpdateBasketAsync(basket)).Result;
            if (result.Result == null)
                return StatusCode(503, result);

            return Ok(result);
        }
    }
}