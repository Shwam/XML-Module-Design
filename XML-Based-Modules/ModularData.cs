using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XML_Based_Modules
{
    class ModularData
    {
        [XmlAttribute]
        private string name;
        [XmlAttribute]
        private int id;
        [XmlAttribute]
        private string description;
        [XmlAttribute]
        private string dataType;
        
    }
}
