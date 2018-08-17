using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Provider.API.Application.Commands;
using Provider.API.Application.Queries;
using Provider.API.Infrastructure.Services;

namespace Provider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderQueries _orderQueries;
        private readonly IIdentityService _identityService;

        public ProviderController(IMediator mediator, IOrderQueries orderQueries, IIdentityService identityService)
        {
            this._mediator = mediator;
            this._orderQueries = orderQueries;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult> Order(int id)
        {
            var order = await _orderQueries.GetOrderAsync(id);

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult> Orders()
        {
            var userId = _identityService.GetUserIdentity();
            var orders = await _orderQueries.GetProviderOrdersAsync(userId);

            return Ok(orders);
        }

        [HttpPut]
        public async Task<ActionResult> Confirm(string orderId)
        {
            var result = false;
            if (Int32.TryParse(orderId, out var orderToConfirmId))
            {
                var command = new ConfirmOrderCommand(orderToConfirmId);
                result = await _mediator.Send(command);
                return Ok();
            }
            return BadRequest();
        }

    }
}
