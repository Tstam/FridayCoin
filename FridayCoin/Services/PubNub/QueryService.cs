using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FridayCoin.Models;

namespace FridayCoin.Services.PubNub
{
    public class QueryService
    {
        private static QueryService _queryServices = new QueryService();

        public static QueryService QueryServices
        {
            get
            {
                if (_queryServices == null)
                {
                    _queryServices = new QueryService();
                }
                return _queryServices;
            }
        }

        //private async Task<Dictionary<string, object>> GetTransactionAndPublish(Transaction trans, string channel,
        //    string uuid)
        //{
        //    // to do: recieve transaction information -> transfer coins -> if succeeded calculate new balances -> else abort
        //}



    }
}
