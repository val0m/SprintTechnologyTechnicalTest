namespace BoardingCards.Domain
{
    public abstract class BaseBoardingCard
    {
        public BaseBoardingCard(string departure, string destination)
        {
            Departure = departure;
            Destination = destination;
        }

        public BaseBoardingCard(string departure, string destination, string? seatNumber)
        {
            Departure = departure;
            Destination = destination;
            SeatNumber = seatNumber;
        }

        public string Departure { get; init; }
        public string Destination { get; init; }
        public string? SeatNumber { get; init; }

        public abstract string TypeInformation { get; }
        public virtual string SeatInformation => !string.IsNullOrWhiteSpace(SeatNumber) ? $"Sit in seat {SeatNumber}." : "No seat assignment.";

        public virtual string GetSummary() => $"Take {TypeInformation} from {Departure} to {Destination}. {SeatInformation}";
    }
}
