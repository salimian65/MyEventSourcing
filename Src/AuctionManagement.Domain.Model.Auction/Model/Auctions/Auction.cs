using System;
using AuctionManagement.Domain.Model.Auctions.Events;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public partial class Auction : AggregateRoot<Guid>
    {
        public Auction(Guid id, 
            long sellerId, 
            long startingPrice,
            string product, 
            DateTime endDate)
        {
            if (endDate < DateTime.Now)
            {
                throw new Exception("End Date is less than now");
            }

            ApplyAndPublish(new AuctionOpened(id, sellerId, startingPrice, endDate, product));
        }

        public long SellerId { get; private set; }

        public long StartingPrice { get; private set; }

        public string Product { get; private set; }

        public DateTime EndDate { get; private set; }

        public WinningBid WinningBid { get; private set; }

        public void PlaceBid(long bidderId, long amount)
        {
            var maxBid = this.StartingPrice;

            if (!FirstBid())
            {
                maxBid = this.WinningBid.Amount;
            }

            if (maxBid >= amount)
            {
                throw new Exception("Invalid amount");
            }


        }
        private bool FirstBid()
        {
            return this.WinningBid == null;
        }
    }
}
