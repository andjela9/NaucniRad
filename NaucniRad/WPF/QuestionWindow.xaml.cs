using NaucniRad.Model;
using System;
using System.Collections.Generic;
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

namespace NaucniRad.WPF
{
    /// <summary>
    /// Interaction logic for Question.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        public QuestionWindow(int sekcija)
        {
            InitializeComponent();
            QuestionOrder questionOrder = new QuestionOrder();
            List<Question> items = new List<Question>();

            switch (sekcija)
            {
                case 1:
                    kategorijaLevoTxt.Text = "Osoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "Osoba SA invaliditetom";
                    foreach(Question q in questionOrder.section1Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 2:
                    kategorijaLevoTxt.Text = "Loše";
                    kategorijaDesnoTxt.Text = "DOBRO";
                    foreach (Question q in questionOrder.section2Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 3:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba SA invaliditetom";
                    foreach (Question q in questionOrder.section3Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 4:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba SA invaliditetom";
                    foreach (Question q in questionOrder.section4Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 5:
                    kategorijaLevoTxt.Text = "Osoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "Osoba BEZ invaliditeta";
                    //TODO: ucitati items za sekciju 5
                    break;
                case 6:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba BEZ invaliditeta";
                    foreach (Question q in questionOrder.section6Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 7:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba BEZ invaliditeta";
                    foreach (Question q in questionOrder.section7Questions)
                    {
                        items.Add(q);
                    }
                    break;
                default:
                    kategorijaDesnoTxt.Text = "";
                    kategorijaLevoTxt.Text = "";
                    break;
            }


        }

        private void E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
                Testni.Text = "Kliknuto E";
            MessageBox.Show("Kliknuto E");
        }

        private void I_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I)
                Testni.Text = "Kliknuto I";
                MessageBox.Show("Kliknuto I");
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void I_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
