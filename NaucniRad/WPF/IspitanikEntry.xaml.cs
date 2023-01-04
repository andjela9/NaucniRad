using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NaucniRad.WPF
{
    /// <summary>
    /// Interaction logic for IspitanikEntry.xaml
    /// </summary>
    public partial class IspitanikEntry : Window
    {
        public List<Ispitanik> ucitanaLista = new List<Ispitanik> { };

        

        private Ispitanik noviIspitanik = new Ispitanik();
        
        
        public IspitanikEntry(Ispitanik unetIspitanik)
        {
            InitializeComponent();
            
            this.DataContext= noviIspitanik;
            //this.ageListBox.ItemsSource = new List<String> { "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"};
            this.collegeListBox.ItemsSource = new List<String> { "FTN", "MFUNS" };
            this.genderListBox.ItemsSource = new List<String> { "Muški", "Ženski", "Ne želim da se izjasnim" };
            this.disabilityListBox.ItemsSource = new List<String> { "Da", "Ne" };


            //ucitanaLista = new List<Ispitanik>();                  //nova lista koja ce pri pokretanju da uzme to poslednje iz xml i doda na staru listu


            try
            {
                XElement data = XElement.Load("../../Entries.xml");
                ucitanaLista = (from ispitanik in data.Descendants("Ispitanik")
                                select new Ispitanik
                                {
                                    Id = Int32.Parse(ispitanik.Element("Id").Value),
                                    Age = ispitanik.Element("Age").Value,
                                    College = ispitanik.Element("College").Value,
                                    Gender = ispitanik.Element("Gender").Value,
                                    Course = ispitanik.Element("Course").Value,
                                    Disability = ispitanik.Element("Disability").Value,
                                    SelfAssessment = int.Parse(ispitanik.Element("SelfAssessment").Value)
                                }
                                   ).ToList();
            }
            catch (Exception)
            {
                //ovde upada ako ne moze da ucita iz xml-a, tj xml je prazan
            }



            string t = ListToString(ucitanaLista);
            //string t = "\n***IZ XML:\n";
            //foreach (var ispitanik in ucitanaLista)
            //{
            //    t += "\n" + (ispitanik.Age) + "\n" + ispitanik.College + "\n" + ispitanik.Gender + "\n"
            //        + ispitanik.Course + "\n" + ispitanik.Disability + "\n" + ispitanik.SelfAssessment + "\n";
            //}
            //MessageBox.Show(t);
        }

        private bool ValidateInput()
        {
            bool retVal = true;

            //validating age input
            //if (ageListBox.SelectedIndex == -1)
            //{
            //    //ageListBox.BorderBrush= Brushes.Red;
            //    ageVal.Visibility = Visibility.Visible;
            //    retVal = false;
            //}
            //else
            //{
            //    //ageVal.ClearValue(Border.BorderBrushProperty);
            //    ageVal.Visibility = Visibility.Hidden;
            //}
            //validating age input
            if (String.IsNullOrWhiteSpace(ageTxt.Text))
            {
                ageTxt.BorderBrush = Brushes.Red;
                ageVal.Visibility = Visibility.Visible;
                retVal = false;
            }
            else
            {
                if (Int32.TryParse(ageTxt.Text, out int age))
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
            if (collegeListBox.SelectedIndex == -1)
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

        public static XmlElement SerializeToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }

        public string ListToString(List<Ispitanik> ispitaniciLista)
        {
            string s = "Iz forme u listu:***\n";
            foreach(var ispitanik in ispitaniciLista)
            {
                s+= ispitanik.Id + "\n" + ispitanik.Age + "\n" + ispitanik.College + "\n" + ispitanik.Gender + "\n" + ispitanik.Course + "\n" + ispitanik.Disability + "\n";
            }
            return s;
        }


        private void ispitanikDaljeClick(object sender, RoutedEventArgs e)
        {
            if(ValidateInput())
            {
                #region debag problema sa listom
                //ispitaniciLista.Add(noviIspitanik);

                //Ispitanik probni = new Ispitanik(1, "fakultet", "z", "kurs", "ne", 0);
                //ispitaniciLista.Add(probni);
                //Ispitanik probni2 = new Ispitanik(1, "fakultet2", "z2", "kurs2", "ne2", 1);
                //ispitaniciLista.Add(probni2);
                //Ispitanik probni3 = new Ispitanik(1, "fakultet3", "z3", "kurs3", "ne3", 2);
                //ispitaniciLista.Add(probni3);

                //Ispitanik fix = noviIspitanik;
                //ispitaniciLista.Add(fix);
                //Ispitanik probni = new Ispitanik(1, "fakultet", "z", "kurs", "ne", 0);
                //ispitaniciLista.Add(probni);


                //popunjavanje liste podacima iz xml
                #endregion

                //upis u xml
                int id = ucitanaLista.Count() + 1;
                Ispitanik fix = new Ispitanik(id, noviIspitanik.Age, noviIspitanik.College, noviIspitanik.Gender, noviIspitanik.Course, 
                                                noviIspitanik.Disability, noviIspitanik.SelfAssessment);
                ucitanaLista.Add(fix);
                MessageBox.Show("Poslednji unos: \n" + "\nId: " + id +  "\nGodine: " + noviIspitanik.Age + "\nFakultet: " + noviIspitanik.College +"\nPol: " + 
                    noviIspitanik.Gender + "\nSmer: " + noviIspitanik.Course + "\nOsoba sa invaliditetom: " + noviIspitanik.Disability 
                    + "\nBroj elemenata u listi: " + ucitanaLista.Count.ToString() + "\n" );

                //MessageBox.Show(ListToString(ispitaniciLista));
                string s = "Lista iz programa\n";
                foreach(var ispitanik in ucitanaLista)
                {
                    s+= ispitanik.Age + "\n";
                }
                //MessageBox.Show(s);

                XmlSerializer serializer = new XmlSerializer(ucitanaLista.GetType(), new XmlRootAttribute("Ispitanici"));                  //ovo je okej
                using (TextWriter writer = new StreamWriter("../../Entries.xml"))                //okej
                {
                    serializer.Serialize(writer, ucitanaLista);
                    writer.Close();
                }

                Introduction introduction = new Introduction();
                this.Close();
                introduction.ShowDialog();

               
            }
            else
            {
                MessageBox.Show("Greska u unosu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
