
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
    class TextQuestion: LinearLayout, IQuestion
    {
        TextView questionTextDisplay;
        EditText anserText;
        public static View rootView;

        public TextQuestion(Context context, QuestionStucture stucture):base(context)
        {
            rootView = Inflate(context, Resource.Layout.TextQuestion, this);
            questionTextDisplay = (TextView)FindViewById(Resource.Id.textView1);
            anserText = (EditText)FindViewById(Resource.Id.TextAnser);

            questionTextDisplay.Text = stucture.questionHeading;
            questionTextDisplay.SetTextColor(Color.White);
        }

        public List<string> saveAnswers()
        {
            List<string> answer = new List<string>();
            answer.Add(anserText.Text);
            return answer;
        }

        public bool checkIsRequired()
        {
            throw new NotImplementedException();
        }
    }
}