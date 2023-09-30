using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class PlaneBoardingCard : BaseBoardingCard
    {
        public PlaneBoardingCard(string departure, string destination, string seat, string airport, string gate, string? tickerCounter) : base(TransportType.Plane, departure, destination)
        {
            if (string.IsNullOrWhiteSpace(seat))
            {
                throw new ArgumentNullException(nameof(seat), "The seat is a mandatory item for an 'plane' boarding pass.");
            }

            Seat = seat;
            Airport = airport;
            Gate = gate;
            TicketCounter = tickerCounter;
        }

        public required string Airport { get; init; }
        public required string Gate { get; init; }
        public string? TicketCounter { get; init; }

        public override string SeatInformation => $"Get {Gate}, seat {Seat}.";
    }
}
