#region Using directives

using System.Collections.Generic;
using FridayCoin.Models;

#endregion

namespace FridayCoin.Services.Guid
{
    public class GuidService
    {
        private static GuidService _guidInstance;

        public readonly Dictionary<System.Guid, CoinWallet> _existingWallets = new Dictionary<System.Guid, CoinWallet>()
            ;

        public static GuidService GuidInstance
        {
            get
            {
                if (_guidInstance == null)
                {
                    _guidInstance = new GuidService();
                }
                return _guidInstance;
            }
        }

        public System.Guid SupplyGuid(CoinWallet wallet)
        {
            if (_existingWallets.ContainsValue(wallet))
            {
                return System.Guid.Empty;
            }
            var a = System.Guid.NewGuid();
            _existingWallets.Add(a, wallet);
            return a;
        }

        public bool WalletExists(System.Guid guid)
        {
            return _existingWallets.ContainsKey(guid);
        }
    }
}