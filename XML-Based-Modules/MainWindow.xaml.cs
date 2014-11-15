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
        public ModularDataEntries xi;
        public string path = Directory.GetCurrentDirectory() + "../../../";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void _loadModules(object sender, RoutedEventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path + "SampleInput.xml");
            string xml = xdoc.InnerXml;

            XmlSerializer serializer = new XmlSerializer(typeof(ModularDataEntries));
            xi = (ModularDataEntries)serializer.Deserialize(new StringReader(xml));
            lb.DataContext = xi.DataModules;

        }

        private void _add_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;
            try
            {
                id = Convert.ToInt32(_id.Text);
            }
            catch (FormatException _e)
            {
                Console.Write(_e);
            }
            catch (OverflowException _e)
            {
                Console.Write(_e);
            }

            if (id > 0)
            {
                ModularData item = (new ModularData(_name.Text, id, _desc.Text, _datatype.Text));
                xi.DataModules.Add(item);
            }
        }

        private void _save_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ModularDataEntries));
            System.IO.StreamWriter file = new System.IO.StreamWriter(path + "ModuleSave.xml");
            serializer.Serialize(file, xi);
            file.Close();
        }

    }
}
