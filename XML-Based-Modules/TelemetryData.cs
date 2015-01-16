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
        private dynamic value;
        
        public TelemetryItem() { }
        public TelemetryItem(byte[] _name, byte[] _id, byte[] _description, byte[] _dataType)
        {
            name = string.Join("", _name);
            id = BitConverter.ToInt32(_id, 0);
            description = string.Join("", _description);
            dataType = string.Join("", _dataType);
        }
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

        public dynamic Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public void SetValue(byte[] _value)
        {
            switch (DataType)
            {
                case "boolean":
                    break;
                case "char":
                    break;
                case "single":
                    break;
                case "double":
                    break;
                case "int16":
                    break;
                case "int32":
                    break;
                case "int64":
                    break;
                case "uint16":
                    break;
                case "uint32":
                    break;
                case "uint64":
                    break;
            }
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
