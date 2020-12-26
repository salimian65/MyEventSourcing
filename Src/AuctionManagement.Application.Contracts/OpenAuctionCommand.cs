using System;

namespace AuctionManagement.Application.Contracts
{
    public class OpenAuctionCommand
    {
        public long SellerId { get; set; }

        public long StartingPrice { get; set; }

        public string Product { get; set; }

        public DateTime EndDate { get; set; }
    }
}
