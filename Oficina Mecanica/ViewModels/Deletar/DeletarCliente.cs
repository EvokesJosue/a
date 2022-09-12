using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficina.Modelos;

namespace Oficina_Mecanica.ViewModels.DeletarOficina
{
    public class DeletarCliente
    {
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public Nullable<double> Divida { get; set; }
    }
}
