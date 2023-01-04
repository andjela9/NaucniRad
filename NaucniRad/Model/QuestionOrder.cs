using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NaucniRad.Model
{
    public class QuestionOrder
    {
        
        
        public List<Question> allQuestions = new List<Question>();
        public List<Question> section1Questions = new List<Question>();
        public List<Question> section2Questions = new List<Question>();
        public List<Question> section3Questions = new List<Question>();
        public List<Question> section4Questions = new List<Question>();
        //public List<Question> section5Questions = new List<Question>();
        public List<Question> section6Questions = new List<Question>();
        public List<Question> section7Questions = new List<Question>();


        public QuestionOrder() {
            this.allQuestions = GetAllQuestions();
            this.section1Questions = GetSection1Questions(allQuestions);
            this.section2Questions= GetSection2Questions(allQuestions);
            this.section3Questions = GetSection3Questions(allQuestions);
            this.section4Questions = GetSection4Questions(allQuestions);
            //this.section5Questions = GetSection5Questions(allQuestions);
            this.section6Questions = GetSection6Questions(allQuestions);
            this.section7Questions = GetSection7Questions(allQuestions);
        }

        public List<Question> GetAllQuestions()
        {
            XElement data = XElement.Load("../../QuestionsAnswers.xml");
            allQuestions = (from question in data.Descendants("Question")
                            select new Question
                            {
                                Path = question.Element("Path").Value,
                                Answer = question.Element("Answer").Value
                            }
                                       ).ToList();
            return allQuestions;
        }

        public List<Question> GetSection1Questions(List<Question> allQuestions)
        {
            int[] indeksi1 = new int[] { 1, 2, 3, 4, 5, 6};
            int[] indeksi2 = new int[] { 7, 8, 9, 10, 11, 12 };
            //ovde pogledati ove indekse, mnogo idu zaredom
            List<int> Section1 = new List<int>() { 7, 10, 4, 5, 4, 3, 8, 6, 10, 12, 7, 11, 8, 9, 2, 3, 2, 1, 6, 9 };
            foreach(int num in Section1)
            {
                section1Questions.Add(allQuestions[num-1]);
            }
            return section1Questions;
        }

        public List<Question> GetSection2Questions(List<Question> allQuestions)
        {
            List<int> Section2 = new List<int>() {14, 24, 15, 22, 23, 13, 21, 20, 23, 15, 13, 25, 17, 22, 26, 18, 17, 28, 27, 16, 19, 22, 20, 21};
            foreach (int num in Section2)
            {
                section2Questions.Add(allQuestions[num - 1]);
            }
            return section2Questions;
        }

        public List<Question> GetSection3Questions(List<Question> allQuestions)
        {
            List<int> Section3 = new List<int>() { 19, 11, 8, 26, 24, 10, 20, 27, 9, 13, 1, 21, 4, 16, 22, 6, 2, 12, 3, 17 };
            foreach (int num in Section3)
            {
                section3Questions.Add(allQuestions[num - 1]);
            }
            return section3Questions;
        }

        public List<Question> GetSection4Questions(List<Question> allQuestions)
        {
            List<int> Section4 = new List<int>() { 25, 18, 3, 11, 24, 2, 26, 23, 28, 6, 20, 15, 6, 27, 7, 19, 1, 23, 13, 12, 
                                                    10, 21, 5, 25, 13, 10, 1, 22, 14, 20, 4, 16, 8, 9, 17, 4, 7, 8, 11, 5 };
            foreach (int num in Section4)
            {
                section4Questions.Add(allQuestions[num - 1]);
            }
            return section4Questions;
        }


        public List<Question> GetSection5Questions(List<Question> allQuestions)
        {
            //TODO
            return null;
        }

        public List<Question> GetSection6Questions(List<Question> allQuestions)
        {
            List<int> Section6 = new List<int>() { 20, 12, 6, 27, 9, 22, 21, 14, 3, 11, 17, 4, 26, 10, 19, 8, 20, 13, 5, 1 };
            foreach (int num in Section6)
            {
                section6Questions.Add(allQuestions[num - 1]);
            }
            return section6Questions;
        }

        public List<Question> GetSection7Questions(List<Question> allQuestions)
        {
            List<int> Section7 = new List<int>() { 22, 12, 1, 24, 27, 7, 5, 21, 10, 23, 11, 14, 26, 14, 9, 15, 8, 3, 20, 15, 8, 3, 
                                                    20, 15, 2, 7, 21, 5, 22, 18, 17, 13, 11, 6, 16, 8, 25, 3, 19, 4, 12, 1, 4, 28 };
            foreach (int num in Section7)
            {
                section7Questions.Add(allQuestions[num - 1]);
            }
            return section7Questions;
        }



        public string Section1QuestionsToSting(List<Question> section1Questions)
        {
            string s = "";
            foreach(Question q in section1Questions)
            {
                s += "\nPath " + q.Path + " , answer: " + q.Answer;
            }
            return s;
        }
    }



}

    
