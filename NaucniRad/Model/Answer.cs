using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaucniRad.Model
{
    public class Answer
    {
        public int Id
        {
            get; 
            set;
        }

        public string Section 
        { 
            get; 
            set; 
        }

        public double Miliseconds
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
       
        public Answer(int id, string section, double miliseconds, int numberOfErrors, string correctAnswer)
        {
            Id = id;
            Section = section;
            Miliseconds = miliseconds;
            NumberOfErrors = numberOfErrors;
            CorrectAnswer = correctAnswer;
        }

        public override string ToString()
        {
            return "*** " + "Id: " + this.Id + " Section: " + this.Section  + " Miliseconds: " +  this.Miliseconds.ToString() + " Number of errors: " 
                + this.NumberOfErrors.ToString()  + " Correct answer: " + this.CorrectAnswer;
        }
    }
}
