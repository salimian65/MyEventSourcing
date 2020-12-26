using System;

namespace AuctionManagement.Application.Contracts
{
    public class PlaceBidCommand
    {
        public Guid AuctionId { get; set; }

        public long BidderId { get; set; }

        public long Amount { get; set; }
    }
}