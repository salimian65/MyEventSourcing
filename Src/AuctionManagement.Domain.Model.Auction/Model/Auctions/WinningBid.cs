using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class WinningBid:Entity<long>
    {
        public WinningBid(long id ,long amount)
        {
            Id = id;
            Amount = amount;
        }

        public long Amount { get; private set; }
       

    }
}