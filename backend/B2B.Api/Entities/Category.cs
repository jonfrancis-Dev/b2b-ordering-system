using System;

namespace B2B.Api.Entities;


public class Category   
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
