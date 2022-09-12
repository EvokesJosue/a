//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Oficina.Modelos
//{
//    public class Itens
//    {
//        //PRODUTO
//        public string descricao;
//        public string codigoBarras;
//        public string valorUnitario;
//        public string qtd;
//        public string desconto;

//        //CLIENTE
//        public string tipoCliente;
//        public string formaPagamento;
//        public string nomeCliente;

//        //SERVIÇO
//        public string servicoMecanico;
//        public string servicoDescricao;
//        public double servicoValor;
//        public DateTime data;

//        public int tipoVenda;

//        //Construtor de produtos
//        public Itens(string descricao, string codigoBarras, string valorUnitario, string qtd, string desconto, DateTime data)
//        {
//            this.Descricao = descricao;
//            this.CodigoBarras = codigoBarras;
//            this.ValorUnitario = valorUnitario;
//            this.Qtd = qtd;
//            this.Desconto = desconto;
//        }

//        public Itens(string descricao, string codigoBarras, string valorUnitario, string qtd, string desconto, string tipoCliente, string formaPagamento)
//        {
//            this.Descricao = descricao;
//            this.CodigoBarras = codigoBarras;
//            this.ValorUnitario = valorUnitario;
//            this.Qtd = qtd;
//            this.Desconto = desconto;
//            this.TipoCliente = tipoCliente;
//            this.FormaPagamento = formaPagamento;
//        }

//        //Construtor de produtos e cliente
//        public Itens(string descricao, string codigoBarras, string valorUnitario, string qtd, string desconto, string tipoCliente, string formaPagamento, string nomeCliente)
//        {
//            this.descricao = descricao;
//            this.codigoBarras = codigoBarras;
//            this.valorUnitario = valorUnitario;
//            this.qtd = qtd;
//            this.desconto = desconto;
//            this.tipoCliente = tipoCliente;
//            this.formaPagamento = formaPagamento;
//            this.nomeCliente = nomeCliente;
//        }

//        //Construtor de produtos, cliente e serviço
//        //public Itens(string descricao, string codigoBarras, string valorUnitario, string qtd, string desconto, string tipoCliente, string formaPagamento, string nomeCliente)
//        //{
//        //    this.descricao = descricao;
//        //    this.codigoBarras = codigoBarras;
//        //    this.valorUnitario = valorUnitario;
//        //    this.qtd = qtd;
//        //    this.desconto = desconto;
//        //    this.tipoCliente = tipoCliente;
//        //    this.formaPagamento = formaPagamento;
//        //    this.nomeCliente = nomeCliente;
//        //}

//        public string Descricao { get => descricao; set => descricao = value; }
//        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
//        public string ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
//        public string Qtd { get => qtd; set => qtd = value; }
//        public string Desconto { get => desconto; set => desconto = value; }
//        public string TipoCliente { get => tipoCliente; set => tipoCliente = value; }
//        public string FormaPagamento { get => formaPagamento; set => formaPagamento = value; }
//        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
//        public string ServicoMecanico { get => servicoMecanico; set => servicoMecanico = value; }
//        public string ServicoDescricao { get => servicoDescricao; set => servicoDescricao = value; }
//        public double ServicoValor { get => servicoValor; set => servicoValor = value; }
//        public DateTime Data { get => data; set => data = value; }
//    }
//}
