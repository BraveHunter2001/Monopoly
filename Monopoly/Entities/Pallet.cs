using System.Text;

namespace Monopoly.Entities;

internal class Pallet : StorageItem
{
    const double OWN_PALLET_WEIGHT = 30;

    private List<Package> _packages = new();

    public DateOnly? ExpirationDate => _packages.Count > 0 ? _packages.Min(x => x.ExpirationDate) : null;

    public override double Weight => _packages.Select(x => x.Weight).Sum() + OWN_PALLET_WEIGHT;

    public override double Volume =>
        _packages.Select(x => x.Volume).Sum() + base.Volume;

    public Pallet(int id, double width, double height, double depth) : base(id, width, height, depth)
    {
    }

    public Pallet(int id, double width, double height, double depth, List<Package> packages) : base(id, width, height, depth)
    {
        packages.ForEach(ValidatePackage);

        _packages = packages;
    }

    private void ValidatePackage(Package package)
    {
        if (package.Width > Width || package.Depth > Depth)
            throw new ArgumentException("Package too big for add");
    }

    public override string ToString()
    {
        string palletStr = $"[Pallet] {base.ToString()}  {ExpirationDate}";

        if (_packages.Count == 0) return palletStr;

        StringBuilder sb = new();
        _packages.ForEach(p => sb.AppendLine($"->{p}"));

        return $"{palletStr}:\n{sb}";
    }

    public void Add(Package p)
    {
        ValidatePackage(p);

        _packages.Add(p);
    }
}