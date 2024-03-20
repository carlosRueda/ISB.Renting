using AutoMapper;
using ISB.Renting.Business.Interface;
using ISB.Renting.Data.Interface;
using ISB.Renting.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ISB.Renting.Business.Implementation;

public class DashboardManager : BaseManager, IDashboardManager
{
    private readonly IUnitOfWork _unitOfWork;
    public DashboardManager(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper)
    {
        _unitOfWork = unitOfWork;
    }

    public List<DashboardResultDTO> GetResume()
    {
        var ownerships = _unitOfWork.Ownership
            .GetAll(x => x.Include(r => r.Contact).Include(p=>p.Property)).ToList();

        return _mapper.Map<List<DashboardResultDTO>>(ownerships).OrderByDescending(x=>x.DateOfPurchase).ToList();
    }
}
