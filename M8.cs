using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador_Curso_.NET
{
    public class M8 : Operador
    {
        public M8() : base()
        {
            Tipo = "M8";
            Bateria = new Bateria(12250);
            CargaMaxima = 250;
            CargaActual = new Random().Next(0, CargaMaxima);
        }
    }
}

