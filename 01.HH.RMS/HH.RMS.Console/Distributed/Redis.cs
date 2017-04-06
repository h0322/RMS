using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.Distributed
{
    public class Redis
    {
        static readonly ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost");
        static readonly string redisKey = "Wechat.Message.Received";
        static readonly string redisChannel = "Channel.Wechat.Message.Received";
                                               
        public Redis()
        {
            //var sub = connection.GetSubscriber();

            //string reader = "Start";
            //while (reader != "exit")
            //{
            //    reader = System.Console.ReadLine();
            //    sub.Publish(redisChannel, reader);
            //}
            //sub.Publish(redisChannel, 10);
            //sub.Publish(redisChannel, 8);
            //sub.Publish(redisChannel, 6);
            //sub.Publish(redisChannel, 4);
            //sub.Publish(redisChannel, 2);
            //sub.Publish(redisChannel, 1);
            MessageService message = new MessageService();
            message.Pub<int>(1);
            message.Pub<int>(2);
            message.Pub<int>(3);
            message.Pub<int>(4);
            System.Console.ReadLine();
        }

    }
    public class MessageService
    {
        static readonly string redisKey = "Wechat.Message.Received";
        static readonly string redisChannel = "Channel.Wechat.Message.Received";
        public void Pub<T>(T value)
        {
            using (ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost"))
            {
                var sub = connection.GetSubscriber();
                var db = connection.GetDatabase();
                db.ListLeftPush(redisKey, JsonConvert.SerializeObject(value), flags: CommandFlags.FireAndForget);
                sub.Publish(redisChannel, "");
            }
        }
    }
}
