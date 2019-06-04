using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Persona : Humano, ISerializableXML, ISerializableBinario
    {
        public string nombre;
        public string apellido;

        public Persona()
        {

        }

        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Path
        {
            get;
            set;
        }

        bool ISerializableBinario.SerializarXML()
        {
            Console.WriteLine("Estoy en el metodo de binario");
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + " - Nombre: " + this.nombre + " - Apellido: " + this.apellido;
        }

        public ISerializableXML DeserializarXML()
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Persona));
                StreamReader sr = new StreamReader(this.Path);
                ISerializableXML p = (Persona)serializador.Deserialize(sr);
                sr.Close();
                return p;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool SerializarXML()
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Persona));
                StreamWriter sw = new StreamWriter(this.Path);
                serializador.Serialize(sw, this);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
