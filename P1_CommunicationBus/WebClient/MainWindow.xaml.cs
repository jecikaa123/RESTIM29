using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;
using Common;
using Common.CommunicationBus;
using Common.CommunicationModel;
using Common.JsonToXmlAdapter;
using Common.DataModel;
using Newtonsoft.Json; // Nuget Package


namespace WebClient
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
            UrlToRequest urlToRequest = new UrlToRequest();
            Request request = urlToRequest.ConvertUrl(TextBoxEnter.Text);
            string json = JsonConvert.SerializeObject(request);
            CommBus cmb = new CommBus();
            string response = cmb.SendRequest(json);

            txtBoxResponse.Text = response;
        }
    }
}

