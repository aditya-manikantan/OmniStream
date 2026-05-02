using System;
using Microsoft.EntityFrameworkCore;
using OmniStream.API.Entities;

namespace OmniStream.API.Data;

public class DbInitializer
{
    public static void DbInit(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetService<LedgerContext>()
            ?? throw new InvalidOperationException("Failed to retrieve ledger context");

        SeedData(context);

    }

    private static void SeedData(LedgerContext context)
    {
        context.Database.Migrate();
        
        if (context.Wallets.Any()) return;

        var wallets = new List<Wallet>
        {
            new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_angular_01",
        Currency = "USD",
        Balance = 20000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_angular_02",
        Currency = "USD",
        Balance = 15000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_netcore_01",
        Currency = "EUR",
        Balance = 18000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_netcore_02",
        Currency = "USD",
        Balance = 30000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_react_01",
        Currency = "GBP",
        Balance = 25000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_typescript_01",
        Currency = "USD",
        Balance = 12000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_vscode_01",
        Currency = "USD",
        Balance = 1800m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    },
    new Wallet
    {
        Id = Guid.NewGuid(),
        OwnerId = "user_redis_01",
        Currency = "USD",
        Balance = 25000m,
        LastUpdated = DateTime.UtcNow,
        Version = Guid.NewGuid()
    }
        };

        context.Wallets.AddRange(wallets);

        context.SaveChanges();
    }
}