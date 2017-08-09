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
using ClassLibrary1;

namespace QuestionRenderPrototype.Droid
{
    class CheckboxQuestion: GridLayout, IQuestion 
    {
        GridLayout checkBoxGrid;

        List<CheckBox> checkBoxes = new List<CheckBox>();

        List<Spec> rowSpecs = new List<Spec>();

        Spec rowSpec1 = GridLayout.InvokeSpec(0, GridLayout.Center);
        
        Spec colSpec1 = GridLayout.InvokeSpec(0);

        public static View rootView;

        bool isRequired;

        public CheckboxQuestion(Context context, QuestionStucture stucture, bool required) : base(context)
        {
            rootView = Inflate(context, Resource.Layout.CheckBoxQuestion, this);
            checkBoxGrid = (GridLayout)FindViewById(Resource.Id.CheckBoxGrid);
            setRows(stucture.answers.Count);
            isRequired = required;

            checkBoxGrid.RowCount = stucture.answers.Count + 1;

            for (int i = 0; i < rowSpecs.Count; i++)
            {
                checkBoxGrid.AddView(createNewCheckBox(context,i, stucture.answers[i]), new GridLayout.LayoutParams(rowSpecs.ElementAt(i), colSpec1));
            }

        }

        
        CheckBox createNewCheckBox(Context context, int id)
        {
            CheckBox newCheckBox = new CheckBox(context);
            newCheckBox.Id = id;
            //set click listener
            checkBoxes.Add(newCheckBox);
            return newCheckBox;
        }

        CheckBox createNewCheckBox(Context context, int id, string questionText)
        {
            CheckBox newCheckBox = new CheckBox(context);
            newCheckBox.Id = id;
            newCheckBox.Text = questionText;
            //set click listener
            checkBoxes.Add(newCheckBox);
            return newCheckBox;
        }

        private void setRows(int answers)
        {
            for (int i = 0; i < answers; i++)
            {
                Spec rowspec2 = GridLayout.InvokeSpec(i + 1);
                rowSpecs.Add(rowspec2);
            }
        }

        public List<string> saveAnswers()
        {
            List<string> answers = new List<string>();
            foreach (CheckBox ch in checkBoxes)
            {
                if (ch.Checked)
                {
                    answers.Add(ch.Id.ToString());
                }
            }

            return answers;
        }

        public bool checkIsRequired()
        {
            return isRequired;
        }
    }
}