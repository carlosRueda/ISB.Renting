using ISB.Renting.Business.Interface;
using ISB.Renting.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISB.Renting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactManager _contactManager;
    public ContactController(IContactManager contactManager)
    {
        _contactManager = contactManager;
    }

    // GET api/<ContactController>/1/10
    [HttpGet("{page}/{size}")]
    public IActionResult Get(int page, int size) => Ok(_contactManager.GetAll(new PaginatedSearchDTO() { Page = page, Size = size }));

    // GET api/<ContactController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => Ok(_contactManager.Get(id));

    // POST api/<ContactController>
    [HttpPost]
    public IActionResult Post(List<ContactDTO> contacts)
    {
        _contactManager.Create(contacts);
        return Ok();
    }

    // PUT api/<ContactController>
    [HttpPut]
    public IActionResult Put(List<ContactDTO> contacts)
    {
        var allUpdated = _contactManager.Update(contacts);
        return allUpdated ? Ok() : BadRequest();
    }

    // DELETE api/<ContactController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _contactManager.Delete(id);
        return deleted ? Ok() : BadRequest();
    }
}
