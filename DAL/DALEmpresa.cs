using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;
using SL.Excepciones;
using SL.Bitacora;

namespace DAL
{
    public class DALEmpresa
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();


        public Empresa obtenerEmpresaPorId(int pIdEmpresa)
        {
            Empresa oEmpresa = new Empresa(); ;

            try
            {

                var _empresa = from d in contexto.Empresa
                               where d.idEmpresa == pIdEmpresa
                               select d;

                IEnumerator<Empresa> enu = _empresa.GetEnumerator();
                while (enu.MoveNext())
                {
                    oEmpresa.RazonSocial = enu.Current.RazonSocial;
                    oEmpresa.Descripcion = enu.Current.Descripcion;
                }
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }



            return oEmpresa;
        }



    }
}
