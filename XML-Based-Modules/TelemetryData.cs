﻿using System;
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
            name = System.Text.Encoding.UTF8.GetString(_name);
            id = BitConverter.ToInt32(_id, 0);
            description = System.Text.Encoding.UTF8.GetString(_description);
            dataType = System.Text.Encoding.UTF8.GetString(_dataType);
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
                    value = BitConverter.ToBoolean(_value, 0);
                    break;
                case "char":
                    value = BitConverter.ToChar(_value, 0);
                    break;
                case "single":
                    value = BitConverter.ToSingle(_value, 0);
                    break;
                case "double":
                    value = BitConverter.ToDouble(_value, 0);
                    break;
                case "int16":
                    value = BitConverter.ToInt16(_value, 0);
                    break;
                case "int32":
                    value = BitConverter.ToInt32(_value, 0);
                    break;
                case "int64":
                    value = BitConverter.ToInt64(_value, 0);
                    break;
                case "uint16":
                    value = BitConverter.ToUInt16(_value, 0);
                    break;
                case "uint32":
                    value = BitConverter.ToUInt32(_value, 0);
                    break;
                case "uint64":
                    value = BitConverter.ToUInt64(_value, 0);
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
