using Microsoft.AspNetCore.Mvc;
using TAC.Person.Interfaces;
using TAC.Person.Models.Dtos;
using TAC.Person.Models.Exceptions;
using TAC.Person.Models.Extensions;

namespace TAC.Person.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly ITaxService _taxService;

    public TaxController(ILogger<PersonController> logger, ITaxService taxService)
    {
        _logger = logger;
        _taxService = taxService;
    }

    // POST /tax
    [HttpPost]
    public async Task<ActionResult> PostAsync(PayPersonTaxDto taxDto)
    {
        var tax = taxDto.AsTax();

        try
        {
            await _taxService.PayAsync(tax);
        }
        catch (PersonNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (TaxNotAddedException ex)
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
