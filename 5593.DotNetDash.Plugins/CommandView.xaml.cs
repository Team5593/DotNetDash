using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Team5593.Dashboard.Plugins
{
    public partial class CommandView : UserControl
    {
        public CommandView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("CommandView Button_Click.");
        }
    }
}
