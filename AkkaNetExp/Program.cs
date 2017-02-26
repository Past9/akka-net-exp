﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;

namespace AkkaNetExp
{
    public class Greet
    {
        public string Who { get; private set; }
        public Greet(string who)
        {
            Who = who;
        }
    }

    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet => Console.WriteLine($"Hello {greet.Who}"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");

            var greeter = system.ActorOf<GreetingActor>("greeter");
            greeter.Tell(new Greet("World"));

            Console.ReadLine();
        }
    }
}
