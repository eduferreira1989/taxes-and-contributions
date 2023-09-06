using Microsoft.AspNetCore.Mvc;
using TAC.Person.Interfaces;
using TAC.Person.Models.Dtos;
using TAC.Person.Models.Exceptions;
using TAC.Person.Models.Extensions;

namespace TAC.Person.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class ContributionController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IContributionService _contributionService;

    public ContributionController(ILogger<PersonController> logger, IContributionService contributionService)
    {
        _logger = logger;
        _contributionService = contributionService;
    }

    // POST /contribution
    [HttpPost]
    public async Task<ActionResult> PostAsync(PayPersonContributionDto contributionDto)
    {
        var contribution = contributionDto.AsContribution();

        try
        {
            await _contributionService.PayAsync(contribution);
        }
        catch (PersonNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ContributionNotAddedException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            throw;
        }

        return NoContent();
    }
}
