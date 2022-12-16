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
        public Explanation()
        {
            InitializeComponent();
            //ucitati sekciju
            int sekcija = 7;

            switch (sekcija)
            {
                case 1:
                    kategorijaLevoTxt.Text = "Osoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "Osoba SA invaliditetom";
                    sekcijaBrojTxt.Text = "Sekcija 1 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 1";
                    break;
                case 2:
                    kategorijaLevoTxt.Text = "Loše";
                    kategorijaDesnoTxt.Text = "Dobro";
                    sekcijaBrojTxt.Text = "Sekcija 2 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 2";
                    break;
                case 3:
                    kategorijaLevoTxt.Text = "Loše\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "Dobro\nOsoba SA invaliditetom";
                    sekcijaBrojTxt.Text = "Sekcija 3 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 3";
                    break;
                case 4:
                    kategorijaLevoTxt.Text = "Loše\nOsoba BEZ invaliditeta";
                    kategorijaDesnoTxt.Text = "Dobro\nOsoba SA invaliditetom";
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
                    kategorijaLevoTxt.Text = "Loše\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "Dobro\nOsoba BEZ invaliditeta";
                    sekcijaBrojTxt.Text = "Sekcija 6 od 7";
                    objasnjenjeTxt.Text = "Dugacak tekst 6";
                    break;
                case 7:
                    kategorijaLevoTxt.Text = "Loše\nOsoba SA invaliditetom";
                    kategorijaDesnoTxt.Text = "Dobro\nOsoba BEZ invaliditeta";
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

        private void ExplanationClick(object sender, RoutedEventArgs e)
        {
            Question question = new Question();
            this.Close();
            question.ShowDialog();
        }
    }
}
