using System;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain;
using AuctionManagement.Domain.Model.Auctions;
using Framework.Application;

namespace AuctionManagement.Application
{
    public class AuctionCommandHandlers : ICommandHandler<OpenAuctionCommand>,
                                        ICommandHandler<PlaceBidCommand>
    {
        private readonly IAuctionRepository auctionRepository;

        public AuctionCommandHandlers(IAuctionRepository auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        public void Handle(OpenAuctionCommand command)
        {
            var id = Guid.NewGuid();
            var auction = new Auction(id,
                                    command.SellerId,
                                    command.StartingPrice,
                                    command.Product,
                                    command.EndDate);

            auctionRepository.Add(auction);
        }

        public void Handle(PlaceBidCommand command)
        {
            var auction = auctionRepository.Get(command.AuctionId);
            auction.PlaceBid(command.BidderId, command.Amount);
            auctionRepository.Update(auction);
        }
    }
}
