using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using static Android.Widget.GridLayout;
using System.Linq;
using static Android.Widget.TabHost;

namespace QuestionRenderPrototype.Droid
{
    [Activity(Label = "QuestionRenderPrototype.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        GridLayout grid;
        List<ClassLibrary1.Question> questionsList = new List<ClassLibrary1.Question>();
        ClassLibrary1.Question quesiton1 = new ClassLibrary1.Question("RadioGroup", "Test 1", 100);
        ClassLibrary1.Question quesiton2 = new ClassLibrary1.Question("Text", "Test 1", 4);
        ClassLibrary1.Question quesiton3 = new ClassLibrary1.Question("Signature", string.Empty, 1);
        ClassLibrary1.Question quesiton4 = new ClassLibrary1.Question("Happiness", string.Empty, 1);
        ClassLibrary1.Question quesiton5 = new ClassLibrary1.Question("Counter", string.Empty, 1);
        ClassLibrary1.Question quesiton6 = new ClassLibrary1.Question("RadioGroup", "Test 1", 5);
        ClassLibrary1.Question quesiton7 = new ClassLibrary1.Question("Text", "Test 1", 4);
        ClassLibrary1.Question quesiton8 = new ClassLibrary1.Question("CheckBox", "Test 1", 4);

        

        List<Spec> rowSpecs = new List<Spec>();

        Spec colSpec1 = GridLayout.InvokeSpec(0);

        List<View> QuestionControls = new List<View>();

        protected override void OnCreate(Bundle bundle)
        {
            questionsList.Add(quesiton1);
            questionsList.Add(quesiton2);
            questionsList.Add(quesiton3);
            questionsList.Add(quesiton4);
            questionsList.Add(quesiton5);
            questionsList.Add(quesiton6);
            questionsList.Add(quesiton7);
            questionsList.Add(quesiton8);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            
         

           

            
            

            grid = (GridLayout)FindViewById(Resource.Id.gridLayout1);

            createControls();
            renderControls();
        }


        void createControls()
        {
            foreach (var quesiton in questionsList)
            {
                switch (quesiton.type)
                {
                    case "RadioGroup":
                        RadioGroupQuestion RG = new RadioGroupQuestion(this.ApplicationContext, quesiton.questionText, quesiton.answers);
                        QuestionControls.Add(RG);
                        break; ;
                    case "Text":
                        TextQuestion TQ = new TextQuestion(this.ApplicationContext, quesiton.questionText);
                        QuestionControls.Add(TQ);
                        break;

                    case "Signature":
                        SignatureControl SC = new SignatureControl(this.ApplicationContext);
                        QuestionControls.Add(SC);
                        break;
                    case "Happiness":
                        HappinessSelectorControl HSC = new HappinessSelectorControl(this.ApplicationContext);
                        QuestionControls.Add(HSC);

                        break;
                    case "Counter":
                        CounterControl CC = new CounterControl(this.ApplicationContext, 0, 0);
                        // SignatureControl SC = new SignatureControl(this.ApplicationContext);
                        QuestionControls.Add(CC);
                        break;
                    case "CheckBox":
                        CheckboxQuestion CHQ = new CheckboxQuestion(this.ApplicationContext, quesiton.answers, quesiton.questionText);
                        QuestionControls.Add(CHQ);
                        break;
                    default:
                        break;
                }
            }

        }

        void renderControls()
        {
            LinearLayout.LayoutParams ll = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

            grid.RowCount = QuestionControls.Count;

            for (int i = 0; i < QuestionControls.Count; i++)
            {
                Spec newRow = GridLayout.InvokeSpec(i);
                rowSpecs.Add(newRow);
                grid.AddView(QuestionControls[i], new GridLayout.LayoutParams(rowSpecs.ElementAt(i), colSpec1));
            }
        }
    }
}


