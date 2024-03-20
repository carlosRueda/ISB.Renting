using System.Drawing;

namespace ISB.Renting.Models.DTO;

public class PaginatedResultDTO<T> where T : class
{
    public PaginatedSearchDTO Pagination { get; set; }
    public List<T> Results { get; set; } = new List<T>();
    public int Length { get; set; }
    public int LastPage
    {
        get
        {
            decimal length = Length;
            decimal size = Pagination.Size;
            decimal calculateValue = length / size;
            return calculateValue == 0 ? 1 : (int)Math.Round(calculateValue, MidpointRounding.ToPositiveInfinity);
        }
    }
}
