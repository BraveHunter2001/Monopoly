namespace Monopoly.Entities;

internal abstract class StorageItem
{
    public int Id { get; set; }
    public double Width { get; init; }
    public double Height { get; init; }
    public double Depth { get; init; }
    public virtual double Weight { get; init; }
    public virtual double Volume => Width * Height * Depth;

    protected StorageItem(int id, double width, double height, double depth)
    {
        Id = id;
        Width = width;
        Height = height;
        Depth = depth;
    }

    public override string ToString()
    {
        return $"{Id}|{Width}|{Height}|{Depth}  {Weight}|{Volume}";
    }
}