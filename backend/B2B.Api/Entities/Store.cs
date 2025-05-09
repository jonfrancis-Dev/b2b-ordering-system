using System;

namespace B2B.Api.Entities;

public class Store
{
     public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactEmail { get; set; }

    public string? PhoneNumber { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}

