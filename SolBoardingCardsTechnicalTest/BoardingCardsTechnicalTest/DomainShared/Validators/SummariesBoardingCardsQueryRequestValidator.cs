using BoardingCards.Applications.Request;
using FluentValidation;

namespace BoardingCards.DomainShared.Validators
{
    public class SummariesBoardingCardsQueryRequestValidator : AbstractValidator<SummariesBoardingCardsQuery.Request>
    {
        public SummariesBoardingCardsQueryRequestValidator()
        {
            RuleForEach(x => x.BoardingCardRequest).SetValidator(new  BoardingCardRequestValidator());
        }
    }
}