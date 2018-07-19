#region Using directives

using FridayCoin.DbContext;
using FridayCoin.Services.Guid;

#endregion

namespace FridayCoin.Services
{
    public class TransactionService
    {
        private readonly FridayCoinContext _context;
        private readonly FridayCoinService _walletService;

        //constructor
        public TransactionService(FridayCoinContext context, FridayCoinService walletService)
        {
            _context = context;
            _walletService = walletService;
        }

        public bool PerformTransaction(System.Guid fromWallet, System.Guid toWallet, int transferAmount)
        {
            if (CanPerformTransaction(fromWallet, transferAmount) && CanRecieveTransaction(toWallet))
            {
                _walletService.UpdateBalance(false, fromWallet, transferAmount);
                _walletService.UpdateBalance(true, toWallet, transferAmount);
                return true;
            }
            return false;
        }

        private bool CanPerformTransaction(System.Guid fromWallet, int transferAmount)
        {
            var wallet = _walletService.GetCoinWalletByGuid(fromWallet);
            return !wallet.WalletLocked && transferAmount <= wallet.WalletBalance;
        }

        private bool CanRecieveTransaction(System.Guid guid)
        {
            return GuidService.GuidInstance.WalletExists(guid);
        }
    }
}