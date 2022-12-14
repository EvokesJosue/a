using Dapper;
using Oficina_Mecanica.Dtos;
using Oficina.Modelos;
using Oficina_Mecanica.ViewModels;
using Oficina_Mecanica.ViewModelsAtualizar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMecanica.Repositories
{
    public class ClienteRepository
    {
        private readonly string _connection = @"Data Source\SQLEXPRESS;Initial Catalog;Integrated Security=True;";
        //private readonly string _connection = @"Data Source\SQLEXPRESS;Initial Catalog;Integrated Security=True;";


        public bool Salvar(CadastrarClientVendaServicoeViewModel salvarPessoaViewModel)
        {
            try
            {
                var query = @"INSERT INTO Clientes 
                              (NomeCliente, CpfCliente, TelefoneCliente, EnderecoCliente, VeiculoCliente, PlacaVeiculoCliente, CorVeiculoCliente) 
                              VALUES (@nomeCliente,@cpfCliente,@telefoneCliente,@enderecoCliente,@veiculoCliente,@placaVeiculoCliente,@corVeiculoCliente)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nomeCliente", salvarPessoaViewModel.NomeCliente);
                    command.Parameters.AddWithValue("@cpfCliente", salvarPessoaViewModel.CpfCliente);
                    command.Parameters.AddWithValue("@telefoneCliente", salvarPessoaViewModel.TelefoneCliente);
                    command.Parameters.AddWithValue("@enderecoCliente", salvarPessoaViewModel.EnderecoCliente);
                    command.Parameters.AddWithValue("@veiculoCliente", salvarPessoaViewModel.VeiculoCliente);
                    command.Parameters.AddWithValue("@placaVeiculoCliente", salvarPessoaViewModel.PlacaVeiculoCliente);
                    command.Parameters.AddWithValue("@corVeiculoCliente", salvarPessoaViewModel.CorVeiculoCliente);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Cliente cadastrado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
        public List<Cliente> BuscarPorNome(string nome)
        {
            List<Cliente> ClientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, NomeCliente, CpfCliente, TelefoneCliente, EnderecoCliente, VeiculoCliente, PlacaVeiculoCliente, CorVeiculocliente FROM Clientes
                                      WHERE NomeCliente = @nome";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    ClientesEncontrados = connection.Query<Cliente>(query, parametros).ToList();
                }

                return ClientesEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public List<Cliente> BuscarTodos()
        {
            List<Cliente> clientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, NomeCliente, CpfCliente, TelefoneCliente, EnderecoCliente, VeiculoCliente, PlacaVeiculoCliente, CorVeiculoCliente FROM Clientes";

                using (var connection = new SqlConnection(_connection))
                {
                    clientesEncontrados = connection.Query<ClientesDto>(query).ToList();
                }
                return clientesEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public void Atualizar(Clientes clientes, int id)
        {
            try
            {
                var query = @"UPDATE Clientes SET NomeCliente = @nomeCliente, CpfCliente = @cpfCliente, TelefoneCliente = @telefoneCliente, EnderecoCliente = @enderecoCliente,
                            VeiculoCliente = @veiculoCliente, PlacaVeiculoCliente = @placaVeiculoCliente, CorVeiculoCliente = @corVeiculoCliente WHERE IdCliente = @idCliente";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idCliente", id);
                    command.Parameters.AddWithValue("@nomeCliente", clientes.NomeCliente);
                    command.Parameters.AddWithValue("@cpfCliente", clientes.CpfCliente);
                    command.Parameters.AddWithValue("@telefoneCliente", clientes.TelefoneCliente);
                    command.Parameters.AddWithValue("@enderecoCliente", clientes.EnderecoCliente);
                    command.Parameters.AddWithValue("@veiculoCliente", clientes.VeiculoCliente);
                    command.Parameters.AddWithValue("@placaVeiculoCliente", clientes.PlacaVeiculoCliente);
                    command.Parameters.AddWithValue("@corVeiculoCliente", clientes.CorVeiculoCliente);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public ClientesDto Confirmar(int idCliente)
        {
            var cliente = new ClientesDto();
            try
            {
                var query = "SELECT * FROM Clientes WHERE IdCliente = @idCliente";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        idCliente
                    };
                    cliente = connection.QueryFirstOrDefault<ClientesDto>(query, parametros);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                cliente = null;
            }
            return cliente;
        }
        public void Deletar(int id)
        {
            try
            {
                var query = "Delete From Clientes where IdCliente = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public class CadastrarClientVendaServicoeViewModel
        {
        }
    }
}
