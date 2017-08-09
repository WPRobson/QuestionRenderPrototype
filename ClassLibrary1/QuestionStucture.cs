using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class QuestionStucture
    {
       public string questionHeading { get; set; }

        //public Dictionary<int, string> answers { get; set;}

        public List<string> answers { get; set; }

        //public bool isRequired { get; set; }

        public int? minimumAnswersRequired { get; set; }

        public int? maximumAnswersRequired { get; set; }

        public int? counterMin { get; set; }

        public int? counterMax { get; set; }


        public QuestionStucture(string heading, List<string> answers, bool required, int? minimumAnswers, int? maximumAnswers, int? counterMinimum, int? counterMaximum)
        {
            this.questionHeading = heading;
            this.answers = answers;
            //this.isRequired = required;
            this.minimumAnswersRequired = minimumAnswers;
            this.maximumAnswersRequired = maximumAnswers;
            this.counterMin = counterMinimum;
            this.counterMax = counterMaximum;
        }


    }
}
