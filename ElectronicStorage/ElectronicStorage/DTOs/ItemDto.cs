namespace ElectronicStorage.DTOs;

public class ItemDto
{
    public string Name { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }
    public string Description { get; set; }

    public ItemDto(string name, double price, int quantity, string description)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Description = description;
    }
}