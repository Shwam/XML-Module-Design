using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

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

            string xml = xdoc.InnerXml;

            XmlSerializer serializer = new XmlSerializer(typeof(ModularDataEntries));
            ModularDataEntries xi = (ModularDataEntries)serializer.Deserialize(new StringReader(xml));

            foreach (ModularData d in xi.DataModules)
            {
                Console.WriteLine(d.Name);
                Console.WriteLine(d.Id);
                Console.WriteLine(d.Description);
                Console.WriteLine(d.DataType);
            }
            InitializeComponent();
        }
    }
}
