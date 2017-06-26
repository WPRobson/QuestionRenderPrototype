
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
    class TextQuestion: LinearLayout
    {
        TextView questionTextDisplay;
        EditText anserText;
        public static View rootView;

        public TextQuestion(Context context, string questionText):base(context)
        {
            rootView = Inflate(context, Resource.Layout.TextQuestion, this);
            questionTextDisplay = (TextView)FindViewById(Resource.Id.textView1);
            anserText = (EditText)FindViewById(Resource.Id.TextAnser);

            questionTextDisplay.Text = questionText;
            questionTextDisplay.SetTextColor(Color.White);
        }

    }
}