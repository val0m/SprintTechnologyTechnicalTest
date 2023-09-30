using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class AirportBusBoardingCard : BaseBoardingCard
    {
        public AirportBusBoardingCard(string departure, string destination, string seatNumber) : base(TransportType.AirportBus, departure, destination, seatNumber)
        {
        }

        public override string TypeInformation => "the airport bus";
    }
}
