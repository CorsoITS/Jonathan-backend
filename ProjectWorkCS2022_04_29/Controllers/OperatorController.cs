using Microsoft.AspNetCore.Mvc;
using _7_WebApi.Service;
using _7_WebApi.Models;

namespace _7_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OperatorController : ControllerBase
{

    private OperatorService operatorService = new OperatorService();

    [HttpGet]
    public IEnumerable<Operator> GetPeople()
    {
        return operatorService.GetPeople();
    }

    [HttpGet("{id}")]
    public Operator GetPerson(int id)
    {
        return operatorService.GetPerson(id);
    }

    [HttpPost]
    public IActionResult Create(Operator operatore)
    {
        var created = operatorService.Create(operatore);
        if (created)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public IActionResult Update(Operator operatore)
    {
        var updated = operatorService.Update(operatore);
        if (updated)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = operatorService.Delete(id);
        if (deleted)
        {
            return Ok();

        }
        else
        {
            return BadRequest();
        }
    }
}