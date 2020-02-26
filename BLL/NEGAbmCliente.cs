using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL.Seguridad;
using BI;
using DAL;
using SL.Excepciones;

namespace BLL
{
    public class NEGAbmCliente : INEGAbmCliente
    {

        IHash intHash = new Hash();
        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();

        public void altaCliente(ClsCliente oCliente, ClsUsuario oUsuario)
        {

            try
            {
                IHash interfazSeguridad = new Hash();
                string passHasheada = interfazSeguridad.obtenerHash(oUsuario.password);
                oUsuario.password = passHasheada;

                //Activo el usuario, ya que es un nuevo empleado.
                oUsuario.activo = true;

                DALUsuario oDalUsuario = new DALUsuario();
                oDalUsuario.altaUsuario(oUsuario, oCliente);

                string pDetalle = "Nuevo Cliente generado ID:" + oCliente.nombre.ToString() + " con susuario: " + oUsuario.usr.ToString() + "satisfactoriamente.";
                string pModulo = "BLL";
                interfazServiceLayer.registrarEventoNegocio(pDetalle, pModulo);


            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

        }

        //public void altaEmpleado(Empleado oEmpleado, Usuario oUsuario)
        //{

        //    try
        //    {

        //        IHash interfazSeguridad = new Hash();
        //        string passHasheada = interfazSeguridad.obtenerHash(oUsuario.password);
        //        oUsuario.password = passHasheada;

        //        DALGrupo oDalGrupo = new DALGrupo();
        //        oEmpleado.puesto = oDalGrupo.obtenerPuestoPorId(oEmpleado.puesto.idGrupo);

        //        //Activo el usuario, ya que es un nuevo empleado.
        //        oUsuario.activo = true;

        //        DALUsuario oDalUsuario = new DALUsuario();
        //        oDalUsuario.altaUsuario(oUsuario, oEmpleado);

        //        string pDetalle = "Nuevo Empleado generado ID:" + oEmpleado.nombre.ToString() + " con susuario: " + oUsuario.usuario.ToString() + "satisfactoriamente.";
        //        string pModulo = "BLL";
        //        interfazServiceLayer.registrarEventoNegocio(pDetalle, pModulo);


        //    }
        //    catch (DalExcepcion ex)
        //    {
        //        DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oDExcepcion);
        //    }
        //    catch (Exception ex)
        //    {
        //        BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oBExcepcion);
        //    }

        //}

        public Boolean validarUsuario(string pUsuario, string pPassword)
        {

            Boolean resultado = false;
            DALUsuario oDalUsuario = new DALUsuario();

            try
            {

                string passwordHasheado = intHash.obtenerHash(pPassword);
                resultado = oDalUsuario.validarUsuario(pUsuario, passwordHasheado);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }


            return resultado;
        }

        public ClsCliente obtenerClientePorUsuario(string pUsuario)
        {

            ClsCliente oCliente = new ClsCliente();
            DALCliente oDalCliente = new DALCliente();

            try
            {

                oCliente = oDalCliente.obtenerClientePorUsuario(pUsuario);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return oCliente;
        }

        public List<ClsGrupo> obtenerGruposPorIdUsuario(int pIdUsuario)
        {

            List<ClsGrupo> listadoGrupos = new List<ClsGrupo>();
            DALGrupo oDalGrupo = new DALGrupo();

            pIdUsuario = 2;

            try
            {
                listadoGrupos = oDalGrupo.obtenerGruposPorIdUsuario(pIdUsuario);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return listadoGrupos;
        }

        public string obtenerGruposPorUsuario(string pUsuario)
        {

            List<ClsGrupo> listadoGrupos = new List<ClsGrupo>();
            DALGrupo oDalGrupo = new DALGrupo();

            string _grupo = "";

            try
            {
                listadoGrupos = oDalGrupo.obtenerGruposPorUsuario(pUsuario);

                if (listadoGrupos.Count() > 0)
                {
                    _grupo = listadoGrupos[0].codigoGrupo;
                }
            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return _grupo;

        }

        public List<ClsGrupo> obtenerPuestos()
        {

            List<ClsGrupo> listadoPuestos = new List<ClsGrupo>();
            DALGrupo oDalGrupo = new DALGrupo();
            try
            {

                listadoPuestos = oDalGrupo.obtenerPuestos();

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return listadoPuestos;
        }

        public ClsCliente obtenerClientePorId(int pIdCliente)
        {

            ClsCliente oCliente = new ClsCliente();
            DALCliente oDalCliente = new DALCliente();

            try
            {

                oCliente = oDalCliente.obtenerClientePorIdCliente(pIdCliente);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return oCliente;

        }

        public void actualizarDatosCliente(ClsCliente oCliente)
        {

            DALCliente oDalCliente = new DALCliente();

            try
            {


                oDalCliente.actualizarDatosCliente(oCliente);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }



        }

        public bool verificarExistenciaUsuario(string pUsuario)
        {
            bool resultado = false;

            try
            {
                DALUsuario oDalUsuario = new DALUsuario();

                resultado = oDalUsuario.verificarExistenciaUsuario(pUsuario);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return resultado;

        }

    }
}
