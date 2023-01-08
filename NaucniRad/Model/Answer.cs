﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaucniRad.Model
{
    public class Answer
    {
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
       
        public Answer(double miliseconds, int numberOfErrors, string correctAnswer)
        {
            Miliseconds = miliseconds;
            NumberOfErrors = numberOfErrors;
            CorrectAnswer = correctAnswer;
        }

        public override string ToString()
        {
            return "*** " + " Miliseconds: " +  this.Miliseconds.ToString() + " Number of errors: " + this.NumberOfErrors.ToString() + " Correct answer: " + this.CorrectAnswer;
        }
    }
}
