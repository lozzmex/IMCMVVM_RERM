using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCMVVM_RERM.Models
{
    public class Persona
    {
        //Datos numericos necesarios para el calculo

        //son nuestras variables estas de aqui abajito <3
        public double Peso { get; set; }
        public double Estatura { get; set; }


        //Este es el metodo que devuelve el IMC utilizando los datos de persona

        public double CalcularIMC()
        {
            return Peso / (Estatura * Estatura);
        }
    }
}
