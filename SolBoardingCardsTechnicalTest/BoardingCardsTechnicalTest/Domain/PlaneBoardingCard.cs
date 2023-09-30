namespace BoardingCards.Domain
{
    public class PlaneBoardingCard : BaseBoardingCard
    {
        public PlaneBoardingCard(string departure, string destination, string seatNumber, string flightNumber, string gateNumber, string? baggageTicketCounter = null) : base(departure, destination, seatNumber)
        {
            if (string.IsNullOrWhiteSpace(seatNumber))
            {
                throw new ArgumentNullException(nameof(seatNumber), "The seat number is a mandatory item for an 'plane' boarding pass.");
            }
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                throw new ArgumentNullException(nameof(flightNumber), "The fight number is a mandatory item for an 'plane' boarding pass.");
            }
            if (string.IsNullOrWhiteSpace(gateNumber))
            {
                throw new ArgumentNullException(nameof(gateNumber), "The gate number is a mandatory item for an 'plane' boarding pass.");
            }

            FlightNumber = flightNumber;
            GateNumber = gateNumber;
            BaggageTicketCounter = baggageTicketCounter;
        }

        public string GateNumber { get; init; }
        public string FlightNumber { get; init; }
        public string? BaggageTicketCounter { get; init; }

        public override string TypeInformation => "flight";
        private string BaggageTicketCounterInformation => !string.IsNullOrWhiteSpace(BaggageTicketCounter) ? $"Baggage drop at ticket counter {BaggageTicketCounter}." : "Baggage will be automatically transferred from your last leg.";
        public override string SeatInformation => $"Get {GateNumber}, seat {SeatNumber}.";

        public override string GetSummary() => $"From {Departure}, take {TypeInformation} {FlightNumber} to {Destination}. {SeatInformation} {BaggageTicketCounterInformation}";
    }
}
