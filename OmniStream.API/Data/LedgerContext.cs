using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using OmniStream.API.Entities;

namespace OmniStream.API.Data;

public class LedgerContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Wallet> Wallets { get; set; }
}
