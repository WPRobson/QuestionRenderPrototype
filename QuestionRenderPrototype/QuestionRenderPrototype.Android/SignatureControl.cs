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
using System.IO;
using Android.Graphics.Drawables;

namespace QuestionRenderPrototype.Droid
{
    class SignatureControl : RelativeLayout
    {

        public static View rootView;
        public static Button clearButton;
        public static TextView nameLable;
        public static EditText NameText;
        public static TextView SignBelowPropt;
        public SignatureBehaviour mSignature;
        public static View mView;
        public static LinearLayout mContent;

        LinearLayout signatureBox;

        public SignatureControl(Context context) : base(context)
        {


            rootView = Inflate(context, Resource.Layout.SignatureLayout, this);
            signatureBox = (LinearLayout)FindViewById(Resource.Id.SignatureBox);

            mContent = (LinearLayout)FindViewById(Resource.Id.SignatureBox);
            mSignature = new SignatureBehaviour(context);

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Color.White); // Changes this drawbale to use a single color instead of a gradient
            gd.SetCornerRadius(5);
            gd.SetStroke(1, Color.Red);
            mSignature.SetBackgroundDrawable(gd);


            mContent.AddView(mSignature, ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);

            clearButton = (Button)FindViewById(Resource.Id.clearButton);

            clearButton.Click += ClearButton_Click;
            mView = mContent;



        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            mSignature.clear();
        }

        public class SignatureBehaviour : Android.Views.View
        {

            LinearLayout mContent;
            //Signature_java mSignature;
            Button mClear, mGetSign, mCancel;
            // public static String tempDir;
            public int count = 1;
            public String current = null;
            private Android.Graphics.Bitmap mBitmap;
            View mView;
            //File mypath;

            public static Boolean signatureDrawn = false;

            private String uniqueId;
            private EditText yourName;
            private static float STROKE_WIDTH = 5f;
            private static float HALF_STROKE_WIDTH = STROKE_WIDTH / 2;
            private Paint paint = new Paint();
            private Android.Graphics.Path path = new Android.Graphics.Path();

            private float lastTouchX;
            private float lastTouchY;
            private RectF dirtyRect = new RectF();






            public SignatureBehaviour(Context context) : base(context)
            {
                paint.AntiAlias = true;
                paint.Color = Color.Black;
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeJoin = Paint.Join.Round;
                paint.StrokeWidth = STROKE_WIDTH;
            }


            public String save(View v)
            {

                if (signatureDrawn.Equals(false))
                {

                    return null;
                }
                else
                {

                    String encoded = null;

                    if (mBitmap == null)
                    {
                        mBitmap = Bitmap.CreateBitmap(v.Width, v.Height, Bitmap.Config.Rgb565);
                    }
                    Canvas canvas = new Canvas(mBitmap);
                    try
                    {
                        //FileOutputStream mFileOutStream = new FileOutputStream(mypath);

                        v.Draw(canvas);

                        //ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

                        byte[] steamBytes = null;

                        System.IO.Stream stream = new MemoryStream(steamBytes);
                        mBitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                        //byte[] byteArray = byteArrayOutputStream.ToByteArray();

                        encoded = Android.Util.Base64.EncodeToString(steamBytes, Android.Util.Base64.Default);


                        //mFileOutStream.flush();
                        // mFileOutStream.close();
                        //String url = MediaStore.Images.Media.insertImage(getContentResolver(), mBitmap, "title", null);
                        //Log.v("log_tag","url: " + url);
                        //In case you want to delete the file
                        //boolean deleted = mypath.delete();
                        //Log.v("log_tag","deleted: " + mypath.toString() + deleted);
                        //If you want to convert the image to string use base64 converter

                    }
                    catch (Exception e)
                    {
                        //Log.v("log_tag", e.toString());
                    }
                    return encoded;
                }

            }

            public void clear()
            {
                path.Reset();
                Invalidate();
                signatureDrawn = false;
            }


            protected override void OnDraw(Canvas canvas)
            {
                canvas.DrawPath(path, paint);
            }

            override public bool OnTouchEvent(MotionEvent e)
            {
                this.Parent.RequestDisallowInterceptTouchEvent(true);
                //getParent().requestDisallowInterceptTouchEvent(true);

                float eventX = e.GetX();
                float eventY = e.GetY();

                string actionEvent = e.Action.ToString();
                switch (actionEvent)
                {
                    case "Down":
                        path.MoveTo(eventX, eventY - 0.5f);
                        lastTouchX = eventX;
                        lastTouchY = eventY;
                        signatureDrawn = true;
                        return true;

                   case "Move":

                    
                    case "Up":

                        resetDirtyRect(eventX, eventY);
                        int historySize = e.HistorySize;
                        for (int i = 0; i < historySize; i++)
                        {
                            float historicalX = e.GetHistoricalX(i);
                            float historicalY = e.GetHistoricalY(i);
                            expandDirtyRect(historicalX, historicalY);
                            path.LineTo(historicalX, historicalY);
                        }
                        path.LineTo(eventX, eventY);
                        signatureDrawn = true;
                        break;

                    default:
                        //debug("Ignored touch event: " + e.toString());
                        return false;
                }

                Invalidate((int)(dirtyRect.Left - HALF_STROKE_WIDTH),
                     (int)(dirtyRect.Top - HALF_STROKE_WIDTH),
                     (int)(dirtyRect.Right + HALF_STROKE_WIDTH),
                     (int)(dirtyRect.Bottom + HALF_STROKE_WIDTH));

                lastTouchX = eventX;
                lastTouchY = eventY;



                return true;
            }
            private void expandDirtyRect(float historicalX, float historicalY)
            {
                if (historicalX < dirtyRect.Left)
                {
                    dirtyRect.Left = historicalX;
                }
                else if (historicalX > dirtyRect.Right)
                {
                    dirtyRect.Right = historicalX;
                }

                if (historicalY < dirtyRect.Top)
                {
                    dirtyRect.Top = historicalY;
                }
                else if (historicalY > dirtyRect.Bottom)
                {
                    dirtyRect.Bottom = historicalY;
                }
            }

            private void resetDirtyRect(float eventX, float eventY)
            {
                dirtyRect.Left = Math.Min(lastTouchX, eventX);
                dirtyRect.Right = Math.Max(lastTouchX, eventX);
                dirtyRect.Top = Math.Min(lastTouchY, eventY);
                dirtyRect.Bottom = Math.Max(lastTouchY, eventY);
            }

        }
    }
}
