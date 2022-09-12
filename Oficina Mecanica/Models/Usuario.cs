using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    using System;
    using System.Collections.Generic;

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string Nascimento { get; set; }
        public Nullable<System.DateTime> Data_Cadastro { get; set; }
        public string Estado { get; set; }
    }
}
