#region Using directives

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace FridayCoin.Models
{
    public class CoinWallet
    {
        // Account Identifier - future guid? 
        [Key]
        public Guid WalletId { get; set; }

        public int WalletBalance { get; set; }

        public bool WalletLocked { get; set; }
    }
}