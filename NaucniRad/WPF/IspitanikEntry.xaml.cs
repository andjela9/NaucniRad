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

        
        private Ispitanik noviIspitanik = new Ispitanik();
        
        public List<Ispitanik> ispitaniciLista = new List<Ispitanik> { };
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
            string s = "";
            foreach(var ispitanik in ispitaniciLista)
            {
                s+= ispitanik.Age + "\n" + ispitanik.College + "\n" + ispitanik.Gender + "\n" + ispitanik.Course + "\n" + ispitanik.Disability + "\n";
            }
            return s;
        }


        private void ispitanikDaljeClick(object sender, RoutedEventArgs e)
        {
            if(ValidateInput())
            {
                //ispitaniciLista.Add(noviIspitanik);

                Ispitanik probni = new Ispitanik(1, "fakultet", "z", "kurs", "ne", 0);
                ispitaniciLista.Add(probni);
                Ispitanik probni2 = new Ispitanik(1, "fakultet2", "z2", "kurs2", "ne2", 1);
                ispitaniciLista.Add(probni2);
                Ispitanik probni3 = new Ispitanik(1, "fakultet3", "z3", "kurs3", "ne3", 2);
                ispitaniciLista.Add(probni3);

                MessageBox.Show("Godine: " + noviIspitanik.Age + "\nFakultet: " + noviIspitanik.College +"\nPol: " + noviIspitanik.Gender + "\nSmer: " + noviIspitanik.Course
                     + "\nOsoba sa invaliditetom: " + noviIspitanik.Disability + "\n" + ispitaniciLista.Count.ToString() + "\n" );

                //MessageBox.Show(ListToString(ispitaniciLista));
                string s = "";
                foreach(var ispitanik in ispitaniciLista)
                {
                    s+= ispitanik.Age;
                }
                MessageBox.Show(s);


                #region Xml parsiranje
                //XmlDocument doc = new XmlDocument();
                //doc.Load("../../Entries.xml");
                //XmlElement node = SerializeToXmlElement(noviIspitanik);
                //var ispitaniciNode = doc.CreateElement("Ispitanici");
                //ispitaniciNode.AppendChild(node);
                //doc.DocumentElement.AppendChild(ispitaniciNode);
                //doc.Save("../../Entries.xml");


                XmlSerializer serializer = new XmlSerializer(ispitaniciLista.GetType(), new XmlRootAttribute("Ispitanici"));                  //ovo je okej
                using (TextWriter writer = new StreamWriter("../../Entries.xml"))                //ovo radi okej, problem je pakovanje u listu
                {
                    serializer.Serialize(writer, ispitaniciLista);
                }




                //XmlSerializer serializer = new XmlSerializer(typeof(Ispitanik));
                //using (StreamWriter writer = new StreamWriter("C:\\Users\\andje\\source\\repos\\NaucniRad\\NaucniRad\\Entries.xml"))
                //{
                //   serializer.Serialize(writer, noviIspitanik);
                //}

                //XmlSerializer serializer = new XmlSerializer(typeof(Ispitanik));
                //using (StreamWriter writer = new StreamWriter("\\Entries.xml"))         //ovako ne moze
                //{
                //    serializer.Serialize(writer, noviIspitanik);
                //}

                //XDocument config = XDocument.Load("../../Entries.xml");                         //ovo ne upisuje nista
                //XElement rootElement = config.Descendants("Ispitanici").FirstOrDefault();
                //XElement ispitanikXml = new XElement("Ispitanik", new XAttribute("age", noviIspitanik.Age),
                //                        new XAttribute("College", noviIspitanik.College));

                //if(rootElement != null)
                //{
                //    rootElement.Add(ispitanikXml);
                //    config.Save("Entries.xml");

                //}

                //XmlSerializer serializer = new XmlSerializer(typeof(Ispitanik));
                //XDocument config = XDocument.Load("../../Entries.xml");                         //ovo ne upisuje nista
                //XElement rootElement = config.Descendants("Ispitanici").FirstOrDefault();
                //using (TextWriter writer = new StreamWriter("../../Entries.xml"))                //radi ali samo za poslednji unos
                //{
                //    serializer.Serialize(writer, noviIspitanik);
                //}

                //if (rootElement != null)
                //{
                //    rootElement.Add(serializer);
                //    config.Save("../../Entries.xml");

                //}


                


                #endregion

            }
            else
            {
                MessageBox.Show("Greska u unosu", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
