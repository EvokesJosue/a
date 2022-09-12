using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficina.Modelos;

namespace Oficina_Mecanica.ViewModels.BuscarOficina
{
    public class BuscarClienteVendaServico
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
    }
}
