using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaucniRad.Model
{
    public class Answer
    {
        public int Miliseconds
        {
            get;
            set;
        }
        public int NumberOfErrors 
        {
            get;
            set;
        }
        public string CorrectAnswer
        {
            get; 
            set;
        }

        public Answer() { }
       
        public Answer(int miliseconds, int numberOfErrors, string correctAnswer)
        {
            Miliseconds = miliseconds;
            NumberOfErrors = numberOfErrors;
            CorrectAnswer = correctAnswer;
        }
    }
}
