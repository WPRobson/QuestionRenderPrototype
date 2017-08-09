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
using System.Threading;
using ClassLibrary1;

namespace QuestionRenderPrototype.Droid
{
    class CounterControl : GridLayout, IQuestion
    {
        bool isRequired;
        int value = 0;
        int? minValue = 0;
        int? maxValue = 0;
        public static View rootView;

        Button increaseValue;
        Button decreaseValue;
        TextView counterText;

        public CounterControl(Context context, QuestionStucture structure, bool required) : base(context)
        {
            isRequired = required;
            rootView = Inflate(context, Resource.Layout.CounterLayout, this);

            increaseValue = (Button)FindViewById(Resource.Id.increaseValue);
            decreaseValue = (Button)FindViewById(Resource.Id.decreaseVale);
            counterText = (TextView)FindViewById(Resource.Id.counterText);
            value = 0;

            if (structure?.counterMin.Value !=null)
            {
                minValue = structure.counterMin.Value;
                value = minValue.Value;
                counterText.Text = value.ToString();
            }

            if (structure?.counterMax.Value != null)
            {
                maxValue = structure.counterMax.Value;
            }

            decreaseValue.Click += DecreaseValue_Click;
            increaseValue.Click += IncreaseValue_Click;
        }


        private void IncreaseValue_Click(object sender, EventArgs e)
        {
            if (maxValue > 0)
            {
                if (value + 1 <= maxValue)
                {
                    value++;
                    counterText.Text = value.ToString();
                }
            }
            else
            {
                value++;
                counterText.Text = value.ToString();
            }
        }

        private void DecreaseValue_Click(object sender, EventArgs e)
        {
            if (minValue != null)
            {
                if (value - 1 >= minValue)
                {
                    value--;
                    counterText.Text = value.ToString();
                }
            }

            else
            {
                value--;
                counterText.Text = value.ToString();
            }
        }

        public List<string> saveAnswers()
        {
            List<string> answer = new List<string>();
            answer.Add(counterText.Text);
            return answer;
        }

        public bool checkIsRequired()
        {
            throw new NotImplementedException();
        }
    }
}