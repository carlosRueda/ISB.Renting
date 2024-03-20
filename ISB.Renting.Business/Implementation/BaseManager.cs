using AutoMapper;
using ISB.Renting.Models.DTO;

namespace ISB.Renting.Business.Implementation;

public class BaseManager
{
    internal readonly IMapper _mapper;
    public BaseManager(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PaginatedResultDTO<TResult> GetPaged<T, TResult>(IQueryable<T> query, PaginatedSearchDTO pagination) where T : class where TResult : class
    {
        var result = new PaginatedResultDTO<TResult> { Pagination = pagination };
        result.Length = query.Count();

        var skip = (result.Pagination.Page - 1) * result.Pagination.Size;
        result.Results = _mapper.Map<List<TResult>>(query.Skip(skip).Take(result.Pagination.Size).ToList());

        return result;
    }
}
