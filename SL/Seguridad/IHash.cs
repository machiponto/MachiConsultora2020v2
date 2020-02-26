using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace SL.Seguridad
{
    public interface IHash
    {

        string obtenerHash(string pCadena);

    }
}
