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

namespace exam_8
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

        private void LineBtn_Click(object sender, RoutedEventArgs e) => new LinesWindow().ShowDialog();

        private void StationBtn_Click(object sender, RoutedEventArgs e) => new StationsWindow().ShowDialog();

        private void TranstiBtn_Click(object sender, RoutedEventArgs e) => new TranstionsWindow().ShowDialog();
    }
}
