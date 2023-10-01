namespace BoardingCards.Domain
{
    public class AirportBusBoardingCard : BaseBoardingCard
    {
        public AirportBusBoardingCard(string departure, string destination, string transportNumber, string seatNumber) : base(departure, destination, transportNumber, seatNumber)
        {
        }

        public override string TypeInformation => "the airport bus";
    }
}
