using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Applications.Queries
{
    public class BoardingCardRequest
    {
        public TransportType Type { get; init; }
        public required string Departure { get; init; }
        public required string Destination { get; init; }
        public string? SeatNumber { get; set; }
        public string? TransportNumber { get; set; }
        public string? GateNumber { get; set; }
        public string? BaggageTicketCounter { get; set; }
    }
}
