using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador_Curso_.NET
{
    public class K9 : Operador
    {
        public K9() : base()
        {
            Tipo = "K9";
            Bateria = new Bateria(6500);
            CargaMaxima = 40;
            CargaActual = new Random().Next(0, CargaMaxima);
        }
    }
}
