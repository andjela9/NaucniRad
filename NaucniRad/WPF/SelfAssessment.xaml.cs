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
    /// Interaction logic for SelfAssessment.xaml
    /// </summary>
    public partial class SelfAssessment : Window
    {
        public SelfAssessment(Ispitanik ispitanik)
        {
            InitializeComponent();
            ispitanik.SelfAssessment = 3;
            MessageBox.Show(ispitanik.ToString());
        }

        private void selfAssesmentDalje_Click(object sender, RoutedEventArgs e)
        {
            Explanation expl = new Explanation(1);
            this.Close();
            expl.ShowDialog();
        }
    }
}
