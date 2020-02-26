using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;
using SL.Bitacora;
using SL.Excepciones;

namespace DAL
{
    public class DALPuesto
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public List<ClsPuestos> obtenerPuestos()
        {

            List<ClsPuestos> listaPuestos = new List<ClsPuestos>();
            ClsPuestos oPuesto;

            try
            {

                //CONSULTA TRAIGO TODOS LOS EVENTOS DE LA TABLA BITACORA
                var eventosPuesto = from d in contexto.Puestos
                                       orderby (d.Id_Puesto) descending
                                       select d;

                IEnumerator<Puestos> enu = eventosPuesto.GetEnumerator();
                while (enu.MoveNext())
                {
                    oPuesto = new ClsPuestos();
                    oPuesto.Id_Puesto = enu.Current.Id_Puesto;
                    oPuesto.DescripcionPuesto = enu.Current.DescripciónPuesto;
                  
                    listaPuestos.Add(oPuesto);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listaPuestos;
        }

    }
}