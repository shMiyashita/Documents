using System;
using UIKit;
using Holomet;

namespace Holomet
{
    public partial class BeforeViewController : UIViewController
    {
        UITextField _ipAddressTextField;
        UIButton _uiButton;

        public BeforeViewController(IntPtr handle) : base(handle)
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
                Placeholder = "対象のhololens",
                KeyboardType = UIKeyboardType.NumberPad
            };
            View.AddSubview(ipAddressTextField);
            this._ipAddressTextField = ipAddressTextField;

            var button = new UIButton(UIButtonType.RoundedRect)
            {
                Bounds = new CoreGraphics.CGRect(0, 0, 200, 30),
                Center = new CoreGraphics.CGPoint((float)View.Bounds.Width / 2, (float)View.Bounds.Height / 2)
            };
            button.SetTitle("接続", UIControlState.Normal);

            //ボタン押下時のイベント処理
            button.TouchUpInside += (sender, args) => {
                sendText connection = new sendText();
                connection.connectHololens();

                //AfterViewControllerの画面に遷移する処理
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
