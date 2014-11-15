using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML_Based_Modules
{
    [XmlRoot()]
    public class ModularDateEntries
    {
        private ModularData[] dataModules;

        public ModularData[] DataModules
        {
            get { return dataModules; }
            set { dataModules = value; }
        }
    }

    class ModularData
    {
        private string name;
        private int id;
        private string description;
        private string dataType;

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

        
    }
}
