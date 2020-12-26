using System;
using System.Collections;
using System.Collections.Generic;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Auctions;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;

namespace AuctionManagement.Gateways.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private readonly ICommandBus commandBus;

        public AuctionsController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }


        [HttpPost]
        public IActionResult Post([FromBody]OpenAuctionCommand command )
        {
            commandBus.Dispatch(command);
            return Ok();
        }

        [HttpPost("{id}/Bids")]
        public IActionResult Post(Guid id,PlaceBidCommand command)
        {
            commandBus.Dispatch(command);
            return Ok();
        }
    }
}
