using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador_Curso_.NET
{
    public class UAV : Operador
    {
        public UAV() : base()
        {
            Tipo = "UAV";
            Bateria = new Bateria(4000);
            CargaMaxima = 5;
            CargaActual = new Random().Next(0, CargaMaxima);
        }
    }
}
