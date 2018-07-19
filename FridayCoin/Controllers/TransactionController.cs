#region Using directives

using System;
using FridayCoin.DbContext;
using FridayCoin.Models;
using FridayCoin.Services;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace FridayCoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(FridayCoinContext context)
        {
            var coinService = new FridayCoinService(context);
            _transactionService = new TransactionService(context, coinService);
        }

        //// POST: api/Transfer
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        // PUT: api/Transfer/5
        [HttpPut("{toguid}")]
        public void Put(Guid toguid, [FromBody] Transaction trans)
        {
            _transactionService.PerformTransaction(trans.FromWallet, trans.ToWallet, trans.TransferAmount);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}