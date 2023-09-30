namespace BoardingCards.Domain
{
    public class TrainBoardingCard : BaseBoardingCard
    {
        public TrainBoardingCard(string departure, string destination) : base(departure, destination)
        {
        }

        public override string TypeInformation => "train";
    }
}
