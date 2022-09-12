using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    using System;
    using System.Collections.Generic;

    public class Venda
    {
        public int IdVenda { get; set; }
        public int Cliente_IdCliente { get; set; }
        public int Funcionario_IdFuncionario { get; set; }
        public Nullable<double> Valor_Total_Compra { get; set; }
        public Nullable<System.DateTime> Data_Venda { get; set; }
        public Nullable<double> Desconto_Total { get; set; }
        public string Forma_Pagamento { get; set; }
        public string Tipo_Cliente { get; set; }
    }
}
