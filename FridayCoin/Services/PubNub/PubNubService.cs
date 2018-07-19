using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PubnubApi;

namespace FridayCoin.Services.PubNub
{
    public class PubNubService
    {
        PNConfiguration config = new PNConfiguration();
        private readonly Pubnub _pusher;

        private static PubNubService _instance;

        //subscribe to channel: transactions


        private PubNubService()
        {
            config.PublishKey = "pub-c-6a3cfcb3-2c90-48e8-80b8-f5d309a9b31f";
            config.SecretKey = "sub-c-9b223526-8b58-11e8-85ee-866938e9174c";
            config.Uuid = "FirstCoin-MASTER?";
            _pusher = new Pubnub(config);
        }

        public static PubNubService Instance => _instance ?? (_instance = new PubNubService());

        public void PublishData(Dictionary<string, object> dic)
        {
            try
            {
                _pusher.Publish()
                    .Message(dic)
                    .Channel(dic.Values.FirstOrDefault()?.ToString())
                    .Async(new PNPublishResultExt(
                        (result, status) =>
                        {
                            //Console.WriteLine("Published to: " + dic.Values.FirstOrDefault()?.ToString());
                            //Console.WriteLine("status: " + status.StatusCode.ToString());
                        }));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


    }
}
