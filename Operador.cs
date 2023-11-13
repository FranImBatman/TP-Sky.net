using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador_Curso_.NET
{
    public abstract class Operador
    {
        public int ID { get; set; }
        public string EstadoGeneral { get; set; }
        public double VelocidadOptima { get; set; }
        public string LocalizacionActual { get; set; }
        public double CargaActual { get; set; }
        public string Tipo { get; protected set; }
        public Bateria Bateria { get; protected set; }
        public int CargaMaxima { get; protected set; }

        public Operador()
        {          
            asignarDatosGenerales();          
        }

        public void asignarDatosGenerales()
        {
            ID = new Random().Next(3500);
            EstadoGeneral = "Activo";
            VelocidadOptima = new Random().Next(30, 120);
            LocalizacionActual = asignarLocalizacion();
        }


        public string asignarLocalizacion()
        {
            List<string> localizaciones = new List<string>();

            localizaciones.Add("San Francisco");
            localizaciones.Add("Amsterdam");
            localizaciones.Add("Manchester");
            localizaciones.Add("Copenhague");
            localizaciones.Add("Nueva York");
            localizaciones.Add("Montreal");
            localizaciones.Add("Praga");
            localizaciones.Add("Tel Aviv");
            localizaciones.Add("Oporto");
            localizaciones.Add("Tokio");
            localizaciones.Add("Los Ángeles");
            localizaciones.Add("Chicago");
            localizaciones.Add("Londres");
            localizaciones.Add("Barcelona");
            localizaciones.Add("Melbourne");
            localizaciones.Add("Sídney");
            localizaciones.Add("Shanghái");
            localizaciones.Add("Madrid");
            localizaciones.Add("Buenos Aires");
            
            return localizaciones[new Random().Next(localizaciones.Count)];
        }
        
//      public void moverseHaciaOtraLocalizacion(string localizacionDestino)
//      {
//          double distanciaARecorrer = new Random().Next(80, 200);
//          double velocidadActual = this.velocidadOptima;
//          double capacidadBateria = this.bateria.Capacidad; //miliAmperios.
//          double cargaActual = this.bateria.Carga;    //Porcentaje de carga restante.
//
//          double distanciaRecorrida = 0; 
//          double capacidadConsumidaPorUnidad = capacidadBateria * 0.01; //Capacidad consumida cada 1% de bateria.
//          double capacidadConsumidaTotal = 0;
//          double cargaConsumida = 0;
//          double tiempoDeUso = capacidadConsumidaPorUnidad / 1000; //Tiempo en horas para consumir el 1% teniendo en cuenta que en una hora consumimos 1000mA.               
//
//
//          while (distanciaRecorrida < distanciaARecorrer && cargaActual > 0) 
//          {                              
//              capacidadConsumidaTotal += capacidadConsumidaPorUnidad; 
//              cargaConsumida++;
//              
//              distanciaRecorrida += velocidadActual * tiempoDeUso; //Distancia que recorro cada 1% de uso.
//
//              if (cargaConsumida % 10 == 0)
//              {                   
//                  velocidadActual *= 0.95;
//              }
//
//              cargaActual--;                          
//                            
//          }
//
//          double miliAmperiosRestantes = capacidadBateria - capacidadConsumidaTotal;
//         
//          this.bateria.Capacidad = miliAmperiosRestantes;
//          this.bateria.Carga = cargaActual;
//
//          Console.WriteLine("El Operador se desplazó hacia {0} que esta a {1} KM y recorrió {2} KM, su bateria restante es {3}mA - {4}%.", localizacionDestino, distanciaARecorrer, distanciaRecorrida, miliAmperiosRestantes, cargaActual);
//
//      }
        
        public void desplazarseDeLocalizacion(string localizacionDestino)
        {
            double distanciaARecorrer = new Random().Next(50, 300);
            double distanciaCapazDeRecorrer = distanciaQuePuedoRecorrer();

            if (distanciaCapazDeRecorrer > distanciaARecorrer)
            {
                double velocidadEfectiva = calcularVelocidadEfectiva();              
                double miliAmperiosConsumidos = miliAmperiosEnDistancia(velocidadEfectiva, distanciaARecorrer);
                consumirEnergia(miliAmperiosConsumidos);
                LocalizacionActual = localizacionDestino;
                Console.WriteLine("El Operador recorrio una distancia de {0}km hacia {1} con una carga de {2}kg a una velocidad constante de {3}km/h. Su bateria restante es de {4}mA - {5}%.", distanciaARecorrer, localizacionDestino, CargaActual, velocidadEfectiva, miliAmperiosRestantes(), bateriaRestante());
            }         
            else
            {
                Console.WriteLine("El Operador no puede llegar a destino, bateria insuficiente.");
            }
        }

        public void transferirCargaDeBateria(Operador operadorEmisor ,Operador operadorReceptor)
        {                     
            double conversionBaterias = conversionDeCargas(operadorEmisor, operadorReceptor); // Devuelve cuanto % representan los mA restantes en el emisor con respecto al maximo de mA del receptor.

            double cargaQueAceptaElReceptor = operadorReceptor.capacidadMaximaBateria() - operadorReceptor.miliAmperiosRestantes(); // Maximo de mA que puede cargar.

            double cargaProvistaPorEmisor = (conversionBaterias / 100) * operadorReceptor.capacidadMaximaBateria(); //mA que provee el receptor.

            if (cargaProvistaPorEmisor <= cargaQueAceptaElReceptor)
            {                           
                operadorEmisor.consumirEnergia(cargaProvistaPorEmisor);
                operadorReceptor.cargarEnergia(cargaProvistaPorEmisor);
            }
            else
            {               
                operadorEmisor.consumirEnergia(cargaQueAceptaElReceptor);
                operadorReceptor.cargarEnergia(cargaQueAceptaElReceptor);
            }

            Console.WriteLine("Transferencia exitosa!");
            
        }

        public void transferirCargaFisica(Operador operadorA, Operador operadorB)
        {
            double cargaEmisor = operadorA.CargaActual;
            double cargaQueAceptaReceptor = operadorB.CargaMaxima - operadorB.CargaActual;

            if(cargaEmisor <= cargaQueAceptaReceptor)
            {
                operadorB.CargaActual += cargaEmisor;
            }
            else
            {
                Console.WriteLine("La carga que deseas transferir al otro Operador excede sus limites.");
            }
        }

        public void volverAlCuartelCargaFisica()
        {
            this.LocalizacionActual = "Cuartel";
            this.CargaActual = 0;
        }

        public void volverAlCuartelBateria()
        {
            this.LocalizacionActual = "Cuartel";
            double cargaMaxima = capacidadMaximaBateria() - miliAmperiosRestantes();
            this.cargarEnergia(cargaMaxima);
        } 

        public void intentoTransferirBateria(Operador operadorA, Operador operadorB)
        {
            if(comprobarMismaLocalizacion(operadorA ,operadorB))
            {
                transferirCargaDeBateria(operadorA, operadorB);
            }
            else
            {
                Console.WriteLine("Los operadores no se encuentran en el mismo sitio. No se puede realizar la transferencia.");
            }
        }

        public void intentoTransferirCarga(Operador operadorA, Operador operadorB) 
        {
            if (comprobarMismaLocalizacion(operadorA, operadorB))
            {
                transferirCargaFisica(operadorA, operadorB);
            }
            else 
            {
                Console.WriteLine("Los operados no se encuentran en el mismo sitio.");                 
            }
        }

        public double conversionDeCargas(Operador operadorEmisor, Operador operadorReceptor)
        {
            double mA_ActualesEmisor = operadorEmisor.miliAmperiosRestantes();

            double capacidadMaximaReceptor = operadorReceptor.Bateria.CapacidadMax;

            double equivalenteEnReceptor = (mA_ActualesEmisor / capacidadMaximaReceptor) * 100;                   

            return equivalenteEnReceptor;
        }
        

        public double calcularVelocidadEfectiva()
        {
            double velocidadEfectiva = VelocidadOptima;
            if(CargaActual > 0) 
            {
                double porcentajeDeCarga = calcularPorcentajeDeCarga();
                velocidadEfectiva = velocidadEfectiva * (1 - 0.05 * (porcentajeDeCarga / 0.10));
            }
            return velocidadEfectiva;
        }

        public double calcularPorcentajeDeCarga()
        {
            double porcentaje = CargaActual / CargaMaxima;
            return porcentaje;
        }

        public double distanciaQuePuedoRecorrer()
        {
            double velocidadEfectiva = calcularVelocidadEfectiva();
            double mA_Restantes = miliAmperiosRestantes();
            return (velocidadEfectiva * mA_Restantes) / 1000; 
        }
        
        public double miliAmperiosEnDistancia(double velocidad, double distancia)
        {
            return (distancia / velocidad) * 1000;  
        }

        public void consumirEnergia(double mA)
        {
            Bateria.consumirMiliAmperios(mA);
        }

        public void cargarEnergia(double mA)
        {
            Bateria.cargarBateria(mA);  
        }
        
        public bool comprobarMismaLocalizacion(Operador operadorA, Operador operadorB)
        {
            return operadorA.LocalizacionActual == operadorB.LocalizacionActual;
        }

       public double capacidadMaximaBateria()
        {
            return Bateria.CapacidadMax;
        }

        public double bateriaRestante()
        {
            return Bateria.Carga;
        }

        public double miliAmperiosRestantes()
        {
            return Bateria.mA_Restantes();
        }

        public double bateriaDecimal()
        {
            return Bateria.cargaEnDecimal();
        }


            
    }       
}
