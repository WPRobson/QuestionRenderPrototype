using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using System.ComponentModel;
using CoreGraphics;

namespace QuestionRenderPrototype.iOS
{
    [Register("CheckBoxGroupControl"), DesignTimeVisible(true)]
    public class CheckBoxGroup : UIView
    {
        public static List<CheckBoxControl> CheckBoxes = new List<CheckBoxControl>();
        List<string> questions = new List<string>();
        
        int answersCount;
        int yPosition = 50;
        public int previousChecked { get; set; }
        public int checkedRadioButton { get; set; }


        public CheckBoxGroup(IntPtr p) : base(p)
        {
            Initialize();
        }

        public CheckBoxGroup(int answers, int defaultAnswer)
        {

            questions.Add("Fish");
            questions.Add("Potato");
            questions.Add("Legolas");
            questions.Add("Starship Enterprise");
            answersCount = answers;
            previousChecked = -1;
            checkedRadioButton = -1;

            for (int i = 0; i < answers; i++)
            {
                CheckBoxControl check = new CheckBoxControl("Test", this, i);
                CheckBoxes.Add(check);
            }

        }

       




        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            var touch = touches.AnyObject as UITouch;
        }



        void Initialize()
        {
            SetNeedsDisplay();
        }


        public override void Draw(CGRect rect)
        {

            for (int i = 0; i != CheckBoxes.Count; i++)
            {
                CheckBoxes[i].Frame = new CGRect(50, yPosition, 100, 100);
                yPosition = yPosition + 50;
                CheckBoxes[i].Opaque = false;
                CheckBoxes[i].BackgroundColor = UIColor.Clear;
                this.Add(CheckBoxes[i]);
            }
        }

    }
}