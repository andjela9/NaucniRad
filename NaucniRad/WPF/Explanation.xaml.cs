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
        
        public Explanation(int sekcija)
        {
            InitializeComponent();

            switch (sekcija)
            {
                case 1:
                    kategorijaLevoTxt.Text = "Osoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "Osoba SA invaliditetom";
                    sekcijaBrojTxt.Text = "Sekcija 1 od 7";
                    objasnjenjeTxt.Text = "Stavite prst leve ruke na taster E i pritisnite ga za svaku sliku koja pripada kategoriji\nOsoba sa invaliditetom.\nStavite prst desne ruke na taster I za slike koje pripadaju kategoriji\nOsoba bez invaliditeta.\nSlike će se pojavljivati jedna po jedna.\n";
                    break;
                case 2:
                    kategorijaLevoTxt.Text = "LOŠE";
                    kategorijaDesnoTxt.Text = "DOBRO";
                    sekcijaBrojTxt.Text = "Sekcija 2 od 7";
                    objasnjenjeTxt.Text = "Stavite prst leve ruke na taster E i pritisnite ga za svaku sliku koja pripada kategoriji\nLOŠE.\nStavite prst desne ruke na taster I za slike koje pripadaju kategoriji\nDOBRO.\nSlike će se pojavljivati jedna po jedna.\n";
                    break;
                case 3:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba SA invaliditetom";
                    sekcijaBrojTxt.Text = "Sekcija 3 od 7";
                    objasnjenjeTxt.Text = "Pritisnite taster E za kategorije Osobe SA invaliditetom i LOŠE.\r\nPritisnite taster I za kategorije Osobe BEZ invaliditeta i DOBRO.\r\nSvaka stavka pripada samo jednoj kategoriji. Biće korištene iste slike i reči kao i u prva dva dela.\r\n";
                    break;
                case 4:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba SA invaliditetom";
                    sekcijaBrojTxt.Text = "Sekcija 4 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 4";
                    break;
                case 5:
                    kategorijaLevoTxt.Text = "Osoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "Osoba BEZ invaliditeta";
                    sekcijaBrojTxt.Text = "Sekcija 5 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 5";
                    break;
                case 6:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba BEZ invaliditeta";
                    sekcijaBrojTxt.Text = "Sekcija 6 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 6";
                    break;
                case 7:
                    kategorijaLevoTxt.Text = "LOŠE\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "DOBRO\nOsoba BEZ invaliditeta";
                    sekcijaBrojTxt.Text = "Sekcija 7 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 7";
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
            QuestionWindow questionWindow = new QuestionWindow(sekcija);
            this.Close();
            questionWindow.ShowDialog();
        }

        private void ExplanationClick(object sender, RoutedEventArgs e)
        {
            this.OpenQuestionWindow();
        }
    }
}
