using BoardingCards.Applications.Queries;
using BoardingCards.Applications.Request;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardingCardsController : ControllerBase
    {
        private readonly ILogger<BoardingCardsController> _logger;
        private readonly IMediator _mediator;
        private readonly IValidator<SummariesBoardingCardsQuery.Request> _summariesBoardingCardsQueryRequestValidator;

        public BoardingCardsController(
            ILogger<BoardingCardsController> logger,
            IMediator mediator,
            IValidator<SummariesBoardingCardsQuery.Request> summariesBoardingCardsQueryRequestValidator)
        {
            _logger = logger;
            _mediator = mediator;
            _summariesBoardingCardsQueryRequestValidator = summariesBoardingCardsQueryRequestValidator;
        }

        [Route("Summary")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<string>>> GetSummariesAsync([FromBody] List<BoardingCardRequest> boardingCardRequests)
        {
            try
            {
                SummariesBoardingCardsQuery.Request request = new(boardingCardRequests);

                ValidationResult validationResult = _summariesBoardingCardsQueryRequestValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
                }

                List<string> summaries = await _mediator.Send(request);

                return Ok(summaries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has been detected on the route {nameof(GetSummariesAsync)}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}