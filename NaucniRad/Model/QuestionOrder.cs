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
        public List<Question> section5Questions = new List<Question>();
        public List<Question> section6Questions = new List<Question>();
        public List<Question> section7Questions = new List<Question>();


        public QuestionOrder() {
            this.allQuestions = GetAllQuestions();
            this.section1Questions = GetSection1Questions(allQuestions);
            this.section2Questions= GetSection2Questions(allQuestions);
            this.section3Questions = GetSection3Questions(allQuestions);
            this.section4Questions = GetSection4Questions(allQuestions);
            this.section5Questions = GetSection5Questions(allQuestions);
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
            List<int> Section1 = new List<int>() { 4, 3, 8, 1, 10, 7, 2, 5, 3, 12, 10, 6, 9, 1, 11, 8, 9, 6, 2, 7  };
            //List<int> Section1 = new List<int>() { 7, 10, 4};
            foreach (int num in Section1)
            {
                section1Questions.Add(allQuestions[num-1]);
            }
            return section1Questions;
        }

        public List<Question> GetSection2Questions(List<Question> allQuestions)
        {
            List<int> Section2 = new List<int>() {14, 24, 15, 22, 13, 20, 23, 15, 13, 25, 17, 22, 26, 18, 28, 27, 16, 19, 20, 21};
            //List<int> Section2 = new List<int>() {14, 24};

            foreach (int num in Section2)
            {
                section2Questions.Add(allQuestions[num - 1]);
            }
            return section2Questions;
        }

        public List<Question> GetSection3Questions(List<Question> allQuestions)
        {
            List<int> Section3 = new List<int>() { 19, 11, 8, 26, 24, 10, 20, 27, 9, 13, 1, 21, 4, 16, 22, 6, 2, 12, 3, 17 };
            //List<int> Section3 = new List<int>() { 19, 11, 8};

            foreach (int num in Section3)
            {
                section3Questions.Add(allQuestions[num - 1]);
            }
            return section3Questions;
        }

        public List<Question> GetSection4Questions(List<Question> allQuestions)
        {
            
            List<int> Section4 = new List<int>() { 21, 1, 22, 13, 14, 3, 15, 23, 4, 16, 7, 24, 8, 2, 18, 8, 25, 21, 1, 9, 10, 26, 12, 5, 27, 17, 28, 6, 
                                                  14, 10, 13, 25, 8, 4, 23, 19, 11, 6, 20, 17};

            //List<int> Section4 = new List<int>() { 25, 18, 5 };

            foreach (int num in Section4)
            {
                section4Questions.Add(allQuestions[num - 1]);
            }
            return section4Questions;
        }


        public List<Question> GetSection5Questions(List<Question> allQuestions)
        {
            List<int> Section5 = new List<int>() { 10, 4, 8, 1, 2, 7, 11, 6, 9, 12, 3, 4, 7, 8, 9, 1, 2, 10, 5, 6 };
            //List<int> Section5 = new List<int>() { 10, 4 };

            foreach (int num in Section5)
            {
                section5Questions.Add(allQuestions[num - 1]);
            }
            return section5Questions;
        }

        public List<Question> GetSection6Questions(List<Question> allQuestions)
        {
            
            
            List<int> Section6 = new List<int>() { 1, 7, 14, 3, 9, 23, 11, 17, 4, 25, 2, 16, 28, 6, 8, 22, 18, 10, 20, 21};
           
            //List<int> Section6 = new List<int>() { 20, 12, 6 };

            foreach (int num in Section6)
            {
                section6Questions.Add(allQuestions[num - 1]);
            }
            return section6Questions;
        }

        public List<Question> GetSection7Questions(List<Question> allQuestions)
        {
            
            List<int> Section7 = new List<int>() { 7, 3, 23, 10, 15, 4, 17, 22, 20, 1,
                                                  12, 6, 1, 8, 25, 18, 9, 24, 7, 19,
                                                 2, 26, 27, 5, 3, 11, 16, 13, 8, 9, 
                                                    14, 20, 21, 18, 28, 10, 2, 27, 6, 21 };

            //List<int> Section7 = new List<int>() { 22, 12, 28 };


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

    
