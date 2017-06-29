using CoreGraphics;
using System;

using UIKit;

namespace QuestionRenderPrototype.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.



            //RadioButtonControl RBC = new RadioButtonControl("Display this!");
     //       RBC.Frame = new CGRect(100, 100, 100, 100);
     //       RBC.Opaque = false;
     //       RBC.BackgroundColor = UIColor.Clear;
     //       RBC.Draw(RBC.Frame);

		   //View.AddSubview(RBC);

            CheckBoxGroup RGroup = new CheckBoxGroup(6, 0);
            RGroup.Frame = new CGRect(100, 100, 500, 500);
            RGroup.Opaque = false;
            RGroup.BackgroundColor = UIColor.Clear;
            //RGroup.Draw(RBC.Frame);

            View.AddSubview(RGroup);
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

	   
	}
}

