using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{

    public class Servico
    {
        public int IdServico { get; set; }
        public int Mecanico_IdMecanico { get; set; }
        public string Descricao { get; set; }
        public Nullable<double> Valor { get; set; }
        public Nullable<System.DateTime> Data_Servico { get; set; }
    }
}
