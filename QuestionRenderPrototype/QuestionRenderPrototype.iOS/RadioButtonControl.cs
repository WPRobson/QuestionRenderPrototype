using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using System.ComponentModel;

namespace QuestionRenderPrototype.iOS
{
    [Register("RadioButtonControl"), DesignTimeVisible(true)]
    public class RadioButtonControl : UIView
    {
        CGPath path;
        CGPoint initialPoint;
        CGPoint latestPoint;
        bool startNewPath = false;

        public  bool radioState { get; set; }
        


        UIImageView image;
        UILabel label;
        string labelText;

        public RadioGroup radioGroup = null;
        public int radioGroupID;



        public RadioButtonControl(IntPtr p)
            : base(p)
        {
            Initialize();
        }

        public RadioButtonControl(string _labelText)
        {
            labelText = _labelText;
            Initialize();
            radioState = false;
        }

        public RadioButtonControl(string _labelText, RadioGroup _radioGroup, int groupID)
        {
            radioGroup = _radioGroup;
            radioGroupID = groupID;
            labelText = _labelText;
            Initialize();
        }

    

       

        void Initialize()
        {
            SetNeedsDisplay();
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            if (radioState != true)
            {
                radioState = true;
                radioGroup.setCheckedRadioButton(this.radioGroupID);

            }
           
 
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
           

            image = new UIImageView();
            image.Opaque = false;

            image.Image = null;

            if (radioState == false)
            {
                image.Image = UIImage.FromBundle("radio1.png");
            }
            else
            {
                image.Image = UIImage.FromBundle("radio2.png");
            }


            image.Frame = new CGRect(5, 30, 30, 30);


            label = new UILabel();
            label.Text = labelText;

            label.Frame = new CGRect(50, -5, 100, 100);

            //label.Text = "test";


            this.AddSubview(image);
            this.AddSubview(label);


        }
    }
}