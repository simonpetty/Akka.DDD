using System.IO;
using Akka.Actor;
using Domain.Files;

namespace Service.Actors
{
    public class ClientInputActor : TypedActor, IHandle<ClientInputActor.FileUploaded>
    {
        public class FileUploaded
        {
            public string Filename { get; set; }
        }

        public class NewAbideReport
        {
            public string Filename { get; set; }
            public int Row { get; set; }
            public AbideReport Report { get; set; }
        }

        public class EndOfFile
        {
            public string Filename { get; set; }
        }

        public void Handle(FileUploaded msg)
        {
            using (var file = File.OpenRead(msg.Filename))
            using(StreamReader reader = new StreamReader(file))
            {
                int row = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(new [] {','});
                    var report = new AbideReport
                    {
                        TradeId = values[0],
                        ActionType = values[1],
                        OtherStuff = values[2]

                    };

                    Context.Parent.Tell(new NewAbideReport
                    {
                        Filename = msg.Filename,
                        Row = row++,
                        Report = report
                    });
                }
            }

            Context.Parent.Tell(new EndOfFile
            {
                Filename = msg.Filename
            });
        }
    }
}
