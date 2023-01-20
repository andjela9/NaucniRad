using NaucniRad.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Stopwatch stopwatch = new Stopwatch();
        Answer answer = new Answer();

        int ispitanikId;
        
        int errors = 0;
        Question currentQuestion = new Question();
        
        
        public QuestionWindow(int sekcija, int id)
        {
            InitializeComponent();
            Dugme.Focus();
            prosledjenjaSekcija = sekcija;
            ispitanikId = id;

            switch (sekcija)
            {
                case 1:
                    kategorijaLevoTxt1.Text = "Osoba sa invaliditetom";
                    kategorijaLevoTxt1.Foreground = Brushes.Chartreuse;
                    kategorijaLevoTxt1.VerticalAlignment= VerticalAlignment.Center;
                    kategorijaLevoTxt2.Text = "";
                    kategorijaDesnoTxt1.Text = "Osoba tipične populacije";
                    kategorijaDesnoTxt1.Foreground = Brushes.Chartreuse;
                    kategorijaDesnoTxt1.VerticalAlignment = VerticalAlignment.Center;
                    kategorijaDesnoTxt2.Text = "";
                    foreach (Question q in questionOrder.section1Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 2:
                    kategorijaLevoTxt1.Text = "LOŠE";
                    kategorijaLevoTxt1.Foreground = Brushes.Blue;
                    kategorijaLevoTxt1.VerticalAlignment = VerticalAlignment.Center;
                    kategorijaLevoTxt2.Text = "";
                    kategorijaDesnoTxt1.Text = "DOBRO";
                    kategorijaDesnoTxt1.Foreground = Brushes.Blue;
                    kategorijaDesnoTxt1.VerticalAlignment = VerticalAlignment.Center;
                    kategorijaDesnoTxt2.Text = "";
                    foreach (Question q in questionOrder.section2Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 3:
                    kategorijaLevoTxt1.Foreground = Brushes.Blue;
                    kategorijaLevoTxt2.Foreground = Brushes.Chartreuse;
                    kategorijaDesnoTxt1.Foreground = Brushes.Blue;
                    kategorijaDesnoTxt2.Foreground = Brushes.Chartreuse;
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba sa invaliditetom";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba tipične populacije";
                    }
                    else
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba tipične populacije";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba sa invaliditetom";
                    }
                    foreach (Question q in questionOrder.section3Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 4:
                    kategorijaLevoTxt1.Foreground = Brushes.Blue;
                    kategorijaLevoTxt2.Foreground = Brushes.Chartreuse;
                    kategorijaDesnoTxt1.Foreground = Brushes.Blue;
                    kategorijaDesnoTxt2.Foreground = Brushes.Chartreuse;
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba sa invaliditetom";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba tipične populacije";
                    }
                    else
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba tipične populacije";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba sa invaliditetom";
                    }
                    foreach (Question q in questionOrder.section4Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 5:
                    kategorijaLevoTxt1.Text = "Osoba tipične populacije";
                    kategorijaLevoTxt1.Foreground = Brushes.Chartreuse;
                    kategorijaLevoTxt2.Text = "";
                    kategorijaLevoTxt1.VerticalAlignment = VerticalAlignment.Center;
                    kategorijaDesnoTxt1.Text = "Osoba sa invaliditetom";
                    kategorijaDesnoTxt1.Foreground = Brushes.Chartreuse;
                    kategorijaDesnoTxt2.Text = "";
                    kategorijaDesnoTxt1.VerticalAlignment = VerticalAlignment.Center;
                    //TODO: ucitati items za sekciju 5
                    foreach (Question q in questionOrder.section1Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 6:
                    kategorijaLevoTxt1.Foreground = Brushes.Blue;
                    kategorijaLevoTxt2.Foreground = Brushes.Chartreuse;
                    kategorijaDesnoTxt1.Foreground = Brushes.Blue;
                    kategorijaDesnoTxt2.Foreground = Brushes.Chartreuse;
                    if (ispitanikId %2 == 0)
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba tipične populacije";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba sa invaliditetom";
                    }
                    else
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba sa invaliditetom";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba tipične populacije";
                    }
                    foreach (Question q in questionOrder.section6Questions)
                    {
                        items.Add(q);
                    }
                    break;
                case 7:
                    kategorijaLevoTxt1.Foreground = Brushes.Blue;
                    kategorijaLevoTxt2.Foreground = Brushes.Chartreuse;
                    kategorijaDesnoTxt1.Foreground = Brushes.Blue;
                    kategorijaDesnoTxt2.Foreground = Brushes.Chartreuse;
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba tipične populacije";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba sa invaliditetom";
                    }
                    else
                    {
                        kategorijaLevoTxt1.Text = "LOŠE";
                        kategorijaLevoTxt2.Text = "Osoba sa invaliditetom";
                        kategorijaDesnoTxt1.Text = "DOBRO";
                        kategorijaDesnoTxt2.Text = "Osoba tipične populacije";
                    }
                    foreach (Question q in questionOrder.section7Questions)
                    {
                        items.Add(q);
                    }
                    break;
                default:
                    kategorijaDesnoTxt1.Text = "";
                    kategorijaLevoTxt1.Text = "";
                    break;
            }
            //POSLE OVOGA SE ITEMS NAPUNE KAKO TREBA, VIDLJIVO JE SPOLJA

             currentQuestion = this.ChangeItem();
            if (currentQuestion.Path.EndsWith(".png"))
            {
                Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                stopwatch.Start();
                Reci.Text = "";
            }
            else 
            {
                Reci.Text = currentQuestion.Path;
                stopwatch.Start();
                Slika.Source = null;
            }
            answer.NumberOfErrors = 0;

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

        private void WriteToCsv(Answer ans)
        {
            var csv = new StringBuilder();
            int correct;
            if (ans.NumberOfErrors >= 1)
            {
                correct = 0;
            }
            else
            {
                correct = 1;
            }
            
            var newLine = $"{ans.Id},{ans.Section},{correct},{ans.Miliseconds}";
            csv.AppendLine(newLine);
            File.AppendAllText("../../AnswersExport.csv", csv.ToString());
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {

            //this.ispisiItems();                 //ovo se izvrsi na bilo koji taster
            // currentQuestion = this.ChangeItem();
            //ovde neka provera ako se zavrsava sa png da bude slika a text null, a ako ne slika je null a tekst je iz path
            //Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
            //TODO: zastiti i od prekoracenja, tj pozovi NextSection kad zavrsi sve
            //if (i == items.Count - 1)
            //{
            //    this.NextSection();
            //}

            switch (prosledjenjaSekcija)
            {
                case 1:
                    Reci.Visibility = Visibility.Hidden; 
                    
                    if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Disabled")
                    {
                        X.Visibility = Visibility.Hidden;
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(ispitanikId, "sekcija1", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                        //WriteToCsv(fix);
                        stopwatch.Reset();
                        stopwatch.Start();
                        //Testni.Text = "E_KeyDown i tacan odgovor";
                        //MessageBox.Show("E_KeyDown i tacan odgovor");
                        errors = 0;
                        answer.NumberOfErrors = 0;
                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        else
                        {
                            currentQuestion = this.ChangeItem();
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                        }
                        
                    }
                    else if (e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Abled")
                    {
                        X.Visibility = Visibility.Hidden;
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(ispitanikId, "sekcija1", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());       //ovo samo zapisati u fajl
                        //WriteToCsv(fix);


                        stopwatch.Reset();
                        stopwatch.Start();
                        //Testni.Text = "I_KeyDown i tacan odgovor";
                        //MessageBox.Show("I_KeyDown i tacan odgovor");
                        errors = 0;
                        answer.NumberOfErrors = 0;
                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        else
                        {
                            currentQuestion = this.ChangeItem();
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                        }
                        
                    }
                    else if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Abled")
                    {
                        //pogresan odgovor
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else if (e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Disabled")
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else
                    {

                    }
                    break;

                case 2:
                    Slika.Visibility = Visibility.Hidden;
                    Reci.Visibility = Visibility.Visible;
                    
                    
                    if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Bad")
                    {
                        X.Visibility = Visibility.Hidden;
                        
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(1, "sekcija2", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + answer.ToString());
                        stopwatch.Reset();
                        stopwatch.Start();
                        Testni.Text = "E_KeyDown i tacan odgovor";
                        errors = 0;
                        answer.NumberOfErrors = 0;

                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        currentQuestion = this.ChangeItem();
                        Reci.Text = currentQuestion.Path;
                    }
                    else if(e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Good")
                    {
                        X.Visibility = Visibility.Hidden;
                        
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(1, "sekcija2", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + answer.ToString());
                        stopwatch.Reset();
                        stopwatch.Start();
                        Testni.Text = "I_KeyDown i tacan odgovor";
                        errors = 0;
                        answer.NumberOfErrors = 0;

                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        currentQuestion = this.ChangeItem();
                        Reci.Text = currentQuestion.Path;
                    }
                    else if(e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Good")
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else if(e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Bad")
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else
                    {

                    }
                    break;


                case 3:             //isto je za 3 i 4

                    if (ispitanikId % 2 == 0)
                    {
                        if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "E_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija3", ms, errors, currentQuestion.Answer);

                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();
                            errors = 0;
                            answer.NumberOfErrors = 0;

                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "I_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija3", ms, errors, currentQuestion.Answer);

                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();
                            errors = 0;
                            answer.NumberOfErrors = 0;

                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        } 
                    }

                    else
                    {
                        if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "E_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija3", ms, errors, currentQuestion.Answer);

                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();
                            errors = 0;
                            answer.NumberOfErrors = 0;

                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "I_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija3", ms, errors, currentQuestion.Answer);

                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();
                            errors = 0;
                            answer.NumberOfErrors = 0;

                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }

                    }
                    break;

                case 4:
                    if (ispitanikId %2 == 0)
                    {
                        if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "E_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija4", ms, errors, currentQuestion.Answer);

                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();
                            errors = 0;
                            answer.NumberOfErrors = 0;

                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "I_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija4", ms, errors, currentQuestion.Answer);
                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();

                            errors = 0;
                            answer.NumberOfErrors = 0;
                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        } 
                    }
                    else
                    {
                        if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "E_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija4", ms, errors, currentQuestion.Answer);

                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();
                            errors = 0;
                            answer.NumberOfErrors = 0;

                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            Testni.Text = "I_KeyDown i tacan odgovor";
                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija4", ms, errors, currentQuestion.Answer);
                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();

                            errors = 0;
                            answer.NumberOfErrors = 0;
                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                    }
                    break;

                
                case 5:
                    Reci.Visibility = Visibility.Hidden;
                    if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Abled")
                    {
                        X.Visibility = Visibility.Hidden;
                              //predji na sledece pitanje
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(ispitanikId, "sekcija5", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                        
                        stopwatch.Reset();
                        stopwatch.Start();
                        //Testni.Text = "E_KeyDown i tacan odgovor";
                        //MessageBox.Show("E_KeyDown i tacan odgovor");

                        errors = 0;
                        answer.NumberOfErrors = 0;
                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        else
                        {
                            currentQuestion = this.ChangeItem();
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));
                        }

                    }
                    else if (e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Disabled")
                    {
                        X.Visibility = Visibility.Hidden;
                       
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(ispitanikId, "sekcija5", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                        
                        stopwatch.Reset();
                        stopwatch.Start();

                        Testni.Text = "I_KeyDown i tacan odgovor";
                        //MessageBox.Show("I_KeyDown i tacan odgovor");
                        errors = 0;
                        answer.NumberOfErrors = 0;
                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        else
                        {
                            currentQuestion = this.ChangeItem();
                            Slika.Source = new BitmapImage(new Uri(currentQuestion.Path, UriKind.Relative));

                        }
                    }
                    else if (e.Key == Key.E && e.IsDown && currentQuestion.Answer == "Disabled")
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        //pogresan odgovor
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else if (e.Key == Key.I && e.IsDown && currentQuestion.Answer == "Abled")
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else
                    {

                    }
                    break;
                  
                case 6:
                    if (ispitanikId %2 == 0)
                    {
                        if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija6", ms, errors, currentQuestion.Answer);

                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();

                            Testni.Text = "E_KeyDown i tacan odgovor";
                            errors = 0;
                            answer.NumberOfErrors = 0;
                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija6", ms, errors, currentQuestion.Answer);
                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();

                            Testni.Text = "I_KeyDown i tacan odgovor";
                            errors = 0;
                            answer.NumberOfErrors = 0;
                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        } 
                    }
                    else
                    {
                        if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija6", ms, errors, currentQuestion.Answer);

                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();

                            Testni.Text = "E_KeyDown i tacan odgovor";
                            errors = 0;
                            answer.NumberOfErrors = 0;
                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                        {
                            X.Visibility = Visibility.Hidden;

                            stopwatch.Stop();
                            double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                            answer.Miliseconds = ms;
                            answer.CorrectAnswer = currentQuestion.Answer;
                            Answer fix = new Answer(ispitanikId, "sekcija6", ms, errors, currentQuestion.Answer);
                            //allAnswers.AddAnswer(answer);
                            //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                            WriteToCsv(fix);
                            stopwatch.Reset();
                            stopwatch.Start();

                            Testni.Text = "I_KeyDown i tacan odgovor";
                            errors = 0;
                            answer.NumberOfErrors = 0;
                            i++;
                            if (i == items.Count)
                            {
                                this.NextSection();
                            }
                            else
                            {
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

                        }
                        else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Abled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                        else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Disabled"))
                        {
                            errors++;
                            answer.NumberOfErrors = errors;
                            X.Visibility = Visibility.Visible;
                            stopwatch.Reset();
                            stopwatch.Start();
                        }
                    }
                    break;

                case 7:
                    
                   
                    if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                    {
                        X.Visibility = Visibility.Hidden;
                       
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(ispitanikId, "sekcija7", ms, errors, currentQuestion.Answer);
                        
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                        WriteToCsv(fix);
                        stopwatch.Reset();
                        stopwatch.Start();

                        Testni.Text = "E_KeyDown i tacan odgovor";
                        errors = 0;
                        answer.NumberOfErrors = 0;
                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        else
                        {
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
                        
                    }
                    else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                    {
                        X.Visibility = Visibility.Hidden;
                       
                        stopwatch.Stop();
                        double ms = stopwatch.ElapsedMilliseconds;          //ovako ce se dobiti samo koliko treba da se stisne taster, 350ak ticks
                        answer.Miliseconds = ms;
                        answer.CorrectAnswer = currentQuestion.Answer;
                        Answer fix = new Answer(ispitanikId, "sekcija7", ms, errors, currentQuestion.Answer);
                        //allAnswers.AddAnswer(answer);
                        //MessageBox.Show("Ms: " + ms.ToString() + fix.ToString());
                        WriteToCsv(fix);
                        stopwatch.Reset();
                        stopwatch.Start();

                        Testni.Text = "I_KeyDown i tacan odgovor";
                        errors = 0;
                        answer.NumberOfErrors = 0;
                        i++;
                        if (i == items.Count)
                        {
                            this.NextSection();
                        }
                        else
                        {
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
                        
                    }
                    else if (e.Key == Key.E && e.IsDown && (currentQuestion.Answer == "Good" || currentQuestion.Answer == "Disabled"))
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    else if (e.Key == Key.I && e.IsDown && (currentQuestion.Answer == "Bad" || currentQuestion.Answer == "Abled"))
                    {
                        errors++;
                        answer.NumberOfErrors = errors;
                        X.Visibility = Visibility.Visible;
                        stopwatch.Reset();
                        stopwatch.Start();
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
            if (prosledjenjaSekcija == 7)
            {
                #region testiranje
                //string s = allAnswers1.ToString() + "\n" + allAnswers2.ToString() + "\n" + allAnswers3.ToString() + "\n" + allAnswers4.ToString() + "\n"
                //    + allAnswers5.ToString() + "\n" + allAnswers6.ToString() + "\n" + allAnswers7.ToString();    
                //Testiranje testiranje = new Testiranje(s);
                //this.Close();
                //testiranje.ShowDialog();

                //AllAnswers fix3 = new AllAnswers(allAnswers3.Section, allAnswers3.Answers);
                //allAnswersLista.Add(fix3);

                //AllAnswers fix4 = new AllAnswers(allAnswers4.Section, allAnswers4.Answers);
                //allAnswersLista.Add(fix4);

                //AllAnswers fix6 = new AllAnswers(allAnswers6.Section, allAnswers6.Answers);
                //allAnswersLista.Add(fix6);

                //AllAnswers fix7 = new AllAnswers(allAnswers7.Section, allAnswers7.Answers);
                //allAnswersLista.Add(fix7);
                #endregion 

                //Testiranje testiranje = new Testiranje(allAnswers3.ToString() + "\n" + allAnswers4.ToString() + "\n" 
                //                                        + allAnswers6.ToString() + "\n" + allAnswers7.ToString());
                //this.Close();
                //testiranje.ShowDialog();

                Thanks thanks = new Thanks();
                this.Close();
                thanks.ShowDialog();
            }
            else
            {
                #region testiranje
                //if(prosledjenjaSekcija == 3)
                //{
                //    Testiranje testiranje3 = new Testiranje(allAnswers3.ToString());
                //    testiranje3.ShowDialog();
                //}
                //if (prosledjenjaSekcija == 4)
                //{
                //    Testiranje testiranje4 = new Testiranje(allAnswers4.ToString());
                //    testiranje4.ShowDialog();
                //}
                //if(prosledjenjaSekcija == 6)
                //{
                //    Testiranje testiranje6 = new Testiranje(allAnswers6.ToString());
                //    testiranje6.ShowDialog();
                //}
                #endregion

                Explanation expl = new Explanation(prosledjenjaSekcija + 1, ispitanikId);
                this.Close();
                expl.ShowDialog();
            }
            
        }


    }
}
