using Microsoft.AspNetCore.Mvc;
using TAC.Person.Interfaces;
using TAC.Person.Models.Dtos;
using TAC.Person.Models.Exceptions;
using TAC.Person.Models.Extensions;

namespace TAC.Person.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPaymentService _paymentService;

    public PaymentController(ILogger<PersonController> logger, IPaymentService paymentService)
    {
        _logger = logger;
        _paymentService = paymentService;
    }

    // POST /payment
    [HttpPost]
    public async Task<ActionResult> PostAsync(PersonPaymentDto paymentDto)
    {
        var payment = paymentDto.AsPayment();

        try
        {
            await _paymentService.AddAsync(payment);
        }
        catch (PersonNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            throw;
        }

        return NoContent();
    }
}
