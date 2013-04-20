using System.Net;

namespace Blowfish
{
    interface IAsyncSocket
    {
        void Send(Message msg);
    }
}
