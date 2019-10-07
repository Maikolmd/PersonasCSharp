using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPersonas
{
    public struct IMC
    {
        public double Valor { get; set; }

        public String Texto
        {
            get
            {
                if (Valor < 20)
                {
                    return "Anorexico";
                }
                else if (Valor >= 20 && Valor <= 30)
                {
                    return "Gordo";
                }
                else
                {
                    return "Gordo de las historietas";
                }
            }

        }
    }
       
   public class Persona
    {
        private uint telefono;
        private double estatura;
        private double peso;
        private string nombre;
        private IMC imc;
        public uint Telefono
        {
            get
            { 
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public double Estatura
        {
            get
            {
                return estatura;
            }

            set
            {
                estatura = value;
            }
        }

        public double Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public void calcularImc()
        {
            double valor = Peso / (Estatura * Estatura);
            this.imc = new IMC() { Valor = valor };
            
        }
        public IMC IMC
        {
            get
            {
                return this.imc;
            }
        }
     

        public override string ToString()
        {

            return Nombre + " " + IMC.Texto;
        }
    }
}
