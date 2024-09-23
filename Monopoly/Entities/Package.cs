namespace Monopoly.Entities;

internal class Package : StorageItem
{
    const int DEFAULT_EXPIRATION_DATE_DAYS = 100;
    public DateOnly ExpirationDate { get; init; }
    public DateOnly ProductionDate { get; init; }

    public Package(int id, double width, double height, double depth, double weight, DateOnly productionDate, DateOnly? expirationDate = null) : base(id, width, height, depth)
    {
        Weight = weight;

        ProductionDate = productionDate;

        ExpirationDate = expirationDate.HasValue
            ? expirationDate.Value
            : productionDate.AddDays(DEFAULT_EXPIRATION_DATE_DAYS);
    }

    public override string ToString()
    {
        return $"[PACKAGE] {base.ToString()} {ExpirationDate}|{ProductionDate}";
    }
}