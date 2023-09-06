using Microsoft.AspNetCore.Mvc;
using TAC.Person.Interfaces;
using TAC.Person.Models.Dtos;
using TAC.Person.Models.Exceptions;
using TAC.Person.Models.Extensions;

namespace TAC.Person.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    // GET /person
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPersonDto>>> GetAsync()
    {
        var personList = await _personService.GetAllAsync();
        var personListDto = personList.Select(p => p.AsDto());

        return Ok(personListDto);
    }

    // GET /person/{id}
    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<ActionResult<ReadPersonDto>> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        var person = await _personService.GetAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person.AsDto());
    }

    // POST /person
    [HttpPost]
    public async Task<ActionResult> PostAsync(CreatePersonDto createPersonDto)
    {
        var person = createPersonDto.AsPerson();

        try
        {
            await _personService.CreateAsync(person);
        }
        catch (PersonAlreadyAddedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            throw;
        }
        var createdPersonData = await _personService.GetAllAsync(p => p.Name == person.Name && p.DateOfBirth == person.DateOfBirth);
        var createdPerson = createdPersonData.First().AsDto();

        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdPerson.Id }, createdPerson);
    }

    // PUT /person/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> PutAsync(Guid id, UpdatePersonDto updatePersonDto)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        var person = updatePersonDto.AsPerson();

        try
        {
            await _personService.UpdateAsync(id, person);
        }
        catch (PersonNotFoundException)
        {
            return NotFound();
        }
        catch
        {
            throw;
        }

        return NoContent();
    }

    // DELETE /person/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        try
        {
            await _personService.DeleteAsync(id);
        }
        catch (PersonNotFoundException)
        {
            return NotFound();
        }
        catch
        {
            throw;
        }

        return NoContent();
    }
}
