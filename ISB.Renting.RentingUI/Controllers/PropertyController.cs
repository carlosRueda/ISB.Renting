using ISB.Renting.Models.DTO;
using ISB.Renting.RentingUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISB.Renting.RentingUI.Controllers;

[Route("[controller]")]
public class PropertyController : Controller
{
    internal RestClient _client;
    internal readonly IsbSettings _isbSettings;

    public PropertyController(RestClient client, IConfiguration config)
    {
        _client = client;
        _isbSettings = config.GetRequiredSection(nameof(IsbSettings)).Get<IsbSettings>();
    }

    [HttpGet("{page}/{size}")]
    public ActionResult Index([FromRoute] int page = 1, int size = 50)
    {
        var httpResponse = _client.Get(_isbSettings.Get_Properties_List_URL(page, size));
        var result = _client.GetResponseAsync<PaginatedResultDTO<PropertyDTO>>(httpResponse).GetAwaiter().GetResult();
        return View(result);
    }

    [HttpGet("Create")]
    public ActionResult Create()
    {
        return View(new PropertyDTO());
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public ActionResult Create([FromForm] PropertyDTO property)
    {
        var httpResponse = _client.Post(new List<PropertyDTO>() { property }, _isbSettings.Get_Properties_URL());

        return RedirectToAction(nameof(Index), new { page = 1, size = 50 });
    }

    [HttpGet("Edit/{id}")]
    public ActionResult Edit(Guid id)
    {
        var httpResponse = _client.Get(_isbSettings.Get_Properties_WithId_URL(id));
        var result = _client.GetResponseAsync<PropertyDTO>(httpResponse).GetAwaiter().GetResult();
        return View(result);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, [FromForm] PropertyDTO property)
    {
        property.Id = id;
        var httpResponse = _client.Put(new List<PropertyDTO>() { property }, _isbSettings.Get_Properties_URL());

        return RedirectToAction(nameof(Index), new { page = 1, size = 50 });
    }

    [HttpGet("Delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        var httpResponse = _client.Delete(_isbSettings.Get_Properties_WithId_URL(id));
        return RedirectToAction(nameof(Index), new { page = 1, size = 50 });
    }

    [HttpGet("Buy/{id}")]
    public ActionResult Buy(Guid id)
    {
        var httpResponse = _client.Get(_isbSettings.Get_Properties_WithId_URL(id));
        var result = _client.GetResponseAsync<PropertyDTO>(httpResponse).GetAwaiter().GetResult();

        var httpResponse2 = _client.Get(_isbSettings.Get_Contacts_List_URL(1,1000));
        var contactsResult = _client.GetResponseAsync<PaginatedResultDTO< ContactDTO>>(httpResponse2).GetAwaiter().GetResult();
        
        ViewBag.Contacts = contactsResult.Results;
        return View(new PurchaseDTO()
        {
            PropertyId = id,
            Price = result.Price,
        });
    }

    [HttpPost("Buy/{id}")]
    [ValidateAntiForgeryToken]
    public ActionResult Buy(Guid id, [FromForm] PurchaseDTO purchase)
    {
        purchase.PropertyId = id;
        var httpResponse = _client.Post(purchase, _isbSettings.Get_Properties_Buy_URL());

        return RedirectToAction(nameof(Index), "Dashboard", new { page = 1, size = 50 });
    }

}
