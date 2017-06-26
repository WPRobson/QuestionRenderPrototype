using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Question
    {
        public string type;
        public string questionText;
        public int answers;

        public Question(string _type, string _text, int _answers)
        {
            type = _type;
            questionText = _text;
            answers = _answers;
        }


    }
}
