using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{

    public class Produto
    {
        public int IdProduto { get; set; }
        //public int IdFornecedor { get; set; }
        //public int Estoque_IdEstoque { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        //public string Un { get; set; }
        public string Descricao_Marca { get; set; }
        public string Codigo { get; set; }
        public string Codigo_Barras { get; set; }
        public Nullable<bool> Valor_Custo { get; set; }
        public Nullable<bool> Margem_Avista { get; set; }
        public Nullable<bool> Valor_Avista { get; set; }
        public Nullable<bool> Margem_Prazo { get; set; }
        public Nullable<bool> Valor_Prazo { get; set; }
        public Nullable<bool> Margem_Atacado { get; set; }
        public Nullable<bool> Valor_Atacado { get; set; }
        public Nullable<System.DateTime> Ultima_Atualizacao { get; set; }
        public Nullable<System.DateTime> Data_Cadastro { get; set; }
        public object Valor_Aprazo { get; internal set; }

        internal class Dtos
        {
        }
    }
}
