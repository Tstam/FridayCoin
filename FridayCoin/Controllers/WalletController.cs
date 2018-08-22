#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using FridayCoin.DbContext;
using FridayCoin.Models;
using FridayCoin.Services;
using FridayCoin.Services.Guid;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace FridayCoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly FridayCoinService _coinService;
        private readonly FridayCoinContext _context;
        private readonly TransactionService _transactionService;
        private readonly WalletService _walletService;

        public WalletController(FridayCoinContext context)
        {
            _context = context;
            _coinService = new FridayCoinService(context);
            _transactionService = new TransactionService(context, _coinService);
            _walletService = new WalletService(context, _coinService);
        }

        //GET: api/Wallet
        [HttpGet]
        public List<KeyValuePair<Guid, CoinWallet>> Get()
        {
            return GuidService.GuidInstance._existingWallets.ToList();
        }

        // GET: api/Wallet/5
        [HttpGet("{guid}", Name = "GetBalance")]
        public int Get(Guid guid)
        {
            return _walletService.GetBalanceById(guid);
        }

        // POST: api/Wallet
        [HttpPost]
        public Guid Post([FromBody] CoinWallet wallet)
        {
            //create wallet
            if (GuidService.GuidInstance.WalletExists(wallet.WalletId) || wallet.WalletId == Guid.Empty)
            {
                var a = _walletService.CreateNewWallet(wallet);
                return a;
            }
            return Guid.Empty;
        }
    }
}