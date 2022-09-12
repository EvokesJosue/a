using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    public class ClienteVendaServico
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

        public ClienteVendaServico(string descricao, string codigoBarras, double valorUnitario, double qtd, double desconto, string tipoCliente, string formaPagamento, string nomeCliente, string servicoMecanico, string servicoDescricao, double servicoValor, DateTime data)
        {
            this.Descricao = descricao;
            this.CodigoBarras = codigoBarras;
            this.ValorUnitario = valorUnitario;
            this.Qtd = qtd;
            this.Desconto = desconto;
            this.TipoCliente = tipoCliente;
            this.FormaPagamento = formaPagamento;
            this.NomeCliente = nomeCliente;
            this.ServicoMecanico = servicoMecanico;
            this.ServicoDescricao = servicoDescricao;
            this.ServicoValor = servicoValor;
            this.Data = data;
        }

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
    }
}
