using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace QuestionRenderPrototype.iOS
{
    class RadioButtonView : UIViewController
    {

        public RadioButtonView()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIImageView radioImage = new UIImageView();

            radioImage.Frame = new CoreGraphics.CGRect(20, 200, 280, 44);
            

            UITextView RadioLabel = new UITextView();
        }
    }
}