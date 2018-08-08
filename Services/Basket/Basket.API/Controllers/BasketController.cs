using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.BL.Interfaces;
using Basket.DTOs;
using Basket.DTOs.Requests;
using Basket.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> CheckoutAsync(BasketCheckoutRequest checkout)
        {
            var result = await service.Checkout(checkout);
            if (!result.Result)
                return BadRequest(result);

            return Accepted(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAsync(string userId)
        {
            var result = await service.GetBasketAsync(userId);

            var response = ResponseFactory.GetBasketResponse(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(CustomerBasketDTO basket)
        {
            var result = await service.UpdateBasketAsync(basket);
            if (result.Result == null)
                return StatusCode(503, result);

            return Ok(result);
        }
    }
}