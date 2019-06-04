using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    public class Humano : ISerializableXML
    {
        private int _dni;

        public int Dni
        {
            get { return this._dni; }
            set { this._dni = value; }
        }

        string ISerializableXML.Path
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "DNI: " + this._dni; 
        }

        ISerializableXML ISerializableXML.DeserializarXML()
        {
            throw new NotImplementedException();
        }

        bool ISerializableXML.SerializarXML()
        {
            throw new NotImplementedException();
        }
    }
}
