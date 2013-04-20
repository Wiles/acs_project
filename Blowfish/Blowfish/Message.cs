using System.Runtime.Serialization;

namespace Blowfish
{

 

    [DataContract]
    public class Message
    {
        public Message(string user, bool encrypted, string text)
        {
            User = user;
            Encrypted = encrypted;
            Text = text;
        }

        [DataMember(Name = "user", IsRequired = true)]
        public string User { get; set; }

        [DataMember(Name = "encyrpted", IsRequired = true)]
        public bool Encrypted { get; set; }


        [DataMember(Name = "text", IsRequired = true)]
        public string Text { get; set; }
    }
}
