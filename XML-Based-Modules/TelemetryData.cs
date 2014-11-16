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
    public class TelemetryMetaData
    {
        private ObservableCollection<TelemetryItem> telemetryItems;

        public ObservableCollection<TelemetryItem> TelemetryData
        {
            get { return telemetryItems; }
            set { telemetryItems = value; }
        }

    }

    public class TelemetryItem
    {
        private string name;
        private int id;
        private string description;
        private string dataType;

        public TelemetryItem() { }
        public TelemetryItem(string _name, int _id, string _description, string _dataType)
        {
            name = _name;
            id = _id;
            description = _description;
            dataType = _dataType;
        }

        [XmlElement]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [XmlElement]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [XmlElement]
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
