using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficina.Modelos;

namespace Oficina_Mecanica.ViewModels.CadastrarOficina
{
    public class CadastrarProduto
    {
        public int IdProduto { get; set; }
        //public int IdFornecedor { get; set; }
        public int Estoque_IdEstoque { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        public string Un { get; set; }
        public string Descricao_Marca { get; set; }
        public string Codigo { get; set; }
        public string Codigo_Barras { get; set; }
        public Nullable<double> Valor_Custo { get; set; }
        public Nullable<double> Margem_Avista { get; set; }
        public Nullable<double> Valor_Avista { get; set; }
        public Nullable<double> Margem_Prazo { get; set; }
        public Nullable<double> valor_Prazo { get; set; }
        //public Nullable<double> Margem_Atacado { get; set; }
        //public Nullable<double> Valor_Atacado { get; set; }
        public Nullable<System.DateTime> Ultima_Atualizacao { get; set; }
        public Nullable<System.DateTime> Data_Cadastro { get; set; }
    }
}
