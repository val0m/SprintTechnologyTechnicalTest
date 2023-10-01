namespace BoardingCards.Domain
{
    public class BusBoardingCard : BaseBoardingCard
    {
        public BusBoardingCard(string departure, string destination, string transportNumber, string seatNumber) : base(departure, destination, transportNumber, seatNumber)
        {
        }

        public override string TypeInformation => "the bus";
    }
}
