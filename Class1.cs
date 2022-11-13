using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Programa_1
{
    public class Proceso
    {
        public int ID;
        public string nombre;
        public int time;
        public float dato1;
        public float dato2;
        public string signo;
        public Proceso(int ID, string nombre, int time, float dato1, float dato2, string signo)
        {
            this.ID = ID;
            this.nombre = nombre;
            this.time = time;
            this.dato1 = dato1;
            this.dato2 = dato2;
            this.signo = signo;
        }
        public Proceso(){}
    }
}
