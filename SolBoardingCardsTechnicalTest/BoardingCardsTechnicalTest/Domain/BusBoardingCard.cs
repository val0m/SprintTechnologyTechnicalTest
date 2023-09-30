using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class BusBoardingCard : BaseBoardingCard
    {
        public BusBoardingCard(string departure, string destination, string seat) : base(TransportType.Bus, departure, destination, seat)
        {
        }
    }
}
