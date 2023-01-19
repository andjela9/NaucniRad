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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NaucniRad.WPF
{
    /// <summary>
    /// Interaction logic for SelfAssessment.xaml
    /// </summary>
    public partial class SelfAssessment : Window
    {
        public List<Ispitanik> ucitanaLista = new List<Ispitanik> { };
        public Ispitanik ispitanik = new Ispitanik();
        public SelfAssessment(Ispitanik proslIspitanik)
        {
            InitializeComponent();
            ispitanik = proslIspitanik;
            //ispitanik.SelfAssessment = 3;
            //MessageBox.Show(ispitanik.ToString());

            try
            {
                XElement data = XElement.Load("../../Entries.xml");
                ucitanaLista = (from isp in data.Descendants("Ispitanik")
                                select new Ispitanik
                                {
                                    Id = Int32.Parse(isp.Element("Id").Value),
                                    Age = isp.Element("Age").Value,
                                    College = isp.Element("College").Value,
                                    Gender = isp.Element("Gender").Value,
                                    Course = isp.Element("Course").Value,
                                    Disability = isp.Element("Disability").Value,
                                    SelfAssessment = int.Parse(isp.Element("SelfAssessment").Value)
                                }
                                   ).ToList();
            }
            catch (Exception)
            {
                //ovde upada ako ne moze da ucita iz xml-a, tj xml je prazan
            }

        }

        private int ValidateInput()
        {
            if(n1.IsChecked == true)
            {
                return 1;
            }
            else if (n2.IsChecked == true)
            {
                return 2;
            }
            else if (n3.IsChecked == true)
            {
                return 3;
            }
            else if (n4.IsChecked == true)
            {
                return 4;
            }
            else if (n5.IsChecked == true)
            {
                return 5;
            }
            else if (n6.IsChecked == true)
            {
                return 6;
            }
            else if (n7.IsChecked == true)
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }

        private void selfAssesmentDalje_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput() != 0)
            {
                MessageBox.Show(ValidateInput().ToString());
                int id = ucitanaLista.Count() + 1;
                Ispitanik fix = new Ispitanik(id, ispitanik.Age, ispitanik.College, ispitanik.Gender, ispitanik.Course,
                                                ispitanik.Disability, ValidateInput());
                ucitanaLista.Add(fix);
                MessageBox.Show("Poslednji unos: \n" + "\nId: " + id + "\nGodine: " + ispitanik.Age + "\nFakultet: " + ispitanik.College
                    + "\nPol: " + ispitanik.Gender + "\nSmer: " + ispitanik.Course + "\nOsoba sa invaliditetom: " + ispitanik.Disability
                    + "\n Self Report: " + ValidateInput() + "\nBroj elemenata u listi: " + ucitanaLista.Count.ToString() + "\n");

                //MessageBox.Show(ListToString(ispitaniciLista));
                string s = "Lista iz programa\n";
                foreach (var ispitanik in ucitanaLista)
                {
                    s += ispitanik.Age + "\n";
                }
                //MessageBox.Show(s);

                XmlSerializer serializer = new XmlSerializer(ucitanaLista.GetType(), new XmlRootAttribute("Ispitanici"));         //ovo je okej
                using (TextWriter writer = new StreamWriter("../../Entries.xml"))                //okej
                {
                    serializer.Serialize(writer, ucitanaLista);
                    writer.Close();
                }

                //Explanation expl = new Explanation(1, ispitanik.Id);
                //this.Close();
                //expl.ShowDialog();
                Introduction ind = new Introduction(id);
                this.Close();
                ind.ShowDialog();
            }
            else
            {
                MessageBox.Show("Izaberite jedan od izbora" + ValidateInput().ToString());
            }

            
        }
    }
}
