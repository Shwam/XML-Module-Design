﻿using System;
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
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path + "SampleInput.xml");
            string xml = xdoc.InnerXml;

            XmlSerializer serializer = new XmlSerializer(typeof(ModularDataEntries));
            xi = (ModularDataEntries)serializer.Deserialize(new StringReader(xml));

            InitializeComponent();

            

            lb.DataContext = xi.DataModules;
        }

        private void _add_Click(object sender, RoutedEventArgs e)
        {
            xi.DataModules.Add(new ModularData(_name.Text, 0, _desc.Text, _datatype.Text));
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
