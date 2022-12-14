using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace NaucniRad.WPF
{
    /// <summary>
    /// Interaction logic for IspitanikEntry.xaml
    /// </summary>
    public partial class IspitanikEntry : Window
    {
        private Ispitanik noviIspitanik = new Ispitanik();
        public IspitanikEntry(Ispitanik unetIspitanik)
        {
            InitializeComponent();
            
            this.DataContext= noviIspitanik;
            this.collegeListBox.ItemsSource = new List<String> { "FTN", "MFUNS" };
            this.genderListBox.ItemsSource = new List<String> { "Muski", "Zenski", "Ne zelim da se izjasnim" };
            this.disabilityListBox.ItemsSource = new List<String> { "Da", "Ne" };
        }

        private bool ValidateInput()
        {
            bool retVal = true;

            //validating age input
            if (String.IsNullOrWhiteSpace(ageTxt.Text))
            {
                ageTxt.BorderBrush = Brushes.Red;
                ageVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                int age;
                if(Int32.TryParse(ageTxt.Text, out age))
                {
                    if (age <= 0)
                    {
                        ageTxt.BorderBrush = Brushes.Red;
                        ageVal.Visibility = Visibility.Visible;
                        ageVal.Text = "Godine moraju biti pozitivan broj";
                        retVal = false;
                    }
                    else
                    {
                        ageTxt.ClearValue(Border.BorderBrushProperty);
                        ageVal.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    ageTxt.BorderBrush = Brushes.Red;
                    ageVal.Text = "Godine moraju biti pozitivan broj";
                    retVal = false;
                }
            }

            //validating college input
            if(collegeListBox.SelectedIndex == -1)
            {
                //collegeListBox.BorderBrush= Brushes.Red;
                collegeVal.Visibility = Visibility.Visible;
                retVal= false;
            }
            else
            {
                //collegeVal.ClearValue(Border.BorderBrushProperty);
                collegeVal.Visibility = Visibility.Hidden;
            }

            //validating gender input
            if (genderListBox.SelectedIndex == -1)
            {
                //genderListBox.BorderBrush = Brushes.Red;
                genderVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                //genderVal.ClearValue(Border.BorderBrushProperty);
                genderVal.Visibility = Visibility.Hidden;
            }

            //validating course input
            if (String.IsNullOrWhiteSpace(courseTxt.Text))
            {
                courseTxt.BorderBrush = Brushes.Red;
                courseVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                courseTxt.ClearValue(Border.BorderBrushProperty);
                courseVal.Visibility = Visibility.Hidden;
            }

            //validating disability input
            if (disabilityListBox.SelectedIndex == -1)
            {
                //disabilityListBox.BorderBrush = Brushes.Red;
                disabilityVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                //disabilityVal.ClearValue(Border.BorderBrushProperty);
                disabilityVal.Visibility = Visibility.Hidden;
            }
            return retVal;
        }

        private void ispitanikDaljeClick(object sender, RoutedEventArgs e)
        {
            if(ValidateInput())
            {
                string disability;
                if (noviIspitanik.Disability == true)
                {
                    disability = "Da";
                }
                else {
                    disability = "ne";
                }
                MessageBox.Show("Godine: " + noviIspitanik.Age + "\nFakultet: " + noviIspitanik.College +"\nPol: " + noviIspitanik.Gender + "\nSmer: " + noviIspitanik.Course
                    + "\nOsoba sa invaliditetom: " + disability);


                //XmlSerializer serializer = new XmlSerializer(typeof(Ispitanik));            //ovo je okej
                //using (TextWriter writer = new StreamWriter("/Entries.xml"))                //ovo moze u admin modu ali ne ispisuje nista
                //{
                //    serializer.Serialize(writer, noviIspitanik);
                //}
                XmlSerializer serializer = new XmlSerializer(typeof(Ispitanik));

                using (StreamWriter writer = new StreamWriter("C:\\Users\\andje\\source\\repos\\NaucniRad\\NaucniRad\\Entries.xml"))
                {
                    serializer.Serialize(writer, noviIspitanik);
                }
               
            }
            else
            {
                MessageBox.Show("Greska u unosu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
