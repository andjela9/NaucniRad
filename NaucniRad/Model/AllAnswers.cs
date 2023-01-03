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
    }
}
