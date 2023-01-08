using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaucniRad.Model
{
    public class AllAnswers
    {
        public int Section                  //bice ih 7
        {
            get;
            set;
        }

        public List<Answer> Answers         //lista odgovora za svaku sekciju
        {
            get;
            set;
        }

        public AllAnswers() 
        {
            Answers = new List<Answer>();
        }

        public AllAnswers(int section)
        {

            Section = section;
            Answers= new List<Answer>();
        }

        public void AddAnswer(Answer answer)
        {
            Answers.Add(answer);
        }

        public override string ToString()
        {
            string s = "***VASI ODGOVORI: " + "Sekcija: " + this.Section.ToString() + "\n";
            foreach(Answer answer in Answers)
            {
                s += answer.ToString() + "\n";
            }
            return s;
        }
    }
}
