using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Based_Modules
{
    class ModularData
    {
        string Name;
        int Id;
        string Description;
        string Type;
        public ModularData() { }
        public ModularData(string name, int id, string description, string type)
        {
            Name = name;
            Id = id;
            Description = description;
            Type = type;
        }
        
    }
}
