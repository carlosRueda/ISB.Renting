using ISB.Renting.Models.DTO;

namespace ISB.Renting.Business.Interface;

public interface IContactManager
{
    PaginatedResultDTO<ContactDTO> GetAll(PaginatedSearchDTO paginatedSearchDTO);
    ContactDTO Get(Guid id);
    void Create(List<ContactDTO> contacts);
    bool Update(List<ContactDTO> contacts);
    bool Delete(Guid id);
}
