using System.Net.Sockets;
using System.Text;

namespace Blowfish
{
    /// <summary>
    /// State used by the sockets
    /// </summary>
    public class StateObject
    {
        // Client  socket.
        public Socket WorkSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder Sb = new StringBuilder();
    }
}
