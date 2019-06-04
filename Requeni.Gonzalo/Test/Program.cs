using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Xml.Serialization;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Humano> h = new List<Humano>();
            Humano h1 = new Humano();
            h1.Dni = 12345678;
            if (Program.SerializarHumano(h1) == true)
            {
                Console.WriteLine("Se serializo correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo serializar correctamente");
            }
            Persona p1 = new Persona("Juan", "Perez");
            p1.Dni = 87654321;
            Alumno a1 = new Alumno();
            a1.Dni = 45235674;
            a1.Legajo = 15438;
            a1.nombre = "Roberto";
            a1.apellido = "Rodriguez";
            ((ISerializableBinario)p1).SerializarXML();
            if(Program.SerializarAlumno(a1) == true)
            {
                Console.WriteLine("Se serializo correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo serializar correctamente");
            }
            Profesor pr1 = new Profesor();
            pr1.Dni = 86421571;
            pr1.Titulo = "Programacion";
            pr1.nombre = "Raul";
            pr1.apellido = "Martinez";
            if (Program.SerializarHumano(pr1) == true)
            {
                Console.WriteLine("Se serializo correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo serializar correctamente");
            }
            h.Add(h1);
            h.Add(p1);
            h.Add(a1);
            h.Add(pr1);

            Console.ReadLine();
            Alumno a2 = Program.DeserializarAlumno();
            if(a2 != null)
            {
                Console.WriteLine(a2);
            }
            else
            {
                Console.WriteLine("No se pudo deserializar");
            }

            Humano h2 = Program.DeserializarHumano();
            if (a2 != null)
            {
                Console.WriteLine(h2);
            }
            else
            {
                Console.WriteLine("No se pudo deserializar");
            }
            Humano h3 = Program.DeserializarHumano();
            if (a2 != null)
            {
                Console.WriteLine(h3);
            }
            else
            {
                Console.WriteLine("No se pudo deserializar");
            }
            Console.ReadLine();

            if (Program.SerializarLista(h) == true)
            {
                Console.WriteLine("Se serializo correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo serializar correctamente");
            }
            Console.ReadLine();
        }

        public static bool SerializarAlumno(Alumno a)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof (Alumno));
                StreamWriter sw = new StreamWriter("D:\\alumno.xml");
                serializador.Serialize(sw, a);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Alumno DeserializarAlumno()
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Alumno));
                StreamReader sr = new StreamReader("D:\\alumno.xml");
                Alumno a = (Alumno)serializador.Deserialize(sr);
                sr.Close();
                return a;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static bool SerializarHumano(Humano h)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Humano));
                StreamWriter sw = new StreamWriter("D:\\humano.xml");
                serializador.Serialize(sw, h);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Humano DeserializarHumano()
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Humano));
                StreamReader sr = new StreamReader("D:\\humano.xml");
                Humano h = (Humano)serializador.Deserialize(sr);
                sr.Close();
                return h;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool SerializarLista(List<Humano> l)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<Humano>));
                StreamWriter sw = new StreamWriter("D:\\lista.xml");
                serializador.Serialize(sw, l);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Humano> DeserializarLista()
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<Humano>));
                StreamReader sr = new StreamReader("D:\\humano.xml");
                List<Humano> h = (List<Humano>)serializador.Deserialize(sr);
                sr.Close();
                return h;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
