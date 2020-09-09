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
using Common;
using Common.Model;
using Newtonsoft.Json;

namespace WebClientComponent
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
            Validations.UrlValid(requestTextBox.Text);
            JSONRequestModel JSONRequest = JSONRequestGenerator.StringToJSON(requestTextBox.Text);
            string json = JsonConvert.SerializeObject(JSONRequest, Formatting.Indented);
            outLabel.Content = json;
        }
    }
}
