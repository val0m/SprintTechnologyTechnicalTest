using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class BusBoardingCard : BaseBoardingCard
    {
        public BusBoardingCard(string departure, string destination, string seatNumber) : base(TransportType.Bus, departure, destination, seatNumber)
        {
        }

        public override string TypeInformation => "the bus";
    }
}
