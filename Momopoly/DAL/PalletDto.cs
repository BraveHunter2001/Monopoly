using Monopoly.Entities;

namespace Monopoly.DAL;

internal class PalletDto : StorageItemDto
{
    public List<PackageDto> Packages { get; set; }

    public Pallet ToPallet(int id, ref int packageIdCounter)
    {
        if (Packages?.Count is null or 0)
            return new(id, Width, Height, Depth);

        List<Package> packages = new List<Package>();
        foreach (var package in Packages)
        {
            packages.Add(package.ToPackage(packageIdCounter++));
        }

        return new(id, Width, Height, Depth, packages);
    }
}