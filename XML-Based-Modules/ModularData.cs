using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML_Based_Modules
{
    [XmlRoot()]
    public class ModularDataEntries
    {
        private ObservableCollection<ModularData> dataModules;

        public ObservableCollection<ModularData> DataModules
        {
            get { return dataModules; }
            set { dataModules = value; }
        }

    }

    public class ModularData
    {
        private string name;
        private int id;
        private string description;
        private string dataType;

        public ModularData() { }
        public ModularData(string _name, int _id, string _description, string _dataType)
        {
            name = _name;
            id = _id;
            description = _description;
            dataType = _dataType;
        }

        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlAttribute]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [XmlAttribute]
        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        public override string ToString()
        {
            string s = name + "\n";
            s += id + "\n";
            s += description + "\n";
            s += dataType;
            return s;
        }

        
    }
}
