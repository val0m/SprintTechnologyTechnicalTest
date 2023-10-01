namespace BoardingCards.Domain
{
    public class TrainBoardingCard : BaseBoardingCard
    {
        public TrainBoardingCard(string departure, string destination, string transportNumber, string seatNumber) : base(departure, destination, transportNumber, seatNumber)
        {
        }

        public override string TypeInformation => "train";
    }
}
