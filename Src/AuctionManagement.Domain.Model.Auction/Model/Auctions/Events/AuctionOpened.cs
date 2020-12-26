using System;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions.Events
{
    public class AuctionOpened : DomainEvent
    {
        public AuctionOpened(Guid id, long sellerId, long startingPrice, DateTime endDate, string product)
        {
            Id = id;
            SellerId = sellerId;
            StartingPrice = startingPrice;
            Product = product;
            EndDate = endDate;
        }

        public Guid Id { get; private set; }

        public long SellerId { get; private set; }

        public long StartingPrice { get; private set; }

        public string Product { get; private set; }

        public DateTime EndDate { get; private set; }
    }
}