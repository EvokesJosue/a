using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina_Mecanica.Dtos
{
    public class MecanicoDtos
    {
        public int IdMecanico { get; set; }
        public int Usuario_IdUsuario { get; set; }
        public string Apelido { get; set; }
        public string Funcao { get; set; }
    }
}
