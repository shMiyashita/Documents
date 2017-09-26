using System;
using UIKit;
using Holomet;

namespace Holomet
{
    public partial class AfterViewController : UIViewController
    {
        UITextField _ipAddressTextField;
        UIButton _uiButton;

        public AfterViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var ipAddressTextField = new UITextField()
            {
                Bounds = new CoreGraphics.CGRect(0, 0, 100, 30),
                Center = new CoreGraphics.CGPoint((float)View.Bounds.Width / 2, (float)View.Bounds.Height / 2),

                BorderStyle = UITextBorderStyle.RoundedRect,
                ClearButtonMode = UITextFieldViewMode.Always,
                Placeholder = "送信する内容",
                KeyboardType = UIKeyboardType.NumberPad
            };
            View.AddSubview(ipAddressTextField);
            this._ipAddressTextField = ipAddressTextField;

            var button = new UIButton(UIButtonType.RoundedRect)
            {
                Bounds = new CoreGraphics.CGRect(0, 0, 200, 30),
                Center = new CoreGraphics.CGPoint((float)View.Bounds.Width / 2, (float)View.Bounds.Height / 2)
            };
            button.SetTitle("送信", UIControlState.Normal);

            //ボタン押下時のイベント処理
            button.TouchUpInside += (sender, args) => {
                sendText sendText = new sendText();
                sendText.sendUDPMessage();
            };
            View.AddSubview(button);
            this._uiButton = button;
        }

        //?
        void DidAppear()
        {

        }

        void Load()
        {

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
