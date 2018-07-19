#region Using directives

using System;

#endregion

namespace FridayCoin.Models
{
    public class Transaction
    {
        public Guid FromWallet { get; set; }
        public Guid ToWallet { get; set; }
        public int TransferAmount { get; set; }
    }
}