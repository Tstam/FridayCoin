#region Using directives

using System;
using System.Linq;
using FridayCoin.DbContext;
using FridayCoin.Models;
using FridayCoin.Services.Guid;

#endregion

namespace FridayCoin.Services
{
    public class FridayCoinService
    {
        private readonly FridayCoinContext _context;


        //constructor
        public FridayCoinService(FridayCoinContext context)
        {
            _context = context;
        }

        public CoinWallet GetCoinWalletByGuid(System.Guid guid)
        {
            return GuidService.GuidInstance.WalletExists(guid)
                ? GuidService.GuidInstance._existingWallets.First(a => a.Key == guid).Value
                : null;
        }

        // true = +, false = -
        public bool UpdateBalance(bool transferType, System.Guid guid, int transferAmount)
        {
            try
            {
                var wallet = GetCoinWalletByGuid(guid);
                if (transferType)
                {
                    wallet.WalletBalance += transferAmount;
                    //var walletMem = GuidService.GuidInstance._existingWallets.TryGetValue(wallet.WalletId, out wallet);
                }
                else
                {
                    wallet.WalletBalance -= transferAmount;
                }
                _context.Wallets.Update(wallet);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}