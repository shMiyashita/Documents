using System;
using CoreGraphics;
using AssetsLibrary;
using UIKit;
using Foundation;
using CoreImage;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ColorControl {

    public class ImageViewController : UIViewController {
        
        UIButton sendButton;
        UITextField textField;
        
        public string api = "http://127.0.0.1:10080/api/holographic/input/keyboard/text?text=";
        
        private String HololensName()
        {
            if (ipAddress == "192.168.1.1")
            {
                return "hololens1";
            }
            else return "unKnown";
        }

        public override void ViewDidLoad ()
        {
            //タイトル部
            base.ViewDidLoad ();
            devName = HololensName();
            Title = "Send Text To Hololens @" + devName;
            View.BackgroundColor = UIColor.White;

            //フォーム部
            textField = new UITextField(new CGRect(10, 100, 300, 40))
            {
                BorderStyle = UITextBorderStyle.RoundedRect, //枠線
                ClearButtonMode = UITextFieldViewMode.Always
            };

            sendButton = UIButton.FromType(UIButtonType.RoundedRect);
            sendButton.Frame = new CGRect(10, 150, 90, 40);
            sendButton.SetTitle("Send Text", UIControlState.Normal);

            sendButton.TouchUpInside += (sender, e) =>
            {
                WebRequest.Create(api + textField.Text);
            };

            View.Add (textField);
            View.Add (sendButton);
            
        }

        //sendText
        public void doSend()
        {
            int localPort = 1234;

            UdpClient client = new UdpClient(localPort);

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.180.112"), 5678);

            byte[] msg = Encoding.ASCII.GetBytes("Hello, world\n");

            try
            {
                client.Send(msg, msg.Length, remoteEP);
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
