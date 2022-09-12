using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Modelos
{
    public class ClasseServico
    {
        public string servicoMecanico;
        public string servicoDescricao;
        public double servicoValor;
        public DateTime data;

        public ClasseServico(string servicoMecanico, string servicoDescricao, double servicoValor, DateTime data)
        {
            this.ServicoMecanico = servicoMecanico;
            this.ServicoDescricao = servicoDescricao;
            this.ServicoValor = servicoValor;
            this.Data = data;
        }

        public string ServicoMecanico { get => servicoMecanico; set => servicoMecanico = value; }
        public string ServicoDescricao { get => servicoDescricao; set => servicoDescricao = value; }
        public double ServicoValor { get => servicoValor; set => servicoValor = value; }
        public DateTime Data { get => data; set => data = value; }

        //public override string ToString() => $"{servicoMecanico}".Trim();

        public override string ToString()
        {
            return "Mecânico: " + servicoMecanico + ", Serviço: " + ServicoDescricao + ", Valor Serviço: " + servicoValor + "\n";
        }
    }
}
