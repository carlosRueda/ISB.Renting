using ISB.Renting.Models.DTO;

namespace ISB.Renting.Business.Interface;

public interface IDashboardManager
{
    public List<DashboardResultDTO> GetResume();
}
