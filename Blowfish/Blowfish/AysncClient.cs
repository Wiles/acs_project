using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Blowfish
{
    public class AsyncClient : IAsyncSocket
    {
        private readonly Socket _client;
        private byte[] _byteData = new byte[1024];
        private readonly Action<Message> _callBack;
        private readonly Action<Exception> _errorCallBack;

        public void Send(Message msg)
        {
            byte[] json = Encoding.ASCII.GetBytes(JsonHelper.Serialize(msg));
            _client.BeginSend(json, 0, json  .Length, SocketFlags.None, OnSend, null);
        }

        private void OnSend(IAsyncResult ar)
        {
            _client.EndSend(ar);
        }

        public AsyncClient(EndPoint endPoint, Action<Message> callBack, Action<Exception> errorCallBack)
        {
            _errorCallBack = errorCallBack;
            _callBack = callBack;

            // Connect to a remote device.
            // Create a TCP/IP socket.
            _client = new Socket(endPoint.AddressFamily,
                                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            _client.BeginConnect(endPoint, OnConnect, _client);
            _byteData = new byte[1024];
            //Start listening to the data asynchronously
            _client.BeginReceive(_byteData,
                                0,
                                _byteData.Length,
                                SocketFlags.None,
                                OnReceive,
                                null);
        }

        private void OnConnect(IAsyncResult ar)
        {
            _client.EndConnect(ar);
        }

        private void OnReceive(IAsyncResult ar)
        {
            _client.EndReceive(ar);
            string json = Encoding.ASCII.GetString(_byteData).TrimEnd('\0');
            var msg = JsonHelper.Deserialize<Message>(json);

            _callBack(msg);

            _byteData = new byte[1024];

            _client.BeginReceive(_byteData,
                0,
                _byteData.Length,
                SocketFlags.None,
                OnReceive,
                null);
        }
    }
}
