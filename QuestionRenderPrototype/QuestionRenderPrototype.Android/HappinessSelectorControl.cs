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
    class HappinessSelectorControl : GridLayout
    {
        public static View rootView;

        public ImageButton rating1;
        public ImageButton rating2;
        public ImageButton rating3;
        public ImageButton rating4;
        public ImageButton rating5;

        int selected = 1;
        int prevousSelected;

        public HappinessSelectorControl(Context context) : base(context)
        {
            rootView = Inflate(context, Resource.Layout.HappinessRatingControlLayout, this);
            rating1 = (ImageButton)FindViewById(Resource.Id.imageButton1);
            rating2 = (ImageButton)FindViewById(Resource.Id.imageButton2);
            rating3 = (ImageButton)FindViewById(Resource.Id.imageButton3);
            rating4 = (ImageButton)FindViewById(Resource.Id.imageButton4);
            rating5 = (ImageButton)FindViewById(Resource.Id.imageButton5);

            rating1.Click += Rating1_Click;
            rating2.Click += Rating2_Click;
            rating3.Click += Rating3_Click;
            rating4.Click += Rating4_Click;
            rating5.Click += Rating5_Click;
        }

        private void Rating5_Click(object sender, EventArgs e)
        {
            selected = 5;
            swapSelectedImage();
            prevousSelected = 5;
            rating5.SetImageResource(Resource.Drawable.face5border);

        }

        private void Rating4_Click(object sender, EventArgs e)
        {
            selected = 4;
            swapSelectedImage();
            prevousSelected = 4;
        }

        private void Rating3_Click(object sender, EventArgs e)
        {
            selected = 3;
            swapSelectedImage();
            prevousSelected = 3;
        }

        private void Rating2_Click(object sender, EventArgs e)
        {
            selected = 2;
            swapSelectedImage();
            prevousSelected = 2;
        }

        private void Rating1_Click(object sender, EventArgs e)
        {
            selected = 1;
            swapSelectedImage();
            prevousSelected = 1;
        }

        private void swapSelectedImage()
        {

            if (selected == prevousSelected)
            {
                return;    
            }
            switch (selected)
            {
                case 1:
                    rating1.SetImageResource(Resource.Drawable.face1border);
                    break;
                case 2:
                    rating2.SetImageResource(Resource.Drawable.face2border);
                    break;
                case 3:
                    rating3.SetImageResource(Resource.Drawable.face3border);
                    break;
                case 4:
                    rating4.SetImageResource(Resource.Drawable.face4border);
                    break;
                case 5:
                    rating5.SetImageResource(Resource.Drawable.face5border);
                    break;
                default:
                    break;
            }

            switch (prevousSelected)
            {

                case 1:
                    rating1.SetImageResource(Resource.Drawable.face1);
                    break;
                case 2:
                    rating2.SetImageResource(Resource.Drawable.face2);
                    break;
                case 3:
                    rating3.SetImageResource(Resource.Drawable.face3);
                    break;
                case 4:
                    rating4.SetImageResource(Resource.Drawable.face4);
                    break;
                case 5:
                    rating5.SetImageResource(Resource.Drawable.face5);
                    break;
                default:
                    break;
            }



        }

    }
}