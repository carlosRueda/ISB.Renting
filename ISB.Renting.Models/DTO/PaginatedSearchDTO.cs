using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB.Renting.Models.DTO;

public class PaginatedSearchDTO
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}
