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
using Common.JSONToXMLAdapter;
using Common.Helper;
using Common.Model;
using Common.JSONToXMLAdapter;
using Newtonsoft.Json;
using System.Xml.Linq;
using Common.XMLToDBAdapter;

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

            if (!Validations.UrlValid(requestTextBox.Text))
            {
                MessageBox.Show("Pls enter valid request.");
                return;
            }
            JSONRequestModel JSONRequest = JSONRequestGenerator.StringToJSON(requestTextBox.Text);
            string json = JsonConvert.SerializeObject(JSONRequest, Formatting.Indented);
            jsonLabel.Content = json;

            XNode xmlNode = JSONToXML.JSONToXMLGenerator(json);
            xmlNode.Document.Element("Verb");
            XElement element = xmlNode.Document.Element("JSONRequestModel");
            xmlLabel.Content = element.Element("Verb").Value;

            xmlLabel.Content = XMLToDBAdapter.XMLToSql(xmlNode);


            //outLabel.Content;
        }
    }
}
