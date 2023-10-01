using BoardingCards.Applications.Queries;
using BoardingCards.Contracts;
using BoardingCards.Domain;
using BoardingCards.DomainShared.Enums;
using BoardingCards.DomainShared.Exceptions;

namespace BoardingCards.Applications
{
    public class BoardingCardService : IBoardingCardService
    {
        public BaseBoardingCard GetBoardingCardFactory(BoardingCardRequest input)
            => input.Type switch
            {
                TransportType.Train => new TrainBoardingCard(input.Departure, input.Destination, input.TransportNumber, input.SeatNumber),
                TransportType.Airplane => new AirplaneBoardingCard(input.Departure, input.Destination, input.TransportNumber, input.SeatNumber, input.GateNumber, input.BaggageTicketCounter),
                TransportType.AirportBus => new AirportBusBoardingCard(input.Departure, input.Destination, input.TransportNumber, input.SeatNumber),
                TransportType.Bus => new BusBoardingCard(input.Departure, input.Destination, input.TransportNumber, input.SeatNumber),
                TransportType.Taxi => new TaxiBoardingCard(input.Departure, input.Destination),
                _ => throw new BoardingCardNotSupportedException($"The {input.Type} transport has not yet been implemented.")
            };
    }
}
