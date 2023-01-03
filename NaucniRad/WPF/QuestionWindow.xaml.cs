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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;

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
            //Dugme.Focusable = true;
            Dugme.Focus();

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


            Slika.Source = new BitmapImage(new Uri(@"/Pictures90/icons8-dancing-90.png", UriKind.Relative));
            //string path = ChangeItem(items, 1);

        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E && e.IsDown)
            {
                this.E_Click(sender, e);
                Testni.Text = "E_KeyDown";
                //MessageBox.Show("E_KeyDown");
            }
            else if(e.Key == Key.I && e.IsDown)
            {
                this.I_Click(sender, e);
                Testni.Text = "I_KeyDown";
                //MessageBox.Show("I_KeyDown");
            } 
        }
        //private void E_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("E_Click");
        //}

        //private void I_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("I_Click");
        //}

        private void E_Click(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("E: neka akcija");
        }

        private void I_Click(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("I: neka akcija");
        }


        private void I_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.I)
            //{
            //    this.I_Click(sender, e);
            //    Testni.Text = "I_KeyDown";
            //    MessageBox.Show("I_KeyDown");
            //}

        }

        private void E_KeyDown(object sender, KeyEventArgs e)
        {

        }

        

        private string ChangeItem(List<Question> items, int i)
        {
            string ret = items[i].Path;
            //moze ovde da vraca listu ciji su elementi uredjeni parovi path i iteracija
            //pa ako su answer i ono stisnuto jednaki, uveca se br iteracije i tako se vrati

            return ret;
        }

      
    }
}

//<Button Name="E" Grid.Row="3" KeyDown="E_KeyDown" Click="E_Click" Grid.Column="0" Height="30" Width="30" HorizontalAlignment="Left" VerticalAlignment="Bottom" Visibility="Visible">E</Button>
//        < Button Name = "I" Grid.Row = "3" KeyDown = "I_KeyDown" Click = "I_Click" Grid.Column = "2" Height = "30" Width = "30" HorizontalAlignment = "Right" VerticalAlignment = "Bottom" Visibility = "Visible" > I </ Button >
