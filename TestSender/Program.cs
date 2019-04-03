using Furesoft.Signals;
using Furesoft.Signals.Attributes;
using System;
using TestModels;

namespace TestSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = Signal.CreateRecieverChannel("signals.test");

            Signal.CallEvent(channel, new PingArg { Message = "hello world" });
            Signal.CollectShared(channel);

            Console.ReadLine();
        }

        [SharedFunction(0xC0FFEE)]
        private static PingArg Pong(PingArg arg)
        {
            return new PingArg { Message = arg.Message + "/PONG" };
        }
    }

    
}
