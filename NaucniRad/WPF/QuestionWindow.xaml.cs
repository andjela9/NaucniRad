using NaucniRad.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        QuestionOrder questionOrder = new QuestionOrder();
        List<Question> items = new List<Question>();
        int i = 0;
        int prosledjenjaSekcija;
        public QuestionWindow(int sekcija)
        {
            InitializeComponent();
            //Dugme.Focusable = true;
            Dugme.Focus();
            prosledjenjaSekcija = sekcija;

            switch (sekcija)
            {
                case 1:
                    kategorijaLevoTxt.Text = "Osoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "Osoba BEZ invaliditeta";
                    foreach(Question q in questionOrder.section1Questions)
                    {
                        items.Add(q);
                    }
                    
                    break;
                case 2:
                    kategorijaLevoTxt.Text = "LOŠE";
                    kategorijaDesnoTxt.Text = "DOBRO";
                    foreach (Question q in questionOrder.section2Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 3:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba BEZ invaliditeta";
                    foreach (Question q in questionOrder.section3Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 4:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba BEZ invaliditeta";
                    foreach (Question q in questionOrder.section4Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 5:
                    kategorijaLevoTxt.Text = "Osoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "Osoba SA invaliditetom";
                    //TODO: ucitati items za sekciju 5
                    foreach (Question q in questionOrder.section1Questions)
                    {
                        items.Add(q);
                    }

                    break;
                case 6:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba SA invaliditetom";
                    foreach (Question q in questionOrder.section6Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 7:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba SA invaliditetom";
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
            //POSLE OVOGA SE ITEMS NAPUNE KAKO TREBA, VIDLJIVO JE SPOLJA

            Question currentQuestion = this.ChangeItem();
            if (currentQuestion.Path.EndsWith(".png"))
            {
                Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                Reci.Text = "";
            }
            else 
            {
                Reci.Text = currentQuestion.Path;
                Slika.Source = null;
            }
            


            //Slika.Source = new BitmapImage(new Uri(@"/Pictures90/icons8-dancing-90.png", UriKind.Relative));
            //string path = ChangeItem(items, 1);


        }

        private void ispisiItems()
        {
            //string s = "";
            //foreach (Question q in items)
            //{
            //    s += "\nPath " + q.Path + " , answer: " + q.Answer;
            //}
            //s += "\n Ukupno " + items.Count;
            MessageBox.Show(i.ToString());
        }

        public object NextItem(Question currentQ)
        {
            if (currentQ.Path.EndsWith(".png"))
            {
                Slika.Source = new BitmapImage(new Uri(currentQ.Path, UriKind.Relative));
                Reci.Text = "";
                return Slika.Source;
            }
            else
            {
                Reci.Text = currentQ.Path;
                Slika.Source = null;
                return Reci.Text;
            }
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //this.ispisiItems();                 //ovo se izvrsi na bilo koji taster
            
            Question currentQuestion = this.ChangeItem();
            //ovde neka provera ako se zavrsava sa png da bude slika a text null, a ako ne slika je null a tekst je iz path
            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
            
            //TODO: zastiti i od prekoracenja, tj pozovi NextSection kad zavrsi sve
            if(i == items.Count - 1)
            {
                this.NextSection();
            }

            switch (prosledjenjaSekcija)
            {
                case 1:
                case 5:
                    Reci.Visibility = Visibility.Hidden;
                    if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Disabled")
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;        //predji na sledece pitanje
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        Testni.Text = "E_KeyDown i tacan odgovor";
                        //MessageBox.Show("E_KeyDown i tacan odgovor");
                        currentQuestion = this.ChangeItem();
                        Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                        
                        
                    }
                    else if (e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Abled")
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "I_KeyDown i tacan odgovor";
                        //MessageBox.Show("I_KeyDown i tacan odgovor");
                        currentQuestion = this.ChangeItem();
                        Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                    }
                    else if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Abled")
                    {
                        //pogresan odgovor
                        X.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Disabled")
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    else
                    {

                    }

                    break;

                case 2:
                    Slika.Visibility = Visibility.Hidden;
                    Reci.Visibility = Visibility.Visible;
                    if(e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Bad")
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "E_KeyDown i tacan odgovor";
                        currentQuestion= this.ChangeItem();
                        Reci.Text = currentQuestion.Path;
                    }
                    else if(e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Good")
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "I_KeyDown i tacan odgovor";
                        currentQuestion= this.ChangeItem();
                        Reci.Text = currentQuestion.Path;
                    }
                    else if(e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Good")
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    else if(e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Bad")
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    else
                    {

                    }
                    break;


                case 3:             //isto je za 3 i 4
                case 4:
                    if(e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "E_KeyDown i tacan odgovor";
                        currentQuestion = this.ChangeItem();
                        if (currentQuestion.Path.EndsWith(".png"))
                        {
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                            Reci.Text = "";
                        }
                        else
                        {
                            Reci.Text = currentQuestion.Path;
                            Slika.Source = null;
                        }
                    }
                    else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "I_KeyDown i tacan odgovor";
                        currentQuestion = this.ChangeItem();
                        if (currentQuestion.Path.EndsWith(".png"))
                        {
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                            Reci.Text = "";
                        }
                        else
                        {
                            Reci.Text = currentQuestion.Path;
                            Slika.Source = null;
                        }
                    }
                    else if(e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    break;

                //case 5: TODO
                  
                case 6:
                case 7:
                    if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "E_KeyDown i tacan odgovor";
                        currentQuestion = this.ChangeItem();
                        if (currentQuestion.Path.EndsWith(".png"))
                        {
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                            Reci.Text = "";
                        }
                        else
                        {
                            Reci.Text = currentQuestion.Path;
                            Slika.Source = null;
                        }
                    }
                    else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                    {
                        X.Visibility = Visibility.Hidden;
                        i++;
                        Testni.Text = "I_KeyDown i tacan odgovor";
                        currentQuestion = this.ChangeItem();
                        if (currentQuestion.Path.EndsWith(".png"))
                        {
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                            Reci.Text = "";
                        }
                        else
                        {
                            Reci.Text = currentQuestion.Path;
                            Slika.Source = null;
                        }
                    }
                    else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                    {
                        X.Visibility = Visibility.Visible;
                    }
                    break;

                default: 
                    break;
            }

            
        }
        

        private Question ChangeItem()
        {
            return items[i];
        }

        private void NextSection()
        {
            //otvara se objasnjenje za novu sekciju
            //Explanation expl = new Explanation();
            //this.Close();
            //expl.ShowDialog();
            MessageBox.Show("Kraj sekcije");
            if (prosledjenjaSekcija == 7)
            {
                MessageBox.Show("Hvala!");
                this.Close();
            }
            else
            {
                Explanation expl = new Explanation(prosledjenjaSekcija + 1);
                this.Close();
                expl.ShowDialog();
            }
            
        }


    }
}
