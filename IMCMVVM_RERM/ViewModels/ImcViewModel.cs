using IMCMVVM_RERM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMCMVVM_RERM.ViewModels
{
    public class ImcViewModel : INotifyPropertyChanged
    {
        //Los entrys capturan texto, incluso al escribir numeros
        public string PesoT { get; set; } = "";
        public string EstaturaT { get; set; } = "";

        private string resultado = "Ingresa tus datos: ";

        public string Resultado 
        {
            get { return resultado; }
            set {
                resultado = value;
                //Avisar al label que el resultado cambio

                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Resultado)));
            }
            
        }
        // El boton usara este comando mediante binding
        public ICommand CalcularCommand {  get; }

        public ImcViewModel()
        {

            // Al ejecutar el comando se llama al calcular
            CalcularCommand = new Command(Calcular);
        }

        //El binding escucha este evento
        public event PropertyChangedEventHandler? PropertyChanged;

        private void Calcular()
        {
            // Validamos cada campo por separado

            double peso;
            bool pesoValido = double.TryParse(PesoT, out peso);

            if (pesoValido == false || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Escribe un peso válido mayor que cero.";
                return;
            }

            double estatura;
            bool estaturaValido = double.TryParse(EstaturaT, out estatura);

            if (estaturaValido == false || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Escribe una estatura válida mayor que cero.";
                return;
            }

            // Crear el modelo y le asignamos datos
            Persona persona = new Persona();
            persona.Peso = peso;
            persona.Estatura = estatura;

            //El modelo persona realiza la operacion o el calculo 

            double imc = persona.CalcularIMC();

            // Evitamos mostrar un resultado numerico inválido

            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y estatura.";

                return;
            }

            //F2 muestra el numero con 2 decimales

            // Identificar la categoría según el IMC

            if (imc < 18.5)
            {
                Resultado = "Tu IMC es: " + imc.ToString("F2")
                    + "\nPeso bajo";
            }
            else if (imc < 25)
            {
                Resultado = "Tu IMC es: " + imc.ToString("F2")
                    + "\nPeso normal";
            }
            else if (imc < 30)
            {
                Resultado = "Tu IMC es: " + imc.ToString("F2")
                    + "\nSobrepeso";
            }
            else
            {
                Resultado = "Tu IMC es: " + imc.ToString("F2")
                    + "\nObesidad";
            }
        }
    }
}
