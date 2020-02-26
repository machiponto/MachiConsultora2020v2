using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Excepciones
{
    public class DalExcepcion : Exception
    {

        public DalExcepcion(string mensaje)
            : base(mensaje)
        {

        }

        public DalExcepcion(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }


    }
}
