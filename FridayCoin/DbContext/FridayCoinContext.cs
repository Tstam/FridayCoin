#region Using directives

using FridayCoin.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace FridayCoin.DbContext
{
    public class FridayCoinContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FridayCoinContext(DbContextOptions<FridayCoinContext> options)
            : base(options)
        {
        }

        public DbSet<CoinWallet> Wallets { get; set; }
    }
}