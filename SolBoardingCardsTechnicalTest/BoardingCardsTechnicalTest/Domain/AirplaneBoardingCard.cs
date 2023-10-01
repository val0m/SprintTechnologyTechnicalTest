namespace BoardingCards.Domain
{
    public class AirplaneBoardingCard : BaseBoardingCard
    {
        public AirplaneBoardingCard(string departure, string destination, string transportNumber, string seatNumber, string gateNumber, string? baggageTicketCounter = null) : base(departure, destination, transportNumber, seatNumber)
        {
            GateNumber = gateNumber;
            BaggageTicketCounter = baggageTicketCounter;
        }

        public string GateNumber { get; init; }
        public string? BaggageTicketCounter { get; init; }

        public override string TypeInformation => "flight";
        private string BaggageTicketCounterInformation => !string.IsNullOrWhiteSpace(BaggageTicketCounter) ? $"Baggage drop at ticket counter {BaggageTicketCounter}." : "Baggage will be automatically transferred from your last leg.";
        public override string SeatInformation => $"Gate {GateNumber}, seat {SeatNumber}.";

        public override string GetSummary() => $"From {Departure}, take {TypeInformation} {TransportNumber} to {Destination}. {SeatInformation} {BaggageTicketCounterInformation}";
    }
}
