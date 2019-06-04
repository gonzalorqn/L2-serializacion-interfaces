using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public interface ISerializableXML
    {
        bool SerializarXML();
        ISerializableXML DeserializarXML();
        string Path
        {
            get;
            set;
        }
    }
}
