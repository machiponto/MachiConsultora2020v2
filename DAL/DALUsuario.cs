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
    public class DALUsuario
    {

        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public Boolean validarUsuario(string pUsuario, string pPassword)
        {

            Boolean resultadoValidacion = false;

            try
            {

                var query = from d in contexto.Usuario
                            where (d.usr == pUsuario.ToLower() && d.password == pPassword)
                            select d;

                if (query.Count() != 0)
                {
                    resultadoValidacion = true;
                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }


            return resultadoValidacion;
        }

        public ClsUsuario obtenerUsuarioPorNombreUsuario(string pUsuario)
        {

            ClsUsuario oUsuario = new ClsUsuario();
            try
            {

                var items = from d in contexto.Usuario
                            where d.usr == pUsuario
                            select d;

                IEnumerator<Usuario> enu = items.GetEnumerator();
                while (enu.MoveNext())
                {

                    oUsuario.idUsuario = enu.Current.idUsuario;
                    oUsuario.usr = enu.Current.usr;
                    oUsuario.password = enu.Current.password;
                    oUsuario.activo = enu.Current.activo;

                }

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return oUsuario;
        }

        public void altaUsuario(ClsUsuario oUsuario, ClsCliente oCliente)
        {

            try
            {
                Usuario oTblUsuario = new Usuario();
                oTblUsuario.usr = oUsuario.usr;
                oTblUsuario.password = oUsuario.password;
                oTblUsuario.activo = oUsuario.activo;
                contexto.Usuario.Add(oTblUsuario);

                //Guardo los cambios para obtener el id de tbl_ComprobanteCabecera
                contexto.SaveChanges();

                oCliente.idUsuario = oTblUsuario.idUsuario;

                DALCliente oDalCliente = new DALCliente();
                oDalCliente.altaCliente(oCliente);

            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }



        }

        //public void altaUsuario(Usuario oUsuario, Empleado oEmpleado)
        //{

        //    try
        //    {
        //        Usuario oTblUsuario = new Usuario();
        //        oTblUsuario.usuario1 = oUsuario.usuario1;
        //        oTblUsuario.password = oUsuario.password;
        //        oTblUsuario.activo = oUsuario.activo;
        //        contexto.Usuario.Add(oTblUsuario);

        //        //Guardo los cambios para obtener el id de tbl_ComprobanteCabecera
        //        contexto.SaveChanges();

        //        oEmpleado.idUsuario = oTblUsuario.idUsuario;

        //        DALEmpleado oDalEmpleado = new DALEmpleado();
        //        oDalEmpleado.altaEmpleado(oEmpleado);

        //    }
        //    catch (Exception ex)
        //    {
        //        DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
        //        throw oDExcepcion;
        //    }



        //}

        public bool verificarExistenciaUsuario(string pUsuario)
        {
            bool resultado = false;
            bool usuarioExiste = false;
            try
            {
                foreach (Usuario _user in contexto.Usuario)
                {
                    if (_user.usr == pUsuario)
                    {
                        usuarioExiste = true;
                    }
                }
                if (usuarioExiste == false)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return resultado;
        }
    }
}
