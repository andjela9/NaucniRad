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
    /// Interaction logic for Explanation.xaml
    /// </summary>
    public partial class Explanation : Window
    {

        //ucitati sekciju
        int prosledjenaSekcija;
        int ispitanikId;
        public Explanation(int sekcija, int id)
        {
            InitializeComponent();
            prosledjenaSekcija = sekcija;
            ispitanikId = id;
            Novo.Focus();
            //MessageBox.Show(prosledjenaSekcija.ToString());
            switch (sekcija)
            {
                case 1:
                    kategorijaLevoTxt.Text = "Osoba sa invaliditetom";
                    kategorijaDesnoTxt.Text = "Osoba tipične populacije";
                    sekcijaBrojTxt.Text = "Sekcija 1 od 7";
                    objasnjenjeTxt.Text = "Stavite prst leve ruke na taster E i pritisnite ga za svaku sliku koja pripada kategoriji\nOsoba sa invaliditetom.\nStavite prst desne ruke na taster I za slike koje pripadaju kategoriji\nOsoba tipične populacije.\nSlike će se pojavljivati jedna po jedna.\n";
                    break;
                case 2:
                    kategorijaLevoTxt.Text = "LOŠE";
                    kategorijaDesnoTxt.Text = "DOBRO";
                    sekcijaBrojTxt.Text = "Sekcija 2 od 7";
                    objasnjenjeTxt.Text = "Stavite prst leve ruke na taster E i pritisnite ga za svaku sliku koja pripada kategoriji\nLOŠE.\nStavite prst desne ruke na taster I za slike koje pripadaju kategoriji\nDOBRO.\nSlike će se pojavljivati jedna po jedna.\n";
                    break;
                case 3:
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba sa invaliditetom";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba tipične populacije";
                    }
                    else
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba tipične populacije";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba sa invaliditetom";
                    }
                    sekcijaBrojTxt.Text = "Sekcija 3 od 7";
                    objasnjenjeTxt.Text = "Pritisnite taster E za kategorije Osobe sa invaliditetom i LOŠE.\r\nPritisnite taster I za kategorije Osoba tipične populacije i DOBRO.\r\nSvaka stavka pripada samo jednoj kategoriji. Biće korištene iste slike i reči kao i u prva dva dela.\r\n";
                    break;
                case 4:
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba sa invaliditetom";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba tipične populacije";
                    }
                    else
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba tipične populacije";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba sa invaliditetom";
                    }
                    sekcijaBrojTxt.Text = "Sekcija 4 od 7";
                    objasnjenjeTxt.Text = "Pritisnite taster E za kategorije Osobe sa invaliditetom i loše.\r\nPritisnite taster I za kategorije Osoba tipične populacije i dobro.\r\nSvaka stavka pripada samo jednoj kategoriji. Biće korištene iste slike i reči kao i u prva dva dela.\r\n";
                    break;
                case 5:
                    kategorijaLevoTxt.Text = "Osoba tipične populacije";
                    kategorijaDesnoTxt.Text = "Osoba sa invaliditetom";
                    sekcijaBrojTxt.Text = "Sekcija 5 od 7";
                    objasnjenjeTxt.Text = "PAZITE, KATEGORIJE SU PROMENILE POZICIJE!\r\nStavite prst leve ruke na taster E i pritisnite ga za svaku sliku koja pripada kategoriji Osoba tipične populacije. \r\nStavite prst desne ruke na taster I za slike koje pripadaju kategoriji Osoba sa invaliditetom.\r\nSlike će se pojavljivati jedna po jedna.\r\n";
                    break;
                case 6:
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba tipične populacije";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba sa invaliditetom";
                    }
                    else
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba sa invaliditetom";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba tipične populacije";
                    }
                    sekcijaBrojTxt.Text = "Sekcija 6 od 7";
                    objasnjenjeTxt.Text = "Pritisnite taster E za kategorije Osoba tipične populacije i loše.\r\nPritisnite taster I za kategorije Osobe sa invaliditetom i dobro.\r\nSvaka stavka pripada samo jednoj kategoriji. Biće korišćene iste slike i reči kao i u prva dva dela.\r\n";
                    break;
                case 7:
                    if (ispitanikId % 2 == 0)
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba tipične populacije";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba sa invaliditetom";
                    }
                    else
                    {
                        kategorijaLevoTxt.Text = "LOŠE\nOsoba sa invaliditetom";
                        kategorijaDesnoTxt.Text = "DOBRO\nOsoba tipične populacije";
                    }
                    sekcijaBrojTxt.Text = "Sekcija 7 od 7";
                    objasnjenjeTxt.Text = "Ovaj deo je identičan prethodnom\r\nPritisnite taster E za kategorije Osoba tipične populacije i loše.\r\nPritisnite taster I za kategorije Osobe sa invaliditetom i dobro.\r\nSvaka stavka pripada samo jednoj kategoriji. Biće korišćene iste slike i reči kao i u prva dva dela.\r\n";
                    break;
                default:
                    kategorijaDesnoTxt.Text = "";
                    kategorijaLevoTxt.Text = "";
                    sekcijaBrojTxt.Text = "";
                    objasnjenjeTxt.Text = "";
                    break;
            }
            //case za sekciju
        }

        private void OpenQuestionWindow()
        {
            QuestionWindow questionWindow = new QuestionWindow(prosledjenaSekcija, ispitanikId);
            this.Close();
            questionWindow.ShowDialog();
        }

        //private void ExplanationClick(object sender, RoutedEventArgs e)
        //{
        //    this.OpenQuestionWindow();
        //}

        //private void Dugme_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.Key == Key.Space && e.IsDown)
        //    {
        //        MessageBox.Show("Kliknuto");
        //        this.OpenQuestionWindow();
        //    }
        //}

        //private void Dugme_Click(object sender, RoutedEventArgs e)
        //{
        //    this.OpenQuestionWindow();
        //}

        private void Novo_Click(object sender, RoutedEventArgs e)
        {
            QuestionWindow questionWindow = new QuestionWindow(prosledjenaSekcija, ispitanikId);
            this.Close();
            questionWindow.ShowDialog();
        }

        private void Novo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                QuestionWindow questionWindow = new QuestionWindow(prosledjenaSekcija, ispitanikId);
                this.Close();
                questionWindow.ShowDialog();
            }
            else
            {
                //MessageBox.Show("Kliknuto nesto drugo");
            }
        }
    }
}
