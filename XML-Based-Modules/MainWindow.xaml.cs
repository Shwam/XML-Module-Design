using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;

namespace XML_Based_Modules
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TelemetryMetaData xi;
        public string path = Directory.GetCurrentDirectory() + "../../../";

        public MainWindow()
        {
            InitializeComponent();

            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.Load(path + "telemetry.xml");
                string xml = xdoc.InnerXml;
                WriteLine("Loaded default telemetry data");

                XmlSerializer serializer = new XmlSerializer(typeof(TelemetryMetaData));
                xi = (TelemetryMetaData)serializer.Deserialize(new StringReader(xml));
                lb.DataContext = xi.TelemetryData;
            }
            catch(FileNotFoundException e)
            {
                Clear();
                WriteLine("Could not find" + e.FileName);
                WriteLine("Please check that the file exists and that the correct filename is specified");
            }
            
        }

        private void _loadModules(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(path + "ModuleSave.xml");
                string xml = xdoc.InnerXml;

                XmlSerializer serializer = new XmlSerializer(typeof(TelemetryMetaData));
                xi = (TelemetryMetaData)serializer.Deserialize(new StringReader(xml));
                lb.DataContext = xi.TelemetryData;
                WriteLine("Loaded custom telemetry data");
            }
            catch(FileNotFoundException _e)
            {
                Clear();
                WriteLine("ERROR: Could not load custom telemetry data");
                WriteLine("Please verify file location before continuing");
            }
            catch(XmlException _e)
            {
                Clear();
                WriteLine("ERROR: reading XML MetaData");
                WriteLine("Please verify ModuleSave.xml is formatted correctly");
            }
        }

        private void WriteLine(string s)
        {
            _console.Text += s;
            _console.Text += "\n";
        }

        private void Clear()
        {
            _console.Text = "";
        }

        private void _lb_select(object sender, RoutedEventArgs e)
        {
            _remove.IsEnabled = lb.SelectedValue != null;
            Clear();
            if (lb.SelectedValue != null)
            {
                WriteLine(lb.SelectedValue.ToString());
            }
        }

        private void _clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void _add_Click(object sender, RoutedEventArgs e)
        {
            if (xi == null)
            {
                WriteLine("First load the telemetry data [Press Load]");
                return;
            }
            int id = -1;
            try
            {
                id = Convert.ToInt32(_id.Text);
            }
            catch (FormatException _e)
            {
                WriteLine("id FormatException (please enter an ID number)");
            }
            catch (OverflowException _e)
            {
                WriteLine("id OverflowException (int32)");
            }

            if (id >= 0)
            {
                TelemetryItem item = (new TelemetryItem(_name.Text, id, _desc.Text, _datatype.Text));
                xi.TelemetryData.Add(item);
                WriteLine("Added " + item.Name + " to telemetry data");
            }

        }

        private void _save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TelemetryMetaData));
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + "ModuleSave.xml");
                serializer.Serialize(file, xi);
                file.Close();
                WriteLine("Successfully overrode ModuleSave.xml");
            }
            catch(Exception _e)
            {
                WriteLine("Error - could not save ModuleSave.xml");
                WriteLine(_e.InnerException.ToString());
            }
        }

        private void _remove_Click(object sender, RoutedEventArgs e)
        {
            if (lb.SelectedValue != null)
            {
                xi.TelemetryData.Remove(lb.SelectedValue as TelemetryItem);
            }
            _remove.IsEnabled = lb.SelectedValue != null;

        }

    }
}
