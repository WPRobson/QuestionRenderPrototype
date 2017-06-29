using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UIKit;

namespace QuestionRenderPrototype.iOS
{
    [Register("ScratchTicketView"), DesignTimeVisible(true)]
    public class ScratchTicketView : UIView
    {
        CGPath path;
        CGPoint initialPoint;
        CGPoint latestPoint;
        bool startNewPath = false;
        bool radioState = false;


        UIImageView image;



        public ScratchTicketView(IntPtr p)
            : base(p)
        {
            Initialize();
        }

        public ScratchTicketView()
        {
            Initialize();
        }

        void Initialize()
        {
            SetNeedsDisplay(); 
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            image.Image = UIImage.FromBundle("radio2.png");
            radioState = !radioState;
            var touch = touches.AnyObject as UITouch;

            if (touch != null)
            {
                initialPoint = touch.LocationInView(this);
            }
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            var touch = touches.AnyObject as UITouch;

            if (touch != null)
            {
                latestPoint = touch.LocationInView(this);
                SetNeedsDisplay();
            }
        }


        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            startNewPath = true;
        }


        public override void Draw(CGRect rect)
        {
            //base.Draw(rect);

            image = new UIImageView();
            if (!radioState)
            {
                image.Image = UIImage.FromBundle("radio1.png");
            }
            else
            {
                image.Image = UIImage.FromBundle("radio2.png");
            }


            image.Frame = new CGRect(5, 30, 50, 50);
            image.Opaque = true;
            image.BackgroundColor = UIColor.Clear;

   
            UIButton button = UIButton.FromType(UIButtonType.System);
            button.Frame = new CGRect(70, 20, 100, 100);
            button.SetTitle("test", UIControlState.Normal);
            this.AddSubview(image);
            this.AddSubview(button);
           

        }
    }
}
