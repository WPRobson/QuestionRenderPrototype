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
    [Register("RadioGroupControl"), DesignTimeVisible(true)]
    public class RadioGroup : UIView
    {
        public static List<RadioButtonControl> radioButtons = new List<RadioButtonControl>();
        List<string> questions = new List<string>();
        
        int answersCount;
        int yPosition = 50;
        public int previousChecked { get; set; }
        public int checkedRadioButton { get; set; }


        public RadioGroup(IntPtr p) : base(p)
        {
            Initialize();
        }

        public RadioGroup(int answers, int defaultAnswer)
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
                RadioButtonControl RBC = new RadioButtonControl(questions[i], this, i);
                radioButtons.Add(RBC);
            }

        }

        public void setCheckedRadioButton(int id)
        {

            previousChecked = checkedRadioButton;
            checkedRadioButton = id;

            

            radioButtons[checkedRadioButton].Draw(radioButtons[checkedRadioButton].Frame);

            if (previousChecked != -1)
            {
                radioButtons[previousChecked].radioState = false;
                radioButtons[previousChecked].Draw(radioButtons[previousChecked].Frame);
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

            for (int i = 0; i != radioButtons.Count; i++)
            {
                radioButtons[i].Frame = new CGRect(50, yPosition, 100, 100);
                yPosition = yPosition + 50;
                radioButtons[i].Opaque = false;
                radioButtons[i].BackgroundColor = UIColor.Clear;
                this.Add(radioButtons[i]);
            }
        }

    }
}