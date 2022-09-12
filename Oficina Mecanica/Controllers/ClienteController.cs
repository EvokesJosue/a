using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficina.Modelos;
using Oficina_Mecanica.ViewModels;
using Oficina_Mecanica.Repositories;
using Oficina_Mecanica.ViewModels.Cadastrar;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oficina_Mecanica.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        public static readonly List<ClienteModel> clientes = new List<ClienteModel>();
        private readonly ClienteRepository _clienteRepository;


        //quando for chamar essa ação, é só chamar assim:
        //https://localhost:44343/ClasseServico/BuscarNomes
        //nome da controller/nome do método

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Salvar(CadastrarClienteViewModel cadastrarClienteViewModel)
        {
            if (cadastrarClienteViewModel == null)
                return Ok("Não Foi encontrado Dado nenhuma ");

            if (cadastrarClienteViewModel.Nome == null)
                return Ok("Não foi encontrado nenhum Dado");

            if (cadastrarClienteViewModel.Cpf == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Cpf)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Rg == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Rg)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Nascimento == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Nascimento)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Logradouro == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Logradouro)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Numero == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Numero)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Bairro == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Bairro)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Cidade == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Cidade)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Cep == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Cep)} vazio ou nulo.");

            if (cadastrarClienteViewModel.Uf == null)
                throw new ArgumentNullException($"campo {nameof(cadastrarClienteViewModel.Uf)} vazio ou nulo.");

            var resultado = _clienteRepository.Salvar(cadastrarClienteViewModel);

            if (resultado) return Ok("Cliente cadastrado com sucesso!");

            return Ok("Houve um problema ao salvar. Cliente não cadastrado!");
        }

        [HttpGet]
        public IActionResult BuscarNomes(string nome)
        {
            var resultado = _clienteRepository.BuscarCliente(nome);
            return Ok(resultado);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
