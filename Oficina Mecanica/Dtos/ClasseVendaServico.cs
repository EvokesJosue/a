using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    public class OrdensServicoDto
    {
        //PRODUTO
        public string descricao;
        public string codigoBarras;
        public double valorUnitario;
        public double qtd;
        public double desconto;

        //CLIENTE
        public string tipoCliente;
        public string formaPagamento;
        public string nomeCliente;

        //SERVIÇO
        public string servicoMecanico;
        public string servicoDescricao;
        public double servicoValor;
        public DateTime data;

       

        public string Descricao { get => descricao; set => descricao = value; }
        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public double Qtd { get => qtd; set => qtd = value; }
        public double Desconto { get => desconto; set => desconto = value; }
        public string TipoCliente { get => tipoCliente; set => tipoCliente = value; }
        public string FormaPagamento { get => formaPagamento; set => formaPagamento = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string ServicoMecanico { get => servicoMecanico; set => servicoMecanico = value; }
        public string ServicoDescricao { get => servicoDescricao; set => servicoDescricao = value; }
        public double ServicoValor { get => servicoValor; set => servicoValor = value; }
        public DateTime Data { get => data; set => data = value; }
        public object TotalGeral { get; internal set; }
        public object IdProduto { get; internal set; }
        public object IdServico { get; internal set; }
        public object IdMecanico { get; internal set; }
    }
}
