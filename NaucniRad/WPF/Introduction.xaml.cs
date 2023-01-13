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
    /// Interaction logic for Introduction.xaml
    /// </summary>
    public partial class Introduction : Window
    {
        int id;
        public Introduction(int ispId)
        {
            InitializeComponent();
            MessageBox.Show("Prosledjen ID: " + ispId.ToString());
            id = ispId;
            MessageBox.Show("Prosledjen ID: " + id.ToString());

        }

        private void explanationDalje_Click(object sender, RoutedEventArgs e)
        {
            Explanation expl = new Explanation(1, id);
            this.Close();
            expl.ShowDialog();
        }
    }
}
