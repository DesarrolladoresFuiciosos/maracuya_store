using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Dto_UsuariosListar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }       
        public string Correo { get; set; }
        public int Id_Genero { get; set; }
        public int Id_Tipo_Documento { get; set; }
        public int id_Foto { get; set; }
        public string Direccion { get; set; }
        public Boolean Estado { get; set; }

    }
}
