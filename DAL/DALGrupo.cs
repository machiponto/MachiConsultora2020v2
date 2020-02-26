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
    public class DALGrupo
    {
        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public List<ClsGrupo> obtenerGruposPorIdUsuario(int pIdUsuario)
        {

            List<ClsGrupo> listadoGrupos = new List<ClsGrupo>();
            ClsGrupo oGrupo;

            try
            {

                foreach (Grupo _grupo in contexto.Grupo.Where(s => s.Usuario.Any(c => c.idUsuario == pIdUsuario)))
                {
                    oGrupo = new ClsGrupo();
                    oGrupo.idGrupo = _grupo.idGrupo;
                    oGrupo.codigoGrupo = _grupo.CodigoGrupo;
                    oGrupo.detalle = _grupo.Detalle;
                    listadoGrupos.Add(oGrupo);
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return listadoGrupos;

        }

        public List<ClsGrupo> obtenerGruposPorUsuario(string pUsuario)
        {

            List<ClsGrupo> listadoGrupos = new List<ClsGrupo>();
            ClsGrupo oGrupo;

            try
            {

                foreach (Grupo _grupo in contexto.Grupo.Where(s => s.Usuario.Any(c => c.usr == pUsuario)))
                {
                    oGrupo = new ClsGrupo();
                    oGrupo.idGrupo = _grupo.idGrupo;
                    oGrupo.codigoGrupo = _grupo.CodigoGrupo;
                    oGrupo.detalle = _grupo.Detalle;
                    listadoGrupos.Add(oGrupo);
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }
            return listadoGrupos;

        }

        public List<ClsGrupo> obtenerPuestos()
        {

            List<ClsGrupo> listadoGrupos = new List<ClsGrupo>();
            ClsGrupo oGrupo;

            try
            {

                foreach (Grupo _grupo in contexto.Grupo)
                {
                    oGrupo = new ClsGrupo();
                    oGrupo.idGrupo = _grupo.idGrupo;
                    oGrupo.codigoGrupo = _grupo.CodigoGrupo;
                    oGrupo.detalle = _grupo.Detalle;
                    listadoGrupos.Add(oGrupo);
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }
            return listadoGrupos;



        }

        public ClsGrupo obtenerPuestoPorNombreGrupo(string pNombreGrupo)
        {

            ClsGrupo oGrupo = new ClsGrupo();

            try
            {

                foreach (Grupo _grupo in contexto.Grupo)
                {
                    if (_grupo.CodigoGrupo == pNombreGrupo)
                    {

                        oGrupo.idGrupo = _grupo.idGrupo;
                        oGrupo.codigoGrupo = _grupo.CodigoGrupo;
                        oGrupo.detalle = _grupo.Detalle;
                    }
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }
            return oGrupo;

        }

        public ClsGrupo obtenerPuestoPorId(int pIdGrupo)
        {

            ClsGrupo oGrupo = new ClsGrupo();

            try
            {

                foreach (Grupo _grupo in contexto.Grupo)
                {
                    if (_grupo.idGrupo == pIdGrupo)
                    {

                        oGrupo.idGrupo = _grupo.idGrupo;
                        oGrupo.codigoGrupo = _grupo.CodigoGrupo;
                        oGrupo.detalle = _grupo.Detalle;
                    }
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }
            return oGrupo;

        }
    }
}

