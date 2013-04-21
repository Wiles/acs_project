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
            try
            {
                byte[] json = Encoding.ASCII.GetBytes(JsonHelper.Serialize(msg));
                _client.BeginSend(json, 0, json.Length, SocketFlags.None, OnSend, null);
            }
            catch(Exception e)
            {
                _errorCallBack(e);
            }
        }

        public void close()
        {
            if(_client != null)
            {
                _client.Dispose();
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try{
                _client.EndSend(ar);
            }
            catch (Exception e)
            {
                _errorCallBack(e);
            }
        }

        public AsyncClient(EndPoint endPoint, Action<Message> callBack, Action<Exception> errorCallBack)
        {
            try{
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
            catch (Exception e)
            {
                _errorCallBack(e);
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try{
                _client.EndConnect(ar);
            }
            catch (Exception e)
            {
                _errorCallBack(e);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
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
            catch (Exception e)
            {
                _errorCallBack(e);
            }
        }
    }
}
