using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmniStream.API.Data;
using OmniStream.API.Entities;

namespace OmniStream.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController(LedgerContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Wallet>>> GetWallets()
        {
            return await context.Wallets.ToListAsync();
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<Wallet>> GetWallet(Guid id)
        {
            var wallet = await context.Wallets.FindAsync(id);

            if (wallet == null) return NotFound();

            return wallet;
        }
    }
}
