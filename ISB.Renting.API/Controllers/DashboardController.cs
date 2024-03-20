using ISB.Renting.Business.Implementation;
using ISB.Renting.Business.Interface;
using ISB.Renting.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISB.Renting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardManager _dashboardManager;
    public DashboardController(IDashboardManager dashboardManager)
    {
        _dashboardManager = dashboardManager;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_dashboardManager.GetResume());

}
