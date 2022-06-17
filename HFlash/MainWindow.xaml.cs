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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HFlash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(aaa.FirstSegment.Text) &&
                !String.IsNullOrEmpty(aaa.SecondSegment.Text) &&
                !String.IsNullOrEmpty(aaa.ThirdSegment.Text) &&
                !String.IsNullOrEmpty(aaa.LastSegment.Text))
            {

                MessageBox.Show(aaa.Address);
            }
        }
    }
}
