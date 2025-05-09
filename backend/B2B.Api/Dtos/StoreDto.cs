using System;

namespace B2B.Api.Dtos;

public class StoreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? ContactEmail { get; set; }
    public string? PhoneNumber { get; set; }
}
