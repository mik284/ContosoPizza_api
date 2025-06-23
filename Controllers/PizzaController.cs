using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController> _logger;

    public PizzaController(ILogger<PizzaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
        {
            return NotFound(
                new { Message = $"Pizza with ID {id} not found." }
            );
        }
        return pizza;
    }

    [HttpPost(Name = "AddPizza")]
    public ActionResult<Pizza> Add([FromBody] Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpDelete("{id}", Name = "DeletePizza")]
    public ActionResult Delete(int id)
    {
        PizzaService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}", Name = "UpdatePizza")]
    public ActionResult<Pizza> Update(int id, [FromBody] Pizza pizza)
    {
        PizzaService.Update(pizza);
        return pizza;
    }
}