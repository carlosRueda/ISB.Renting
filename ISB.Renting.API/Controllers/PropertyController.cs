using ISB.Renting.Business.Implementation;
using ISB.Renting.Business.Interface;
using ISB.Renting.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISB.Renting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyManager _PropertyManager;
    public PropertyController(IPropertyManager PropertyManager)
    {
        _PropertyManager = PropertyManager;
    }

    // GET api/<PropertyController>/1/10
    [HttpGet("{page}/{size}")]
    public IActionResult Get(int page, int size) => Ok(_PropertyManager.GetAll(new PaginatedSearchDTO() { Page = page, Size = size }));

    // GET api/<PropertyController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => Ok(_PropertyManager.Get(id));

    // POST api/<PropertyController>
    [HttpPost]
    public IActionResult Post(List<PropertyDTO> Propertys)
    {
        _PropertyManager.Create(Propertys);
        return Ok();
    }

    // POST api/<ContactController>
    [HttpPost("Buy")]
    public IActionResult BuyProperty(PurchaseDTO puchase)
    {
        var message = _PropertyManager.Buy(puchase);
        return Ok(message);
    }

    // PUT api/<PropertyController>
    [HttpPut]
    public IActionResult Put(List<PropertyDTO> Propertys)
    {
        var allUpdated = _PropertyManager.Update(Propertys);
        return allUpdated ? Ok() : BadRequest();
    }

    // DELETE api/<PropertyController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _PropertyManager.Delete(id);
        return deleted ? Ok() : BadRequest();
    }
}
