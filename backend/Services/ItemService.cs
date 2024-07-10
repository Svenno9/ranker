using backend.DTOs;
using backend.Model;

namespace  backend.Services;
public static class ItemService
{
    private static List<Item> Items { get; }

    static ItemService()
    {
        var i1 = 
        Items = new List<Item>
        {
            new Item
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Title = "Akira"
            },
            new Item
            {
                Id = new Guid(),
                Title = "\"Ghost in the shell\""
            }
        };
    }

    public static List<Item> GetAll() => Items;

    public static Item? Get(Guid id) => Items.FirstOrDefault(i => i.Id == id);

    public static Item Add(CreateItemDto itemDto)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Title = itemDto.Title,
            Rank = itemDto.Rank,
            Score = itemDto.Score
        };
        
        Items.Add(item);
        return item;
    }

    public static void Delete(Guid id)
    {
        var item = Get(id);
        if(item is null)
            return;

        Items.Remove(item);
    }

    public static void Update(Item item)
    {
        var index = Items.FindIndex(i => i.Id == item.Id);
        if(index == -1)
            return;

        Items[index] = item;
    }
}