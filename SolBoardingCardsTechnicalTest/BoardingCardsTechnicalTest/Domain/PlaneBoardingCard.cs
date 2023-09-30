using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class PlaneBoardingCard : BaseBoardingCard
    {
        public PlaneBoardingCard(string departure, string destination, string seatNumber, string flightNumber, string gateNumber, string? baggageTicketCounter = null) : base(TransportType.Plane, departure, destination, seatNumber)
        {
            if (string.IsNullOrWhiteSpace(seatNumber))
            {
                throw new ArgumentNullException(nameof(seatNumber), "The seat is a mandatory item for an 'plane' boarding pass.");
            }

            FlightNumber = flightNumber;
            GateNumber = gateNumber;
            BaggageTicketCounter = baggageTicketCounter;
        }

        public required string GateNumber { get; init; }
        public required string FlightNumber { get; init; }
        public string? BaggageTicketCounter { get; init; }

        private string BaggageTicketCounterInformation => !string.IsNullOrWhiteSpace(BaggageTicketCounter) ? $"Baggage drop at ticket counter {BaggageTicketCounter}." : "Baggage will be automatically transferred from your last leg.";
        public override string SeatInformation => $"Get {GateNumber}, seat {SeatNumber}.";

        public override string ToString() => $"From {Departure}, take flight {FlightNumber} to {Destination}. {SeatInformation} {BaggageTicketCounterInformation}";
    }
}
