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

namespace Client.Icons
{
    /// <summary>
    /// Логика взаимодействия для Icon.xaml
    /// </summary>
    public partial class Icon : UserControl
    {
        public Icon()
        {
            InitializeComponent();
        }



        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconTextProperty =
            DependencyProperty.Register("IconText", typeof(string), typeof(Icon), new PropertyMetadata(string.Empty));
    }
}
