using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    using System;
    using System.Collections.Generic;

    public class Funcionario
    {
        public int Idfuncionario { get; set; }
        public int Idusuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        //public string Nivel_Acesso { get; set; }
    }
}
