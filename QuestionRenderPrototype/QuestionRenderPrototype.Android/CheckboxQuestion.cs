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

namespace QuestionRenderPrototype.Droid
{
    class CheckboxQuestion: GridLayout
    {
        GridLayout checkBoxGrid;

        List<Spec> rowSpecs = new List<Spec>();

        Spec rowSpec1 = GridLayout.InvokeSpec(0, GridLayout.Center);
        
        Spec colSpec1 = GridLayout.InvokeSpec(0);

        public static View rootView;

        public CheckboxQuestion(Context context, int answers, string questionText) : base(context)
        {
            rootView = Inflate(context, Resource.Layout.CheckBoxQuestion, this);

            checkBoxGrid = (GridLayout)FindViewById(Resource.Id.CheckBoxGrid);
            setRows(answers);

            checkBoxGrid.RowCount = answers + 1;

            for (int i = 0; i < rowSpecs.Count; i++)
            {

                checkBoxGrid.AddView(new CheckBox(context), new GridLayout.LayoutParams(rowSpecs.ElementAt(i), colSpec1));

            }

        }

        private void setRows(int answers)
        {
            for (int i = 0; i < answers; i++)
            {
                Spec rowspec2 = GridLayout.InvokeSpec(i + 1);
                rowSpecs.Add(rowspec2);
            }
        }




    }
}