using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class TaxiBoardingCard : BaseBoardingCard
    {
        public TaxiBoardingCard(string departure, string destination) : base(TransportType.Taxi, departure, destination)
        {
        }
    }
}
