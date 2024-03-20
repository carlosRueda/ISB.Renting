namespace ISB.Renting.Models.DTO;

public class DashboardResultDTO
{
    public Guid OwnershipId { get; set; }
    public string PropertyName { get; set; }
    public decimal AskingPrice { get; set; }
    public string AskingPriceFormated => $"EUR {AskingPrice.ToString("C")}";
    public string Owner { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal SoldPriceEur { get; set; }
    public string SoldPriceEurFormated => $"EUR {AskingPrice.ToString("C")}";
    public decimal SoldPriceUsd { get; set; }
    public string SoldPriceUsdFormated => $"USD {AskingPrice.ToString("C")}";
}
