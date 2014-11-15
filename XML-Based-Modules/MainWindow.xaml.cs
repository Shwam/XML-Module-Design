using System;
using System.IO;
using System.Windows;
using System.Xml;

namespace XML_Based_Modules
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string path = Directory.GetCurrentDirectory() + "../../../";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path + "SampleInput.xml");
            Console.WriteLine(xdoc.InnerXml);
            InitializeComponent();
        }
    }
}
