using System;
using AuctionManagement.Domain;
using AuctionManagement.Domain.Model.Auctions;
using Framework.Domain;

namespace AuctionManagement.Persistance.ES
{
    public class AuctionRepository:IAuctionRepository
    {
        private readonly IEventSourceRepository<Auction, Guid>  repository;

        public AuctionRepository(IEventSourceRepository<Auction, Guid> repository)
        {
            this.repository = repository;
        }

        public Auction Get(Guid id)
        {
         return repository.GetById(id);
        }

        public void Add(Auction auction)
        {
            repository.AppendEvents(auction);
        }

        public void Update(Auction auction)
        {
            repository.AppendEvents(auction);
        }
    }
}
