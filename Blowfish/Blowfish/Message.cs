using System.Runtime.Serialization;

namespace Blowfish
{
    /// <summary>
    /// Chat message
    /// </summary>
    [DataContract]
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="user">The sender</param>
        /// <param name="encrypted">if set to <c>true</c> [encrypted].</param>
        /// <param name="text">The text.</param>
        public Message(string user, bool encrypted, string text)
        {
            User = user;
            Encrypted = encrypted;
            Text = text;
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [DataMember(Name = "user", IsRequired = true)]
        public string User { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Message"/> is encrypted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if encrypted; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "encrypted", IsRequired = true)]
        public bool Encrypted { get; set; }


        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [DataMember(Name = "text", IsRequired = true)]
        public string Text { get; set; }
    }
}
