using System;
using Akka.Actor;
using Domain.ActionTypes;
using Service.Actors;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("DigbyAkka2");

            var actionTypeFactory = new ActionTypeFactory();

            var clientActor = system.ActorOf(Props.Create(() => new ClientActor(actionTypeFactory)), "client1");

            Console.WriteLine("Press any key to process AllTransactionsPassValidation.csv");
            Console.ReadKey();

            clientActor.Tell(new ClientInputActor.FileUploaded
                {
                    Filename = @"c:\Akka\file1.csv"
                });

            Console.WriteLine("Press any key to process AllTransactionsPassValidation2.csv");
            Console.ReadKey();

            clientActor.Tell(new ClientInputActor.FileUploaded
                {
                    Filename = @"c:\Akka\file2.csv"
                });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            system.Shutdown();
            system.AwaitTermination();
        }
    }
}
