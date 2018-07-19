#region Using directives

using FridayCoin.DbContext;
using FridayCoin.Models;
using FridayCoin.Services.Guid;

#endregion

namespace FridayCoin.Services
{
    public class WalletService
    {
        private readonly FridayCoinContext _context;
        private readonly FridayCoinService _fridayCoinService;

        //constructor
        public WalletService(FridayCoinContext context, FridayCoinService fridayCoinService)
        {
            _context = context;
            _fridayCoinService = fridayCoinService;
        }

        //get balance by id
        public int GetBalanceById(System.Guid guid)
        {
            return GuidService.GuidInstance.WalletExists(guid)
                ? _context.Wallets.Find(guid).WalletBalance
                : 0;
        }

        public System.Guid CreateNewWallet(CoinWallet wallet)
        {
            if (GuidService.GuidInstance.WalletExists(wallet.WalletId))
            {
                return System.Guid.Empty;
            }
            wallet.WalletId = GuidService.GuidInstance.SupplyGuid(wallet);
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }

        // do api methods

        //private update balance
    }
}