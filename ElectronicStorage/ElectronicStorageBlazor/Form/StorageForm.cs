using System.ComponentModel.DataAnnotations;

namespace ElectronicStorageBlazor.Form;

public class StorageForm
{
    [Required(ErrorMessage = "Položka je povinná")]
    [StringLength(16, MinimumLength = 3, ErrorMessage = "Špatná délka názvu")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Položka je povinná")]
    [Range(0.1, 9999999.99, ErrorMessage = "Špatná hodnota")]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Položka je povinná")]
    [Range(1, 100000, ErrorMessage = "Špatná hodnota")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Položka je povinná")]
    [StringLength(600, MinimumLength = 3, ErrorMessage = "Špatná délka popisku")]
    public string? Description { get; set; }
    public StorageForm(string name, double price, int quantity, string description)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Description = description;
    }
    public StorageForm()
    {
        Name = null;
        Description = null;
    }
}