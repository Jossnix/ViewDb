using System.Text.Json.Serialization;

namespace ViewDb.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Guid Category_Id { get; set; }
    
    public Guid Salesman_Id { get; set; }
    
    public bool Sold { get; set; }
}