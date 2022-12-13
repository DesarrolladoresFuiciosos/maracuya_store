using Bussiness;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend_maracuya_store.Controllers
{
    public class UsuariosController : ApiController
    {
        public UsuariosBussiness Bussiness = new UsuariosBussiness (Properties.Settings.Default.Conexion);
        
        [HttpGet, Route ("api/GetUsuariosListar")]
        public List <Dto_UsuariosListar> GetUsuariosListar ()
        {
            return Bussiness.GetUsuariosListar();
        }

        //Listar por ID

        [HttpGet, Route("api/GetUsuariosListarId")]
        public List<Dto_UsuariosListar> GetUsuariosListarId(int Id)
        {
            return Bussiness.GetUsuariosListarId(Id);
        }

        [HttpGet, Route("api/GetUsuariosValidacion")]
        public List<Dto_UsuariosListar> GetUsuariosValidacion(string email, string password)
        {
            return Bussiness.GetUsuariosValidacion(email, password);
        }

        [HttpPost, Route("api/AddUsuarios")]
        public dynamic AddUsuarios (Dto_UsuariosAgregar dto_UsuariosAgregar)
        {
            try
            {
                Bussiness.AddUsuarios(dto_UsuariosAgregar);
                return "Usuario " + dto_UsuariosAgregar.Nombre + " agregado exitosamente";
            }
            catch (Exception ex)
            {
                return new Mensaje_Retorno{
                    Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                    Message = ex.Message.ToString(),
                    Data = new Dto_UsuariosAgregar {
                        Nombre = dto_UsuariosAgregar.Nombre,
                        Apellidos = dto_UsuariosAgregar.Apellidos,
                        Correo = dto_UsuariosAgregar.Correo,
                        Id_Genero = dto_UsuariosAgregar.Id_Genero,
                        Id_Tipo_Documento = dto_UsuariosAgregar.Id_Tipo_Documento,
                        Num_Documento = dto_UsuariosAgregar.Num_Documento,
                        Id_Foto = dto_UsuariosAgregar.Id_Foto,
                        Direccion = dto_UsuariosAgregar.Direccion,
                        Estado = dto_UsuariosAgregar.Estado,
                    }
                };
            }
        }


        [HttpPut, Route("api/ActualizaUsuarios")]
        public dynamic ActualizaUsuarios ([FromBody] List<Dto_UsuariosModificar> actualizaUsuarios)
        {
            try
            {
                for (int i = 0; i < actualizaUsuarios.Count; i++)
                {
                    var retorno = Bussiness.ActualizaUsuarios(actualizaUsuarios[i]);
                    if (actualizaUsuarios.Count - i == 1)
                    {
                        return retorno;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }
        }




    }
}