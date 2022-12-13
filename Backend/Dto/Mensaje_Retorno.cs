using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Mensaje_Retorno
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Dto_UsuariosAgregar Data { get; set; }
    }
}
