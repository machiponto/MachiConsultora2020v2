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
    public class DALSucursal
    {

        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();


        public Sucursal obtenerSucursalPorId(int pIdSucursal)
        {
            Sucursal oSucursal = new Sucursal(); ;

            try
            {

                var _sucursal = from d in contexto.Sucursal
                                where d.idSucursal == pIdSucursal
                                select d;

                IEnumerator<Sucursal> enu = _sucursal.GetEnumerator();
                while (enu.MoveNext())
                {

                    oSucursal.idSucursal = enu.Current.idSucursal;
                    oSucursal.direccion = enu.Current.direccion;
                    oSucursal.telefono = enu.Current.telefono;
                    oSucursal.fax = enu.Current.fax;

                    DALEmpresa oDalEmpresa = new DALEmpresa();
                    //oSucursal.oEmpresa = oDalEmpresa.obtenerEmpresaPorId(enu.Current.idEmpresa);

                }
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }


            return oSucursal;
        }

    }
}
