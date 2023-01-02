using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaucniRad.Model
{
    [Serializable]
    public class Question
    {
        private string path;
        private string answer;

        public Question(string path, string answer)
        {
            this.path = path;
            this.answer = answer;
        }
        public Question() { }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}
