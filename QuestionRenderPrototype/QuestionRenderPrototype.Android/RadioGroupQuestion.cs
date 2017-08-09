using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using ClassLibrary1;

namespace QuestionRenderPrototype.Droid
{
    class RadioGroupQuestion : GridLayout, IQuestion
    {
        GridLayout radioGroupGrid;
        TextView questionTextView;

        List<Spec> rowSpecs = new List<Spec>();
        bool isrequired;

        public static View rootView;

        Spec rowSpec1 = GridLayout.InvokeSpec(0, GridLayout.Center);
        //Spec rowSpec2 = GridLayout.InvokeSpec(1, GridLayout.Center);
       Spec colSpec1 = GridLayout.InvokeSpec(0);
        //Spec colSpec2 = GridLayout.InvokeSpec(0);
        RadioGroup answersRadioGroup;



        public RadioGroupQuestion(Context context, QuestionStucture stucture, bool required) : base(context)
        {
            isrequired = required;
            rootView = Inflate(context, Resource.Layout.RadioGroup, this);

            radioGroupGrid = (GridLayout)FindViewById(Resource.Id.RadioGroupGrid);
            questionTextView = (TextView)FindViewById(Resource.Id.RadioGroupText);

            questionTextView.Text = stucture.questionHeading;
            //rowSpecs.Add(rowSpec1);
            setRows(stucture.answers.Count);

            radioGroupGrid.RowCount = stucture.answers.Count +1;

            answersRadioGroup = new RadioGroup(context);

            for (int i = 0; i < rowSpecs.Count; i++)
            {
                RadioButton rb = new RadioButton(context);
                rb.SetTextColor(Color.White);
                rb.Text = stucture.answers[i];
                rb.Id = i;
                answersRadioGroup.AddView(rb, new GridLayout.LayoutParams(rowSpecs.ElementAt(i), colSpec1));
               // radioGroupGrid.AddView(answersRadioGroup.GetChildAt(i), new GridLayout.LayoutParams(rowSpecs.ElementAt(i), colSpec1));
            }
            radioGroupGrid.AddView(answersRadioGroup);
            

        }

        private void setRows(int answers)
        {
            for (int i = 0; i < answers; i++)
            {
                Spec rowspec2 = GridLayout.InvokeSpec(i+1);
                rowSpecs.Add(rowspec2);
            }
        }

        public List<string> saveAnswers()
        {
            List<string> answer = new List<string>();

            answer.Add(answersRadioGroup.CheckedRadioButtonId.ToString());
            return answer;
        }

        public bool checkIsRequired()
        {
            throw new NotImplementedException();
        }
    }
}