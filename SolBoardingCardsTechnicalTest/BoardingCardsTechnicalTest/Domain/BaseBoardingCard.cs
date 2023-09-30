using BoardingCards.DomainShared.Enums;
using BoardingCards.Extensions;

namespace BoardingCards.Domain
{
    public abstract class BaseBoardingCard
    {
        protected BaseBoardingCard(TransportType transportType, string departure, string destination)
        {
            Type = transportType;
            Departure = departure;
            Destination = destination;
        }
        protected BaseBoardingCard(TransportType transportType, string departure, string destination, string seat)
        {
            Type = transportType;
            Departure = departure;
            Destination = destination;
            Seat = seat;
        }

        public required string Departure { get; init; }
        public required string Destination { get; init; }
        public string? Seat { get; init; }
        public TransportType Type { get; init; } = TransportType.None;

        public virtual string SeatInformation => !string.IsNullOrWhiteSpace(Seat) ? $"Sit in seat {Seat}." : "No seat assignment.";

        public override string ToString() => $"Take {Type.ToLowerString()} from {Departure} to {Destination}. {SeatInformation}";
    }
}
