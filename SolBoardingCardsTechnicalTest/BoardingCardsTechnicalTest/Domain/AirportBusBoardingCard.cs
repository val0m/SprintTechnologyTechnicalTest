namespace BoardingCards.Domain
{
    public class AirportBusBoardingCard : BaseBoardingCard
    {
        public AirportBusBoardingCard(string departure, string destination, string seatNumber) : base(departure, destination, seatNumber)
        {
        }

        public override string TypeInformation => "the airport bus";
    }
}
