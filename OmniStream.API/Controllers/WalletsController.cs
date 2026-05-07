using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmniStream.API.Data;
using OmniStream.API.Entities;

namespace OmniStream.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController(LedgerContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Wallet>> GetWallets()
        {
            return context.Wallets.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Wallet> GetWallet(Guid id)
        {
            var wallet = context.Wallets.Find(id);

            if (wallet == null) return NotFound();
            
            return wallet;
        }
    }
}
