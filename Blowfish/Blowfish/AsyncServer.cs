using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Blowfish
{
    internal class AsyncServer : IAsyncSocket
    {
        private readonly Socket _serverSocket;
        private byte[] _byteData = new byte[1024];
        private Socket _clientSocket;
        private readonly Action<Message> _callBack;
        private readonly Action<Exception> _exceptionCallBack;

        public AsyncServer(EndPoint localEndPoint, Action<Message> callBack, Action<Exception> errorCallBack)
        {
            try{
                _exceptionCallBack = errorCallBack;
                _callBack = callBack;
                //We are using TCP sockets
                _serverSocket = new Socket(localEndPoint.AddressFamily,
                                          SocketType.Stream,
                                          ProtocolType.Tcp);
                _serverSocket.Bind(localEndPoint);
                _serverSocket.Listen(4);

                //Accept the incoming clients
                _serverSocket.BeginAccept(OnAccept, null);
            }
            catch(Exception e)
            {
                _exceptionCallBack(e);
            }
        }

        public void Send(Message msg)
        {
            try{
                byte[] json = Encoding.ASCII.GetBytes(JsonHelper.Serialize(msg));
                _clientSocket.BeginSend(json, 0, json.Length, SocketFlags.None, OnSend, null);
            
            }
            catch(Exception e)
            {
                _exceptionCallBack(e);
            }
        }


        public void OnSend(IAsyncResult ar)
        {
            try{
                var client = (Socket)ar.AsyncState;
                if(client != null)
                {
                    client.EndSend(ar);
                }
            }
            catch (Exception e)
            {
                _exceptionCallBack(e);
            }

        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                _clientSocket = _serverSocket.EndAccept(ar);
                _byteData = new Byte[1024];
                _clientSocket.BeginReceive(_byteData, 0, _byteData.Length, SocketFlags.None,
                    OnReceive, _clientSocket);
            }
            catch (Exception e)
            {
                _exceptionCallBack(e);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                var client = (Socket)ar.AsyncState;
                client.EndReceive(ar);

                //Transform the array of bytes received from the user into an
                //intelligent form of object Data
                var json = Encoding.ASCII.GetString(_byteData).TrimEnd('\0');
                var msg = JsonHelper.Deserialize<Message>(json);

                _callBack(msg);

                _byteData = new Byte[1024];
                client.BeginReceive(_byteData, 0, _byteData.Length, SocketFlags.None, OnReceive, client);
            }
            catch (Exception e)
            {
                _exceptionCallBack(e);
            }
        }
    }
}
