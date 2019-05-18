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

namespace kursowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PartService partService;
        public MainWindow()
        {
            InitializeComponent();
            partService = PartService.GetInstance();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            partService.MakeBolid();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            partService.ForTest();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            partService.MakeWheel();
        }
    }
}
