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
    public class DALCliente
    {

        MachiConsultoraVFEntities contexto = new MachiConsultoraVFEntities();

        public void altaCliente(ClsCliente oCliente)
        {

            try
            {
                Cliente oTblCliente = new Cliente();

                oTblCliente.Nombre = oCliente.nombre;
                oTblCliente.Telefono = oCliente.telefono;
                oTblCliente.Direccion = oCliente.direccion;
                oTblCliente.Mail = oCliente.mail;
                oTblCliente.idUsuario = oCliente.idUsuario;
                //oTblCliente.Op= oCliente.opcionDePago.idOpcionDePago;

                contexto.Cliente.Add(oTblCliente);

                contexto.SaveChanges();


            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }


        }

        public ClsCliente obtenerClientePorUsuario(string pUsuario)
        {

            ClsCliente oCliente = new ClsCliente();
            ClsUsuario oUsuario = new ClsUsuario();
            DALUsuario oDalUsuario = new DALUsuario();

            try
            {
                oUsuario = oDalUsuario.obtenerUsuarioPorNombreUsuario(pUsuario);

                var items = from d in contexto.Cliente
                            where d.idUsuario == oUsuario.idUsuario
                            select d;

                IEnumerator<Cliente> enu = items.GetEnumerator();
                while (enu.MoveNext())
                {
                    oCliente.idCliente = enu.Current.Id_Cliente;
                    oCliente.nombre = oCliente.nombre;
                    oCliente.telefono = oCliente.telefono;
                    oCliente.direccion = oCliente.direccion;
                    oCliente.mail = oCliente.mail;
                    oCliente.idUsuario = oCliente.idUsuario;


                    //var items2 = from d in contexto.OpcionDePago
                    //            where d.idOpcionDePago == enu.Current.opcionDePago
                    //            select d;

                    //IEnumerator<OpcionDePago> enu2 = items2.GetEnumerator();
                    //while (enu2.MoveNext())
                    //{
                    //    OpcionDePago oOpcionDePago = new OpcionDePago();
                    //    oOpcionDePago = new OpcionDePago();
                    //    oOpcionDePago.idOpcionDePago = enu2.Current.idOpcionDePago;
                    //    oOpcionDePago.nombre = enu2.Current.nombre;
                    //    oCliente.opcionDePago = oOpcionDePago;
                    //}

                }
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

            return oCliente;
        }

        public ClsCliente obtenerClientePorIdCliente(int pIdCliente)
        {

            ClsCliente oCliente = new ClsCliente();

            try
            {

                var items = from d in contexto.Cliente
                            where d.Id_Cliente == pIdCliente
                            select d;

                IEnumerator<Cliente> enu = items.GetEnumerator();
                while (enu.MoveNext())
                {
                    oCliente.idCliente = enu.Current.Id_Cliente;
                    oCliente.nombre = enu.Current.Nombre;
                    oCliente.telefono = enu.Current.Telefono;
                    oCliente.direccion = enu.Current.Direccion;
                    oCliente.mail = enu.Current.Mail;
                    oCliente.idUsuario = enu.Current.idUsuario;


                    //var items2 = from d in contexto.OpcionDePago
                    //             where d.idOpcionDePago == enu.Current.opcionDePago
                    //             select d;

                    //IEnumerator<OpcionDePago> enu2 = items2.GetEnumerator();
                    //while (enu2.MoveNext())
                    //{
                    //    OpcionDePago oOpcionDePago = new OpcionDePago();
                    //    oOpcionDePago = new OpcionDePago();
                    //    oOpcionDePago.idOpcionDePago = enu2.Current.idOpcionDePago;
                    //    oOpcionDePago.nombre = enu2.Current.nombre;
                    //    oCliente.opcionDePago = oOpcionDePago;
                    //}

                }
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }


            return oCliente;


        }

        public void actualizarDatosCliente(ClsCliente oCliente)
        {

            try
            {
                var _cliente = from d in contexto.Cliente
                               where d.Id_Cliente == oCliente.idCliente
                               select d;

                foreach (Cliente oTblCliente in _cliente)
                {

                    oCliente.nombre = oCliente.nombre;
                    oCliente.telefono = oCliente.telefono;
                    oCliente.direccion = oCliente.direccion;
                    oCliente.mail = oCliente.mail;

                    //oTblCliente.idUsuario = oCliente.idUsuario;
                }

                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.InnerException.Message);
                throw oDExcepcion;
            }

        }
    }
}
