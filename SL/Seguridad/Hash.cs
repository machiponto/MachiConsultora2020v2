using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace SL.Seguridad
{
    public class Hash : IHash
    {

        public string obtenerHash(string pCadena)
        {

            string textoPlano = pCadena;
            string hashkey = "*hg849gh84th==3tg7-534d=_";

            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] HashAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(textoPlano, hashkey));
            Byte[] EncryptedBytes = HashTool.ComputeHash(HashAsByte);
            HashTool.Clear();

            string resultado = Convert.ToBase64String(EncryptedBytes);

            resultado = resultado.Substring(0, 50);

            return resultado;

        }

    }
}
