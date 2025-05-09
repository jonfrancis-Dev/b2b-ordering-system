using System;

namespace B2B.Api.Entities;

public class Product
{
    public int Id { get; set; } // PK

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public bool IsActive { get; set; } = true;

    public string? ImageUrl { get; set; }      

    // Foreign key to owning organization
    public int StoreId { get; set; } // FK
    public Store Store{ get; set; } = null!;

    public int CategoryId { get; set; } // FK

    public Category Category { get; set; } = null!;
}