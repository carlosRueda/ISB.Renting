namespace ISB.Renting.Cross;

public static class Conversor
{
    public static decimal EUR_To_USD(decimal valueInEur) => valueInEur * ValueInUsd;
    public const decimal ValueInUsd = 1.09m;
}
