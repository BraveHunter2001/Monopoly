using Monopoly.DAL;
using Monopoly.Entities;
using System.Text.Json;

namespace Momopoly;

internal class Program
{
    static void Main(string[] args)
    {
        List<Pallet> pallets = null;
        try
        {
            pallets = Db.GetPallets();
        }
        catch (Exception e) when (e is JsonException || e is ArgumentException)
        {
            Console.WriteLine($"Failed:\n{e.Message}");
            return;
        }

        Console.WriteLine("REQUEST 1");
        var request1 = pallets
            .GroupBy(p => p.ExpirationDate)
            .ToDictionary(
                g => g.Key,
                g => g.OrderBy(p => p.Weight).ToList()
            );

        foreach (var rKey in request1.Keys.OrderDescending())
        {
            Console.WriteLine(rKey);
            foreach (var pallet in request1[rKey])
                Console.WriteLine(pallet);

            Console.WriteLine();
        }

        Console.WriteLine("REQUEST 2");

        var request2 = pallets.OrderByDescending(p => p.ExpirationDate)
            .Take(3)
            .OrderBy(p => p.Volume)
            .ToList();

        foreach (var pallet in request2)
        {
            Console.WriteLine(pallet);
        }
    }
}