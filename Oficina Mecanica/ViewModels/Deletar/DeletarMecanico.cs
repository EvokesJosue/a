using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficina.Modelos;

namespace Oficina_Mecanica.ViewModels.DeletarOficina
{
    public class DeletarMecanico
    {
        public int IdMecanico { get; set; }
        public int Usuario_IdUsuario { get; set; }
        public string Apelido { get; set; }
        public string Funcao { get; set; }
    }
}
