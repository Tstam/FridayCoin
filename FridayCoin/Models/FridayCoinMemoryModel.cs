#region Using directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace FridayCoin.Models
{
    public class FridayCoinMemoryModel
    {
        [Key]
        public CoinWallet[] Wallets { get; set; }

        public int TotalNumberOfCoins { get; set; }
    }
}