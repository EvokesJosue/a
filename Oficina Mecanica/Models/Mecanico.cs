using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{

    public class Mecanico
    {
        public static object IdMecancio { get; internal set; }
        public static object Usuario_IdUsuario { get; internal set; }
        public int IdMecanico { get; set; }
        //public int Usuario_IdUsuario { get; set; }
        public string Apelido { get; set; }
        public string Funcao { get; set; }

        internal class Dtos
        {
        }
    }
}
