using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void colorClick(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            //if(colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) // ... == DialogResult.OK)
            //{
            //    something.whatToColor = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B)
            //}
        }

        private void closeClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
