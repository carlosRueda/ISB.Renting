using ISB.Renting.Models.DTO;
using ISB.Renting.RentingUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISB.Renting.RentingUI.Controllers;

public class DashboardController : Controller
{
    internal RestClient _client;
    internal readonly IsbSettings _isbSettings;

    public DashboardController(RestClient client, IConfiguration config)
    {
        _client = client;
        _isbSettings = config.GetRequiredSection(nameof(IsbSettings)).Get<IsbSettings>();
    }
    public ActionResult Index()
    {
        var httpResponse = _client.Get(_isbSettings.Get_Dashboard_List_URL());
        var dashboardRecords = _client.GetResponseAsync<List<DashboardResultDTO>>(httpResponse).GetAwaiter().GetResult();
        return View(dashboardRecords);
    }
}
