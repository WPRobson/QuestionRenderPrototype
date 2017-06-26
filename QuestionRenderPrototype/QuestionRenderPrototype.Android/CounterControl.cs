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

namespace QuestionRenderPrototype.Droid
{
    class CounterControl : GridLayout
    {

        int value = 0;
        int minValue = 0;
        int maxValue = 0;
        public static View rootView;

        Button increaseValue;

        Button decreaseValue;

        TextView counterText;

        public CounterControl(Context context, int min, int max) : base(context)
        {

            rootView = Inflate(context, Resource.Layout.CounterLayout, this);

            increaseValue = (Button)FindViewById(Resource.Id.increaseValue);
            decreaseValue = (Button)FindViewById(Resource.Id.decreaseVale);
            counterText = (TextView)FindViewById(Resource.Id.counterText);
            value = 0;

            if (min > 0)
            {
                minValue = min;
                value = minValue;
                counterText.Text = value.ToString();
            }

            if (max > 0)
            {
                maxValue = max;
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
            if (minValue > 0)
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
    }
}