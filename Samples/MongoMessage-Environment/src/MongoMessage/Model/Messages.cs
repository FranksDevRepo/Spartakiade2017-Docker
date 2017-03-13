using System.Collections.Generic;

namespace FP.Spartakiade2017.Docker.Environment.Model
{
    public class Messages
    {
        public Messages()
        {
            Entries = new List<Message>();
        }

        public List<Message> Entries { get; }
    }
}
