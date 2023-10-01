using BoardingCards.Applications.Queries;
using BoardingCards.DomainShared.Enums;
using FluentValidation;

namespace BoardingCards.DomainShared.Validators
{
    public class BoardingCardRequestValidator : AbstractValidator<BoardingCardRequest>
    {
        public BoardingCardRequestValidator()
        {
            RuleFor(x => x.Type).NotEqual(TransportType.None);
            RuleFor(x => x.Departure).NotEmpty();
            RuleFor(x => x.Destination).NotEmpty();
            RuleFor(x => x.TransportNumber).NotEmpty()
                .When(x => x.Type == TransportType.Train || x.Type == TransportType.Airplane);
            RuleFor(x => x.SeatNumber).NotEmpty()
                .When(x => x.Type == TransportType.Train || x.Type == TransportType.Airplane);
            RuleFor(x => x.GateNumber).NotEmpty()
                .When(x => x.Type == TransportType.Airplane);
        }
    }
}
