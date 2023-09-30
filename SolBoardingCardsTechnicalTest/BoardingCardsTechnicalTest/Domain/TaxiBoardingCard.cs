namespace BoardingCards.Domain
{
    public class TaxiBoardingCard : BaseBoardingCard
    {
        public TaxiBoardingCard(string departure, string destination) : base(departure, destination)
        {
        }

        public override string TypeInformation => "the taxi";
    }
}
