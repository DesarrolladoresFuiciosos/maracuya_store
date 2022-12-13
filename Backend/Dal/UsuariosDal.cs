using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UsuariosDal : Dapper
    {
        public UsuariosDal(string ConexionString)
        {
            Conexion = ConexionString;
        }

        public List<Dto_UsuariosListar> GetUsuariosListar ()
        {
            return ListQuery<object, Dto_UsuariosListar>("[dbo].[SP_ListarUsuarios]", null);
        }

        //Listar por ID//

        public List<Dto_UsuariosListar> GetUsuariosListarId(int Id)
        {
            return ListQuery<object, Dto_UsuariosListar>("[dbo].[SP_ListarUsuarios_Id]", new { Id = Id });
        }

        public List<Dto_UsuariosListar> GetUsuariosValidacion(string email, string password)
        {
            return ListQuery<object, Dto_UsuariosListar>("[dbo].[SP_Usuarios_Validacion]", new { Email = email, Password = password });
        }


        public dynamic AddUsuarios (Dto_UsuariosAgregar dto_UsuariosAgregar)
        {
            return SingleQuery<object, Dto_UsuariosAgregar>("[dbo].[SP_AgregarUsuarios]",
                new
                {
                    Nombre = dto_UsuariosAgregar.Nombre,
                    Apellidos = dto_UsuariosAgregar.Apellidos,
                    Correo = dto_UsuariosAgregar.Correo,
                    Password = dto_UsuariosAgregar.Password,
                    Id_Genero = dto_UsuariosAgregar.Id_Genero,
                    Id_Tipo_Documento = dto_UsuariosAgregar.Id_Tipo_Documento,
                    Num_Documento = dto_UsuariosAgregar.Num_Documento,
                    Id_Foto = dto_UsuariosAgregar.Id_Foto,
                    Direccion = dto_UsuariosAgregar.Direccion,
                    Estado = dto_UsuariosAgregar.Estado

                });
        }

        public dynamic ActualizaUsuarios(Dto_UsuariosModificar actualizaUsuarios)
        {
            return SingleQuery<Dto_UsuariosModificar, dynamic>("[dbo].[SP_ActualizarUsuarios]", actualizaUsuarios);
        }






    }
}
