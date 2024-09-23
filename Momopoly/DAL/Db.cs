using Monopoly.Entities;
using System.Text.Json;

namespace Monopoly.DAL;

internal static class Db
{
    public static List<Pallet> GetPallets()
    {
        int PalletIdCounter = 1;
        int PackageIdCounter = 1;

        using StreamReader sr = new StreamReader("./DAL/db.json");

        string json = sr.ReadToEnd();

        List<PalletDto> pallets = JsonSerializer.Deserialize<List<PalletDto>>(json);

        return pallets.ConvertAll(p => p.ToPallet(PalletIdCounter++, ref PackageIdCounter));
    }
}