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
    public class DALCV
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public List<ClsDatosPersonales> obtenerDatosPersonales()
        {

            List<ClsDatosPersonales> listadoDPBD = new List<ClsDatosPersonales>();
           
            ClsDatosPersonales oDatosPersonales;

            try
            {
                //CONSULTA TRAIGO TODOS LOS SERVICIOS
                var items = from d in contexto.DatosPersonales
                            select d;

                IEnumerator<DatosPersonales> enu = items.GetEnumerator();
                while (enu.MoveNext())
                {
                    oDatosPersonales = new ClsDatosPersonales();
                    oDatosPersonales.Id_DatosPersonales = enu.Current.Id_DatosPersonales;
                    oDatosPersonales.ApellidoPostulante = enu.Current.ApellidoPostulante;
                    oDatosPersonales.ApellidoMaterno = enu.Current.ApellidoMaterno;
                    oDatosPersonales.NombrePostulante = enu.Current.NombrePostulante;
                    oDatosPersonales.Sexo = enu.Current.Sexo;
                    oDatosPersonales.FechaNacimiento = enu.Current.FechaNacimiento;

                   
                    var _prodServ = contexto.DatosPersonales.First(m => m.Id_DatosPersonales == enu.Current.Id_DatosPersonales);
                    oDatosPersonales.Id_DatosPersonales = _prodServ.Id_DatosPersonales;

                    oDatosPersonales.ApellidoPostulante = _prodServ.ApellidoPostulante;
                    oDatosPersonales.ApellidoMaterno = _prodServ.ApellidoMaterno;
                    oDatosPersonales.NombrePostulante = _prodServ.NombrePostulante;
                    oDatosPersonales.Sexo = _prodServ.Sexo;
                    oDatosPersonales.FechaNacimiento = _prodServ.FechaNacimiento;

                    listadoDPBD.Add(oDatosPersonales);

                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoDPBD;

        }
    }
}
