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
using ClassC1;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Onb1Click));
            void Onb1Click(object sender, RoutedEventArgs e)
            {
            long R = long.Parse(Real.Text);
            long Min = long.Parse(MinLimit.Text);
            long Max = long.Parse(MaxLimit.Text);
            long BH = long.Parse(MaxHeightBar.Text);
            
            RealHeight.Text = Convert.ToString((R - Min) * BH / (Max - Min));
            }
            

        }
    }
}
