using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Provider.API.Application.Commands;

namespace Provider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProviderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult> Confirm(string orderId)
        {
            var result = false;
            if(Int32.TryParse(orderId, out var orderToConfirmId))
            {
                var command = new ConfirmOrderCommand(orderToConfirmId);
                result = await _mediator.Send(command);
                return Ok();
            }
            return BadRequest();
        }

    }
}
