using ISB.Renting.Models.DTO;
using ISB.Renting.RentingUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISB.Renting.RentingUI.Controllers;

[Route("[controller]")]
public class ContactController : Controller
{
    internal RestClient _client;
    internal readonly IsbSettings _isbSettings;

    public ContactController(RestClient client, IConfiguration config)
    {
        _client = client;
        _isbSettings = config.GetRequiredSection(nameof(IsbSettings)).Get<IsbSettings>();
    }

    [HttpGet("{page}/{size}")]
    public ActionResult Index([FromRoute] int page = 1, int size = 50)
    {
        var httpResponse = _client.Get(_isbSettings.Get_Contacts_List_URL(page, size));
        var result = _client.GetResponseAsync<PaginatedResultDTO<ContactDTO>>(httpResponse).GetAwaiter().GetResult();
        return View(result);
    }

    [HttpGet("Create")]
    public ActionResult Create()
    {
        return View(new ContactDTO());
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public ActionResult Create([FromForm] ContactDTO contact)
    {
        var httpResponse = _client.Post(new List<ContactDTO>() { contact }, _isbSettings.Get_Contacts_URL());

        return RedirectToAction(nameof(Index), new { page = 1, size = 50 });
    }

    [HttpGet("Edit/{id}")]
    public ActionResult Edit(Guid id)
    {
        var httpResponse = _client.Get(_isbSettings.Get_Contacts_WithId_URL(id));
        var result = _client.GetResponseAsync<ContactDTO>(httpResponse).GetAwaiter().GetResult();
        return View(result);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, [FromForm] ContactDTO contact)
    {
        contact.Id = id;
        var httpResponse = _client.Put(new List<ContactDTO>() { contact }, _isbSettings.Get_Contacts_URL());

        return RedirectToAction(nameof(Index), new { page = 1, size = 50 });
    }

    [HttpGet("Delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        var httpResponse = _client.Delete(_isbSettings.Get_Contacts_WithId_URL(id));
        return RedirectToAction(nameof(Index), new { page = 1, size = 50 });
    }

}
