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

namespace QuestionRenderPrototype.Droid
{
    class RadioGroupQuestion : GridLayout
    {
        GridLayout radioGroupGrid;
        TextView questionTextView;

        List<Spec> rowSpecs = new List<Spec>();


        public static View rootView;

        Spec rowSpec1 = GridLayout.InvokeSpec(0, GridLayout.Center);
        //Spec rowSpec2 = GridLayout.InvokeSpec(1, GridLayout.Center);
       Spec colSpec1 = GridLayout.InvokeSpec(0);
        //Spec colSpec2 = GridLayout.InvokeSpec(0);



        public RadioGroupQuestion(Context context, string questionText, int answers) : base(context)
        {
            rootView = Inflate(context, Resource.Layout.RadioGroup, this);

            radioGroupGrid = (GridLayout)FindViewById(Resource.Id.RadioGroupGrid);
            questionTextView = (TextView)FindViewById(Resource.Id.RadioGroupText);

            questionTextView.Text = questionText;
            //rowSpecs.Add(rowSpec1);
            setRows(answers);

            radioGroupGrid.RowCount = answers +1;

            RadioGroup answersRadioGroup = new RadioGroup(context);

            for (int i = 0; i < rowSpecs.Count; i++)
            {

                RadioButton rb = new RadioButton(context);

                rb.SetTextColor(Color.White);
                rb.Text = $"Question {i}";
               
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
    }
}