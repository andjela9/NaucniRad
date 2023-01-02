using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NaucniRad
{
    [Serializable]
    
    public class Ispitanik : INotifyPropertyChanged
    {
        private int id;
        private string age;
        private string college;
        private string gender;
        private string course;
        private string disability;
        private int selfAssessment;
        

        public Ispitanik(int id, string age, string college, string gender, string course, string disability, int selfAssessment)
        {
            this.id = id;
            this.age = age;
            this.college = college;
            this.gender = gender;
            this.course = course;
            this.disability = disability;
            this.selfAssessment = selfAssessment;
        }

        public Ispitanik() { }
        public event PropertyChangedEventHandler PropertyChanged;

        #region Geteri i seteri

        public int Id
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged("Id");
            }
        }
        
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public string College
        {
            get { return college; }
            set
            {
                college = value;
                OnPropertyChanged("College");
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Course
        {
            get { return course; }
            set
            {
                course = value;
                OnPropertyChanged("Course");
            }
        }

        public string Disability
        {
            get { return disability; }
            set
            {
                disability = value;
                OnPropertyChanged("Disability");
            }
        }
        public int SelfAssessment
        {
            get { return selfAssessment; }
            set
            {
                selfAssessment = value;
                OnPropertyChanged("SelfAssessment");
            }
        }
        #endregion


        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
