using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Foundation;
using UIKit;

namespace Holomet
{
    class sendText
    {
        UdpClient udpClient = new UdpClient();
        string LOCAL_HOST = "127.0.0.1";
        const string REMOTE_HOST = "192.168.180.112";
        const int port = 3333;
        IPEndPoint ipEndPoint = new IPEndPoint(REMOTE_HOST.LongCount(), port);
        const String sendMessage = "test";

        //public NSObject GetObject()
        //{
        //    NSObject textObject;//画面の要素どうやってとってくる？
        //    return textObject;
        //}

        public void connectHololens()
        {
            udpClient.Connect(ipEndPoint);
        }

        public void sendUDPMessage()
        {
            var data = Encoding.UTF8.GetBytes(sendMessage);
            udpClient.Connect(ipEndPoint);
            udpClient.Send(data, port);
        }

        public void closeConnect()
        {
            udpClient.Close();
        }


    }
}
