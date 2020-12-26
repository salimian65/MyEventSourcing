using System;
using System.Runtime.CompilerServices;
using AuctionManagement.Domain.Model.Auctions.Events;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public partial class Auction
    {
        //public override void Apply(DomainEvent @event)
        //{
        //    When((dynamic) @event);
        //}

        private void When(AuctionOpened @event)
        {
            this.Id = @event.Id;
            this.SellerId = @event.SellerId;
            this.StartingPrice = @event.StartingPrice;
            this.Product = @event.Product;
            this.EndDate = @event.EndDate;
        }

        private void When(BidPlaced @event)
        {
            this.WinningBid = new WinningBid(@event.BidderId, @event.BidAmount);
        }

        protected override void When(DomainEvent @event)
        {
            When((dynamic)@event);
        }
    }
}
