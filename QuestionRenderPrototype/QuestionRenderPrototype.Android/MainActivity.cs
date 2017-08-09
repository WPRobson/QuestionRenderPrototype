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
using ClassLibrary1;

namespace QuestionRenderPrototype.Droid
{
    [Activity(Label = "QuestionRenderPrototype.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        GridLayout grid;
        List<ClassLibrary1.Question> questionsList = new List<ClassLibrary1.Question>();
        ClassLibrary1.Question quesiton1 = new ClassLibrary1.Question(Enums.QuestionTypes.RadioGroup, "Test 1", 10);
        ClassLibrary1.Question quesiton2 = new ClassLibrary1.Question(Enums.QuestionTypes.Text, "Test 1", 4);
        ClassLibrary1.Question quesiton3 = new ClassLibrary1.Question(Enums.QuestionTypes.Signature, string.Empty, 1);
        ClassLibrary1.Question quesiton4 = new ClassLibrary1.Question(Enums.QuestionTypes.Happiness, string.Empty, 1);
        ClassLibrary1.Question quesiton5 = new ClassLibrary1.Question(Enums.QuestionTypes.Counter, string.Empty, 1);
        ClassLibrary1.Question quesiton6 = new ClassLibrary1.Question(Enums.QuestionTypes.RadioGroup, "Test 1", 5);
        ClassLibrary1.Question quesiton7 = new ClassLibrary1.Question(Enums.QuestionTypes.Text, "Test 1", 4);
        ClassLibrary1.Question quesiton8 = new ClassLibrary1.Question(Enums.QuestionTypes.CheckBox, "Test 1", 4);

        

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

        List<IQuestion> testSaveList = new List<IQuestion>();

        void createControls()
        {

            List<string> testAnswers;
            QuestionStucture QS;

            foreach (var quesiton in questionsList)
            {

                
                switch (quesiton.type)
                {
                    case Enums.QuestionTypes.RadioGroup:
                        testAnswers = new List<string>();
                        testAnswers.Add("Question 1");
                        testAnswers.Add("Question 2");
                        testAnswers.Add("Question 3");
                        testAnswers.Add("Question 4");
                        testAnswers.Add("Question 5");
                        QS = new QuestionStucture("Test RadioGroup", testAnswers, true, null, 3, null, null);

                        RadioGroupQuestion RG = new RadioGroupQuestion(this.ApplicationContext, QS, false);
                        QuestionControls.Add(RG);
                        testSaveList.Add(RG);
                        break; ;
                    case Enums.QuestionTypes.Text:
                        QS = new QuestionStucture("Test TextQuestion", null, true, null, null, null, null);
                        TextQuestion TQ = new TextQuestion(this.ApplicationContext, QS);
                        QuestionControls.Add(TQ);
                        testSaveList.Add(TQ);
                        break;

                    case Enums.QuestionTypes.Signature:
                        SignatureControl SC = new SignatureControl(this.ApplicationContext, null, true);
                        QuestionControls.Add(SC);
                        testSaveList.Add(SC);
                        break;
                    case Enums.QuestionTypes.Happiness:
                        HappinessSelectorControl HSC = new HappinessSelectorControl(this.ApplicationContext, null, false);
                        QuestionControls.Add(HSC);
                        testSaveList.Add(HSC);

                        break;
                    case Enums.QuestionTypes.Counter:
                        QS = new QuestionStucture(string.Empty, null, true, null, null, 0, 5);
                        CounterControl CC = new CounterControl(this.ApplicationContext, QS, true );
                        // SignatureControl SC = new SignatureControl(this.ApplicationContext);
                        QuestionControls.Add(CC);
                        testSaveList.Add(CC);
                        break;
                    case Enums.QuestionTypes.CheckBox:
                       testAnswers = new List<string>();
                        testAnswers.Add("Question 1");
                        testAnswers.Add("Question 2");
                        testAnswers.Add("Question 3");
                        QS = new QuestionStucture("Test checkBox", testAnswers, true, null, 3, null, null);

                        CheckboxQuestion CHQ = new CheckboxQuestion(this.ApplicationContext,QS, false);
                        QuestionControls.Add(CHQ);
                        testSaveList.Add(CHQ);

                        break;
                    default:
                        break;
                }
            }

        }

        void renderControls()
        {
            //LinearLayout.LayoutParams ll = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

            grid.RowCount = QuestionControls.Count + 1;

            for (int i = 0; i < QuestionControls.Count; i++)
            {
                Spec newRow = GridLayout.InvokeSpec(i);
                rowSpecs.Add(newRow);
                grid.AddView(QuestionControls[i], new GridLayout.LayoutParams(rowSpecs.ElementAt(i), colSpec1));
            }

            Button saveButton = new Button(this.ApplicationContext);
            saveButton.Text = "Save";
            saveButton.Click += SaveButton_Click;
            Spec newRow2 = GridLayout.InvokeSpec(8);
            rowSpecs.Add(newRow2);

            grid.AddView(saveButton, new GridLayout.LayoutParams(rowSpecs.ElementAt(8), colSpec1));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            List<List<string>> questionAnswers = new List<List<string>>();    
            foreach (var item in testSaveList)
            {
              questionAnswers.Add(item.saveAnswers());
            }
        }
    }
}


