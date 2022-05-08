using ContosoRose.Models;
using ContosoRose.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoRose.Controllers;

[ApiController]
[Route("[controller]")]
public class RoseController : ControllerBase
{
    public RoseController()
    {
    }

    [HttpGet]
    public ActionResult<List<Rose>> GetAll() =>
    RoseService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Rose> Get(int id)
    {
        var Rose = RoseService.Get(id);

        if(Rose == null)
            return NotFound();

        return Rose;
    }

    [HttpPost]
    public IActionResult Create(Rose Rose)
    {            
        RoseService.Add(Rose);
        return CreatedAtAction(nameof(Create), new { id = Rose.Id }, Rose);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Rose Rose)
    {
        if (id != Rose.Id)
            return BadRequest();
            
        var existingRose = RoseService.Get(id);
        if(existingRose is null)
            return NotFound();
    
        RoseService.Update(Rose);           
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Rose = RoseService.Get(id);
    
        if (Rose is null)
            return NotFound();
        
        RoseService.Delete(id);
    
        return NoContent();
    }
}