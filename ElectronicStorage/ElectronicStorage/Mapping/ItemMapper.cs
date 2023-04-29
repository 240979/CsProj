using ElectronicStorage.DTOs;
using ElectronicStorage.Persistence.Models;

namespace ElectronicStorage.Mapping;

public class ItemMapper
{
    public Item MapItemDtoToItem(Item item, ItemDto itemDto)
    {
        item.Description = itemDto.Description;
        item.Name = itemDto.Name;
        item.Price = itemDto.Price;
        item.Quantity = itemDto.Quantity;
        return item;
    }
}