﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Blowfish
{
    internal class AsyncServer : IAsyncSocket
    {
        private readonly Socket _serverSocket;
        private readonly byte[] _byteData = new byte[1024];
        private Socket _clientSocket;
        private readonly Action<Message> _callBack;
        private readonly Action<Exception> _exceptionCallBack;

        public AsyncServer(EndPoint localEndPoint, Action<Message> callBack, Action<Exception> errorCallBack)
        {
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

        public void Send(Message msg)
        {
            byte[] json = Encoding.ASCII.GetBytes(JsonHelper.Serialize(msg));
            _clientSocket.BeginSend(json, 0, json.Length, SocketFlags.None, OnSend, null);
        }


        public void OnSend(IAsyncResult ar)
        {
            var client = (Socket)ar.AsyncState;
            if(client != null)
            {
                client.EndSend(ar);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            _clientSocket = _serverSocket.EndAccept(ar);

            _clientSocket.BeginReceive(_byteData, 0, _byteData.Length, SocketFlags.None,
                OnReceive, _clientSocket);
        }

        private void OnReceive(IAsyncResult ar)
        {
            var client = (Socket)ar.AsyncState;
            client.EndReceive(ar);

            //Transform the array of bytes received from the user into an
            //intelligent form of object Data
            var json = Encoding.ASCII.GetString(_byteData).TrimEnd('\0');
            var msg = JsonHelper.Deserialize<Message>(json);

            _callBack(msg);

            client.BeginReceive(_byteData, 0, _byteData.Length, SocketFlags.None, OnReceive, client);
        }
    }
}