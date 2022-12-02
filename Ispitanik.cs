using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaucniRad
{
    public class Ispitanik : INotifyPropertyChanged
    {
        private int age;
        private string college;
        private string gender;
        private string course;
        private bool disability;

        public Ispitanik(int age, string college, string gender, string course, bool disability)
        {
            this.age = age;
            this.college = college;
            this.gender = gender;
            this.course = course;
            this.disability = disability;
        }

        public Ispitanik() { }
        public event PropertyChangedEventHandler PropertyChanged;

        #region Geteri i seteri

        public int Age
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

        public bool Disability
        {
            get { return disability; }
            set
            {
                disability = value;
                OnPropertyChanged("Disability");
            }
        }
        #endregion


        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
