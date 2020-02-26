using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;

namespace BLL
{
    public interface INEGAbmCliente
    {

        void altaCliente(ClsCliente oCliente, ClsUsuario oUsuario);
        //void altaEmpleado(Empleado oEmpleado, Usuario oUsuario);
        ClsCliente obtenerClientePorUsuario(string usuario);
        Boolean validarUsuario(string pUsuario, string pPassword);
        List<ClsGrupo> obtenerGruposPorIdUsuario(int pIdUsuario);
        string obtenerGruposPorUsuario(string pUsuario);
        bool verificarExistenciaUsuario(string pUsuario);
        ClsCliente obtenerClientePorId(int pIdCliente);
        void actualizarDatosCliente(ClsCliente oCliente);

        List<ClsGrupo> obtenerPuestos();
    }
}
