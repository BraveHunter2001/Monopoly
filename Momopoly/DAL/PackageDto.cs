using Monopoly.Entities;

namespace Monopoly.DAL;

internal class PackageDto : StorageItemDto
{
    public DateTime? ExpirationDate { get; set; }
    public DateTime ProductionDate { get; set; }

    public Package ToPackage(int id) => new(
        id,
        Width,
        Height,
        Depth,
        Weight,
        DateOnly.FromDateTime(ProductionDate),
        ExpirationDate.HasValue ? DateOnly.FromDateTime(ExpirationDate.Value) : null
    );
}