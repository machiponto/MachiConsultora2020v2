using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Excepciones
{
    public class WebExcepcion : Exception
    {

        public WebExcepcion(string mensaje)
            : base(mensaje)
        {

        }

        public WebExcepcion(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }


    }
}
