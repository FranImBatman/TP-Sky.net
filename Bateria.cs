using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador_Curso_.NET
{
    public class Bateria
    {
        double capacidadMax;
        double carga;
        double mA_Consumidos;

        public Bateria(double capacidadMax)
        {
            this.capacidadMax = capacidadMax;
            this.mA_Consumidos = 0;
            this.carga = 100;
        }

        public double CapacidadMax { get { return capacidadMax; } set { capacidadMax = value; } }
        
        public double Carga { get {  return carga; } set {  carga = value; } }

        public double MiliAmperiosConsumidos { get { return mA_Consumidos; } set { mA_Consumidos = value; } }

        public void consumirMiliAmperios(double mA)
        {
            if(mA <= CapacidadMax - MiliAmperiosConsumidos)
            {
                MiliAmperiosConsumidos += mA;
                Carga -= (mA_Consumidos / capacidadMax) * 100;
            }
            else
            {
                Console.WriteLine("La cantidad a consumir supera los limites de la bateria. Se consumira el restante disponible.");
                MiliAmperiosConsumidos = CapacidadMax;
                Carga = 0;
            }
            
        }

        public void cargarBateria(double mA)
        {
            if(mA <= CapacidadMax - mA_Restantes())
            {
                MiliAmperiosConsumidos -= mA;
                Carga += (mA_Consumidos / capacidadMax) * 100;
            }
            else
            {
                Console.WriteLine("La carga que deseas realizar excede los limites de la bateria. Se cargara el maximo posible.");
                MiliAmperiosConsumidos = 0;
                Carga = 100;
            }
        }
       

        public double mA_Restantes()
        {
            return CapacidadMax - MiliAmperiosConsumidos;
        }

        public double cargaEnDecimal()
        {
            return Carga / 100;
        }
    }

}
