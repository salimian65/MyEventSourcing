using System;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions.Events
{
    public class BidPlaced : DomainEvent
    {
        public BidPlaced( Guid auctionId,long bidderId, long bidAmount)
        {
            AuctionId = auctionId;
            BidderId = bidderId;
            BidAmount = bidAmount;
          
        }

        public Guid AuctionId { get; private set; }

        public long BidderId { get; private set; }

        public long BidAmount { get; private set; }
    }

    public class AuctionClosed : DomainEvent
    {
        public AuctionClosed(Guid auctionId, long bidderId, long bidAmount)
        {
            AuctionId = auctionId;
            BidderId = bidderId;
            BidAmount = bidAmount;
        }

        public Guid AuctionId { get; private set; }

        public long BidderId { get; private set; }

        public long BidAmount { get; private set; }
    }

    public class WinnerIsClosen: DomainEvent
    {
        public WinnerIsClosen(Guid auctionId, long bidderId, long bidAmount)
        {
            AuctionId = auctionId;
            BidderId = bidderId;
            BidAmount = bidAmount;
        }

        public Guid AuctionId { get; private set; }

        public long BidderId { get; private set; }

        public long BidAmount { get; private set; }
    }
}