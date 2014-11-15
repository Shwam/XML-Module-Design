﻿using System;
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
                WriteLine("First load the modules");
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

        private void _remove_Click(object sender, RoutedEventArgs e)
        {
            if (lb.SelectedValue != null)
            {
                xi.DataModules.Remove(lb.SelectedValue as ModularData);
            }
            _remove.IsEnabled = lb.SelectedValue != null;

        }

    }
}
