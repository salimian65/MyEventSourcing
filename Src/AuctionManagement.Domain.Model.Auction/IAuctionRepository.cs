using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;

namespace AuctionManagement.Domain
{
    public interface IAuctionRepository
    {
        Auction Get(Guid id);

        void Add(Auction auction);

        void Update(Auction auction); // TODO: discuss update method
    }
}
