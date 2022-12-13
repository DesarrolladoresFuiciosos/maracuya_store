using Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class UsuariosBussiness
    {
        public UsuariosDal Dal;
        public UsuariosBussiness(string Conexion)
        {
            Dal = new UsuariosDal(Conexion);
        }

        public List<Dto_UsuariosListar> GetUsuariosListar()
        {
            return Dal.GetUsuariosListar();
        }

        //Listar por ID
        public List<Dto_UsuariosListar> GetUsuariosListarId(int Id)
        {
            return Dal.GetUsuariosListarId(Id);
        }

        public List<Dto_UsuariosListar> GetUsuariosValidacion(string email, string password)
        {
            return Dal.GetUsuariosValidacion(email, password);
        }

        public dynamic ActualizaUsuarios(Dto_UsuariosModificar actualizaUsuarios)
        {
            return Dal.ActualizaUsuarios(actualizaUsuarios);
        }

        public dynamic AddUsuarios (Dto_UsuariosAgregar dto_UsuariosAgregar)
        {
            return Dal.AddUsuarios(dto_UsuariosAgregar);
        }
        

    }
}
