using BoardingCards.DomainShared.Enums;
using BoardingCards.Extensions;

namespace BoardingCards.Domain
{
    public abstract class BaseBoardingCard
    {
        protected BaseBoardingCard(TransportType transportType, string departure, string destination, string? seatNumber = null)
        {
            Type = transportType;
            Departure = departure;
            Destination = destination;
            SeatNumber = seatNumber;
        }

        public TransportType Type { get; init; } = TransportType.None;
        public required string Departure { get; init; }
        public required string Destination { get; init; }
        public string? SeatNumber { get; init; }

        public virtual string TypeInformation => Type.ToLowerString();
        public virtual string SeatInformation => !string.IsNullOrWhiteSpace(SeatNumber) ? $"Sit in seat {SeatNumber}." : "No seat assignment.";

        public override string ToString() => $"Take {TypeInformation} from {Departure} to {Destination}. {SeatInformation}";
    }
}
