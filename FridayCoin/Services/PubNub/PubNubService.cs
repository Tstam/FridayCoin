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
            config.PublishKey = "pub-c-caf6d7d4-a49a-4348-be48-ceaf046c0d95";
            config.SecretKey = "sub-c-7b792c92-a61b-11e8-87b0-ca0e85b4e44e";
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
