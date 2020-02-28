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

namespace DataGridControlLibrary
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
 
        }

 

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
             BarHeight.Height  = int.Parse(Input.Text) * 2;
        }

        private void abc()
        {

        }

        private void ggg(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
