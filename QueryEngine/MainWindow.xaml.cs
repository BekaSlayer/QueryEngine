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

namespace QueryEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DataSource dataSource;
        public MainWindow()
        {
            var data = new Data();
            dataSource = data.GenerateSomeData();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var wholeString = string.Empty;
            var queryEngine = new Engine.Engine();
            foreach (var item in queryEngine.EngineStart(QueryTextBox.Text, dataSource))
            {
                wholeString = wholeString + item + "\n";
            }
            DataSourceTextBlock.Text = wholeString;
        }
    }
}
