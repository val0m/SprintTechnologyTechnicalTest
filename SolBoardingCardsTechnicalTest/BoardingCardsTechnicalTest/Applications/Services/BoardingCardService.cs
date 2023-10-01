using BoardingCards.Applications.Queries;
using BoardingCards.Contracts;
using BoardingCards.Domain;
using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Applications
{
    public class BoardingCardService : IBoardingCardService
    {
        public BaseBoardingCard GetBoardingCardFactory(BoardingCardRequest input)
            => input.Type switch
            {
                TransportType.Train => new TrainBoardingCard(input.Departure, input.Destination),
                TransportType.Airplane => new AirplaneBoardingCard(input.Departure, input.Destination, input.SeatNumber, input.TransportNumber, input.GateNumber, input.BaggageTicketCounter),
                TransportType.AirportBus => new AirportBusBoardingCard(input.Departure, input.Destination, input.SeatNumber),
                TransportType.Bus => new BusBoardingCard(input.Departure, input.Destination, input.SeatNumber),
                TransportType.Taxi => new TaxiBoardingCard(input.Departure, input.Destination),
                _ => throw new NotImplementedException($"The {input.Type} transport has not yet been implemented.")
            };

        public List<string> GetSummaries(List<BoardingCardRequest> boardingCardInputs)
        {
            throw new NotImplementedException();
        }
    }
}
