using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficina.Modelos;

namespace Oficina.Modelos
{
   

    public class ClienteModel
    {
        public int IdCliente { get; set; }
        //public Nullable<double> Divida { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        //public string Sexo { get; set; }
        public string Nascimento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        //public string Estado { get; set; }

    }
}
