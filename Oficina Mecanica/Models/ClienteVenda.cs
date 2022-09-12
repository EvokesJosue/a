using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    public class ClienteVenda
    {
        //CLIENTE
        public string tipoCliente;
        public string formaPagamento;
        public string nomeCliente;

        //VENDA
        public string descricao;
        public string codigoBarras;
        public Double valorUnitario;
        public Double qtd;
        public Double desconto;

        public ClienteVenda(string tipoCliente, string formaPagamento, string nomeCliente, string descricao, string codigoBarras, Double valorUnitario, Double qtd, Double desconto)
        {
            this.TipoCliente = tipoCliente;
            this.FormaPagamento = formaPagamento;
            this.NomeCliente = nomeCliente;
            this.Descricao = descricao;
            this.CodigoBarras = codigoBarras;
            this.ValorUnitario = valorUnitario;
            this.Qtd = qtd;
            this.Desconto = desconto;
        }

        public string TipoCliente { get => tipoCliente; set => tipoCliente = value; }
        public string FormaPagamento { get => formaPagamento; set => formaPagamento = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
        public Double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public Double Qtd { get => qtd; set => qtd = value; }
        public Double Desconto { get => desconto; set => desconto = value; }
    }
}
