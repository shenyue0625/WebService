using ContosoRose.Models;

namespace ContosoRose.Services;

public static class RoseService
{
    static List<Rose> Roses { get; }
    static int nextId = 3;
    static RoseService()
    {
        Roses = new List<Rose>
        {
            new Rose { Id = 1, Name = "English Rose", IsDryFlower = false },
            new Rose { Id = 2, Name = "Hybrid Tea Rose", IsDryFlower = true }
        };
    }

    public static List<Rose> GetAll() => Roses;

    public static Rose? Get(int id) => Roses.FirstOrDefault(p => p.Id == id);

    public static void Add(Rose Rose)
    {
        Rose.Id = nextId++;
        Roses.Add(Rose);
    }

    public static void Delete(int id)
    {
        var Rose = Get(id);
        if(Rose is null)
            return;

        Roses.Remove(Rose);
    }

    public static void Update(Rose Rose)
    {
        var index = Roses.FindIndex(p => p.Id == Rose.Id);
        if(index == -1)
            return;

        Roses[index] = Rose;
    }
}