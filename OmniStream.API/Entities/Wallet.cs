using System;

namespace OmniStream.API.Entities;

public class Wallet
{
    public Guid Id { get; set; }
    public required string OwnerId { get; set; }
    public required string Currency { get; set; }
    public decimal Balance { get; set; }   
    public DateTime LastUpdated { get; set; }
    public Guid Version { get; set; }
}
