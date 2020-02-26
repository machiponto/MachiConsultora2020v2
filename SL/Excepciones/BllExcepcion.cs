using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Excepciones
{
    public class BllExcepcion : Exception
    {

        public BllExcepcion(string mensaje)
            : base(mensaje)
        {

        }

        public BllExcepcion(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }


    }
}
