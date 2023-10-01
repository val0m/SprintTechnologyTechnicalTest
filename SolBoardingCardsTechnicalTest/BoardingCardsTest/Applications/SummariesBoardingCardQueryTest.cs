using BoardingCards.Applications;
using BoardingCards.Applications.Queries;
using BoardingCards.Applications.Request;
using BoardingCards.DomainShared.Enums;
using BoardingCards.DomainShared.Exceptions;
using BoardingCards.DomainShared.Exceptions.BoardingCard;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoardingCardsTest.Applications
{
    public class SummariesBoardingCardQueryTest
    {
        private readonly SummariesBoardingCardsQuery.Handler _sut;

        public SummariesBoardingCardQueryTest()
        {
            _sut = new(
                new BoardingCardService(),
                new Mock<ILogger<SummariesBoardingCardsQuery.Handler>>().Object
            );
        }

        private List<BoardingCardRequest> boardingCardInputsCorrect = new()
        {
            new() { Type = TransportType.AirportBus, Departure = "Barcelona" , Destination = "Gerona Airport" },
            new() { Type = TransportType.Airplane, Departure = "Gerona Airport" , Destination = "Stockholm", SeatNumber = "3A", GateNumber = "45B", TransportNumber = "SK455", BaggageTicketCounter = "344" },
            new() { Type = TransportType.Train, Departure = "Madrid" , Destination = "Barcelona", TransportNumber = "78A", SeatNumber = "45B" },
            new() { Type = TransportType.Airplane, Departure = "Stockholm" , Destination = "New York JFK", SeatNumber = "7B", GateNumber = "22", TransportNumber = "SK22" },
            new() { Type = TransportType.Bus, Departure = "New York JFK" , Destination = "Boston" },
        };

        [Fact]
        public async void Should_GetSummaries_WhenInputIsCorrect()
        {
            // Arrange
            SummariesBoardingCardsQuery.Request request = new(boardingCardInputsCorrect);

            // Act
            List<string> result = await _sut.Handle(request, cancellationToken: default);

            // Assert
            result.Count.Should().Be(6);
            result[0].Should().Be("Take train 78A from Madrid to Barcelona. Sit in seat 45B.");
            result[1].Should().Be("Take the airport bus from Barcelona to Gerona Airport. No seat assignment.");
            result[2].Should().Be("From Gerona Airport, take flight SK455 to Stockholm. Gate 45B, seat 3A. Baggage drop at ticket counter 344.");
            result[3].Should().Be("From Stockholm, take flight SK22 to New York JFK. Gate 22, seat 7B. Baggage will be automatically transferred from your last leg.");
            result[4].Should().Be("Take the bus from New York JFK to Boston. No seat assignment.");
            result[5].Should().Be("You have arrived at your final destination.");
        }

        [Fact]
        public async void Should_ThrowBoardingCardOrderException_WhenInputIsNotCorrect()
        {
            // Arrange
            BoardingCardRequest boardingCardRequest = boardingCardInputsCorrect.First(x => x.Departure.Equals("Barcelona"));
            boardingCardInputsCorrect.Remove(boardingCardRequest);

            SummariesBoardingCardsQuery.Request request = new(boardingCardInputsCorrect);

            // Act
            Func<Task> act = () => _sut.Handle(request, cancellationToken: default);

            // Assert
            (await act.Should().ThrowAsync<BoardingCardsOrderException>()).WithMessage("It is not possible to determine the next item on boarding cards with that destination : New York JFK");
        }

        [Fact]
        public async void Should_ThrowBoardingCardOrderException_WhenFirstBoardingCardUnknown()
        {
            // Arrange
            BoardingCardRequest boardingCardRequest = new() { Type = TransportType.Taxi, Departure = "New York JFK", Destination = "Madrid" };
            boardingCardInputsCorrect.Add(boardingCardRequest);

            SummariesBoardingCardsQuery.Request request = new(boardingCardInputsCorrect);

            // Act
            Func<Task> act = () => _sut.Handle(request, cancellationToken: default);

            // Assert
            (await act.Should().ThrowAsync<BoardingCardsOrderException>()).WithMessage("It is not possible to determine the first item on boarding cards.");
        }

        [Fact]
        public async void Should_ThrowBoardingCardNotSupportedException_WhenBoardingCardIsUnknown()
        {
            // Arrange
            BoardingCardRequest boardingCardRequest = new() { Type = TransportType.None, Departure = "New York JFK", Destination = "Madrid" };
            boardingCardInputsCorrect.Add(boardingCardRequest);

            SummariesBoardingCardsQuery.Request request = new(boardingCardInputsCorrect);

            // Act
            Func<Task> act = () => _sut.Handle(request, cancellationToken: default);

            // Assert
            (await act.Should().ThrowAsync<BoardingCardNotSupportedException>()).WithMessage("The none transport has not yet been implemented.");
        }
    }
}
