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
        #region ne treba ovako jer onda budu duplo kolone za sve
        //private string path;
        //private string answer;

        //public Question(string path, string answer)
        //{
        //    this.path = path;
        //    this.answer = answer;
        //}
        //public Question() { }

        //public string Path
        //{
        //    get { return path; }
        //    set { path = value; }
        //}
        //public string Answer
        //{
        //    get { return answer; }
        //    set { answer = value; }
        //}
        #endregion
        public string Path
        {
            get; set;
        }
        public string Answer
        {
            get; set;
        }

        public Question(string path, string answer)
        {
            this.Path = path;
            this.Answer = answer;
        }
        public Question() { }

    }
}
