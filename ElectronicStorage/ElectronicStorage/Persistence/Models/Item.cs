using System.ComponentModel.DataAnnotations;

namespace ElectronicStorage.Persistence.Models;

public class Item : EntityBase
{
    [MaxLength(100)] 
    public string Name { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }
    public string Description { get; set; }
}