using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPersonas;
using System.IO;

namespace AdminPersonasModel.DAL
{
    public class PersonasDALArchivos : IPersonasDAL
    {
        private static string archivo = "personas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;
            //C:/Users/sistemas/VisualStud...
        public void AgregarPersona(Persona persona)
        {

            //1. Crear el StreamWriter
            //2. Agregar una linea del archivo
            //3. Cerrar el StreamWriter
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    string texto = persona.Nombre + ";" //CSV: Comma Separated Values
                        + persona.Estatura + ";"
                        + persona.Telefono + ";"
                        + persona.Peso + ";";
                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error al escribir en archivo " + ex.Message);
            }

        }

        public List<Persona> FiltrarPersonas(string nombre)
        {
            return ObtenerPersonas().FindAll(p => p.Nombre.ToLower() == nombre.ToLower());
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();
              using(StreamReader reader = new StreamReader(ruta))
            {
                string texto;
                do
                {

                    //Leer desde el archivo hasta que no haya nada
                    texto = reader.ReadLine(); //error
                    if (texto != null)
                    {
                        //Nombre;Estatura;Telefono;Peso;
                        string[] textoArr = texto.Trim().Split(';');
                        string nombre = textoArr[0];
                        double estatura = Convert.ToDouble(textoArr[1]);
                        uint telefono = Convert.ToUInt32(textoArr[2]);
                        double peso = Convert.ToDouble(textoArr[3]);

                        //crear una Persona
                        Persona p = new Persona()
                        {
                            Nombre = nombre,
                            Estatura = estatura,
                            Telefono = telefono,
                            Peso = peso
                        };
                        //* calcular su imc
                        p.calcularImc();
                        personas.Add(p);
                    }
                } while (texto != null);
            }

            return personas;
        }
    }
}
