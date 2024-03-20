using ISB.Renting.Models.DTO;

namespace ISB.Renting.Business.Interface;

public interface IPropertyManager
{
    PaginatedResultDTO<PropertyDTO> GetAll(PaginatedSearchDTO paginatedSearchDTO);
    PropertyDTO Get(Guid id);
    void Create(List<PropertyDTO> Properties);
    bool Update(List<PropertyDTO> Properties);
    bool Delete(Guid id);
    string Buy(PurchaseDTO puchase);
}
