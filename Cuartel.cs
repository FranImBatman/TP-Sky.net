using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador_Curso_.NET
{
    public class Cuartel
    {
        List<Operador> todosLosOperadores = new List<Operador>();
        List<Operador> operadoresEnReserva = new List<Operador>();

        public Cuartel() { }

        public void listarEstados()
        {
            foreach(Operador o in todosLosOperadores)
            {
                Console.WriteLine("ID: {0} | Estado: {1}", o.ID, o.EstadoGeneral);
            }
        }

        public void listarEstadosPorLocalizacion(string localizacion)
        {
            foreach (Operador o in todosLosOperadores)
            {
                if(o.LocalizacionActual == localizacion)
                {
                    Console.WriteLine("ID: {0} | Estado: {1}", o.ID, o.EstadoGeneral);
                }
            }
        }

        public void totalRecall()
        {
            foreach(Operador o in todosLosOperadores)
            {
                o.LocalizacionActual = "Cuartel";
            }
        }

    }

}
