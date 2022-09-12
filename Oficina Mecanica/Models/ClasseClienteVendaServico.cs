using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    public class ClasseClienteVendaServico
    {
        public int idCliente;
        public int idFuncionario;
        public double valorTotalCompra;
        public DateTime dataVenda;
        public double descontoTotal;
        public string formaPagamento;
        public string tipoCadastroCliente;

        public int idVenda;
        public int qtd;
        public double precoVenda;
        public double desconto;
        public string codigoBarras;
        public string descricao;

        public string servicoMecanico;
        public string servicoDescricao;
        public double servicoValor;
        public DateTime data;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdFuncionario { get => idFuncionario; set => idFuncionario = value; }
        public double ValorTotalCompra { get => valorTotalCompra; set => valorTotalCompra = value; }
        public DateTime DataVenda { get => dataVenda; set => dataVenda = value; }
        public double DescontoTotal { get => descontoTotal; set => descontoTotal = value; }
        public string FormaPagamento { get => formaPagamento; set => formaPagamento = value; }
        public string TipoCadastroCliente { get => tipoCadastroCliente; set => tipoCadastroCliente = value; }
        public int IdVenda { get => idVenda; set => idVenda = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        public double PrecoVenda { get => precoVenda; set => precoVenda = value; }
        public double Desconto { get => desconto; set => desconto = value; }
        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string ServicoMecanico { get => servicoMecanico; set => servicoMecanico = value; }
        public string ServicoDescricao { get => servicoDescricao; set => servicoDescricao = value; }
        public double ServicoValor { get => servicoValor; set => servicoValor = value; }
        public DateTime Data { get => data; set => data = value; }

        public ClasseClienteVendaServico(int idCliente, int idFuncionario, double valorTotalCompra, DateTime dataVenda, double descontoTotal, string formaPagamento, string tipoCadastroCliente, int idVenda, int qtd, double precoVenda, double desconto, string codigoBarras, string descricao, string servicoMecanico, string servicoDescricao, double servicoValor, DateTime data)
        {
            this.IdCliente = idCliente;
            this.IdFuncionario = idFuncionario;
            this.ValorTotalCompra = valorTotalCompra;
            this.DataVenda = dataVenda;
            this.DescontoTotal = descontoTotal;
            this.FormaPagamento = formaPagamento;
            this.TipoCadastroCliente = tipoCadastroCliente;
            this.IdVenda = idVenda;
            this.Qtd = qtd;
            this.PrecoVenda = precoVenda;
            this.Desconto = desconto;
            this.CodigoBarras = codigoBarras;
            this.Descricao = descricao;
            this.ServicoMecanico = servicoMecanico;
            this.ServicoDescricao = servicoDescricao;
            this.ServicoValor = servicoValor;
            this.Data = data;
        }
    }
}
