using Oficina_Mecanica.ViewModelsAtualizar;
using Oficina.Modelos;
using Oficina_Mecanica.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Oficina_Mecanica.ViewModels.Cadastrar;
using Dapper;
using Oficina_Mecanica.Dtos;

namespace Oficina_Mecanica.Repositories
{
    public class ClienteRepository
    {
        private readonly string _connection = @"Data Source=DESKTOP-8JAGM2K\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";
        //private readonly string _connection = @"Data Source=\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";

        public bool Salvar(CadastrarClienteViewModel cadastrarClienteViewModel)
        {
            try
            {
                var query = @"INSERT INTO Cliente (Nome, CPF, RG, Nascimento, Logradouro, Numero, Bairro, Cidade, CEP, UF) 
                                                    VALUES (@nome,@cpf,@rg,@nascimento,@logradouto,@numero,@bairro,@cidade,@cep,@uf)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cadastrarClienteViewModel.Nome);
                    command.Parameters.AddWithValue("@cpf", cadastrarClienteViewModel.Cpf);
                    command.Parameters.AddWithValue("@rg", cadastrarClienteViewModel.Rg);
                    command.Parameters.AddWithValue("@nascimento", cadastrarClienteViewModel.Nascimento);
                    command.Parameters.AddWithValue("@logradouto", cadastrarClienteViewModel.Logradouro);
                    command.Parameters.AddWithValue("@numero", cadastrarClienteViewModel.Numero);
                    command.Parameters.AddWithValue("@bairro", cadastrarClienteViewModel.Bairro);
                    command.Parameters.AddWithValue("@cidade", cadastrarClienteViewModel.Cidade);
                    command.Parameters.AddWithValue("@cep", cadastrarClienteViewModel.Cep);
                    command.Parameters.AddWithValue("@uf", cadastrarClienteViewModel.Uf);
                    command.Connection.Open();
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
        public List<ClienteDtos> BuscarPorNome(string nome)
        {
            List<ClienteDtos> ClientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, Nome, CPF, RG, Nascimento, Logradouro, Numero, Bairro, Cidade, CEP, UF FROM Cliente
                                      WHERE Nome = @nome";

                using (var connection = new SqlConnection(_connection))
                {

                    ClientesEncontrados = connection.Query<ClienteDtos>(query).ToList();

                    //ClientesEncontrados = connection.QueryFirstOrDefault<ClienteDtos>(query, parametros);

                }

                return ClientesEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public void Atualizar(ClienteModel clienteModel, int id)
        {
            try
            {
                var query = @"UPDATE Cliente SET Nome = @nome,@cpf,@rg,@nascimento,@logradouto,@numero,@bairro,@cidade,@cep,@uf WHERE IdCliente = @idCliente";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", clienteModel.Nome);
                    command.Parameters.AddWithValue("@cpf", clienteModel.Cpf);
                    command.Parameters.AddWithValue("@rg", clienteModel.Rg);
                    command.Parameters.AddWithValue("@nascimento", clienteModel.Nascimento);
                    command.Parameters.AddWithValue("@logradouto", clienteModel.Logradouro);
                    command.Parameters.AddWithValue("@numero", clienteModel.Numero);
                    command.Parameters.AddWithValue("@bairro", clienteModel.Bairro);
                    command.Parameters.AddWithValue("@cidade", clienteModel.Cidade);
                    command.Parameters.AddWithValue("@cep", clienteModel.Cep);
                    command.Parameters.AddWithValue("@uf", clienteModel.Uf);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public ClienteDtos Confirmar(int idCliente)
        {
            var cliente = new ClienteDtos();
            try
            {
                var query = "SELECT * FROM Cliente WHERE IdCliente = @idCliente";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        idCliente
                    };
                    cliente = connection.QueryFirstOrDefault<ClienteDtos>(query, parametros);
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
                var query = "Delete From Cliente where IdCliente = @id";
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









        //    VincularItensOs(cadastrarVendaServicoViewModel.IdItens, idOrdemCriada);

        //        var os = BuscarPorIDVendaServico(idOrdemCriada);

        //        if (os != null)
        //        {
        //            os.TotalGeral = CalcularTotalVendaServico(IdVendaServico);
        //            AtualizarTotalGeralOs(os);
        //        }

        //        Console.WriteLine("Venda Servico cadastrada com sucesso!");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return false;
        //    }
        //}
        //public void AtualizarTotalGeralOs(VendaServico IdvendaServico)
        //{
        //    try
        //    {
        //        var query = @"UPDATE VendaServico SET TotalGeral = @totalGeral WHERE IdVendaServico = @idvendaServico";
        //        using (var sql = new SqlConnection(_connection))
        //        {
        //            SqlCommand command = new SqlCommand(query, sql);
        //            command.Parameters.AddWithValue("@idvendaServico", vendaServico.IdVendaServico);
        //            command.Parameters.AddWithValue("@totalGeral", ordensServicoDto.TotalGeral);
        //            command.Connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //    }
        //}
        //public OrdensServicoDto BuscarPorIDOrdemServico(int id)
        //{
        //    OrdensServicoDto ordensServicoDto;
        //    try
        //    {
        //        var query = @"SELECT IdOrdemServico, IdCliente, IdProfissional, IdServico, TotalGeral FROM OrdensServico WHERE IdOrdemServico = @id";

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            var parametros = new
        //            {
        //                id
        //            };
        //            ordensServicoDto = connection.QueryFirst<OrdensServicoDto>(query, parametros);
        //        }

        //        if (ordensServicoDto != null)
        //        {
        //            ordensServicoDto.Itens = BuscarProdutosDaOrdem(id);
        //        }
        //        if (ordensServicoDto != null)
        //        {
        //            ordensServicoDto.execucao = BuscarProfissionaisDaOrdem(id);
        //        }

        //        return ordensServicoDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return null;
        //    }
        //}
        //public List<OrdensServicoDto> BuscarTodos()
        //{
        //    List<OrdensServicoDto> ordensServicoEncontrados;
        //    try
        //    {
        //        var query = @"SELECT IdOrdemServico, IdCliente, IDProfissional, IdServico, IdProduto, TotalGeral FROM OrdensServico";

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            ordensServicoEncontrados = connection.Query<OrdensServicoDto>(query).ToList();
        //        }
        //        return ordensServicoEncontrados;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return null;
        //    }
        //}
        //public void Atualizar(OrdensServico ordensServico, int id)
        //{
        //    try
        //    {
        //        var query = @"UPDATE OrdensServico SET IdCliente = @idCliente, IdProfissional = @idProfissional, IdServico = @idServico, IdProduto = @idProduto, TotalGeral = @totalGeral
        //                    WHERE IdOrdemServico = @idOrdemServico";
        //        using (var sql = new SqlConnection(_connection))
        //        {
        //            SqlCommand command = new SqlCommand(query, sql);
        //            command.Parameters.AddWithValue("@idCliente", id);
        //            command.Parameters.AddWithValue("@idProfissional", ordensServico.IdProfissional);
        //            command.Parameters.AddWithValue("@idServico", ordensServico.IdServico);
        //            command.Parameters.AddWithValue("@idProduto", ordensServico.IdProduto);
        //            command.Parameters.AddWithValue("@totalGeral", ordensServico.TotalGeral);
        //            command.Connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //    }
        //}
        //public OrdensServicoDto Confirmar(int idOrdemServico)
        //{
        //    var ordemServico = new OrdensServicoDto();
        //    try
        //    {
        //        var query = "SELECT * FROM OrdensServico WHERE IdOrdemServico = @idOrdemServico";

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            var parametros = new
        //            {
        //                idOrdemServico
        //            };
        //            ordemServico = connection.QueryFirstOrDefault<OrdensServicoDto>(query, parametros);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        ordemServico = null;
        //    }
        //    return ordemServico;
        //}
        //public void VincularItensOs(List<int> idItens, int idOrdemServico)
        //{
        //    foreach (var item in idItens)
        //    {
        //        var sql = @"INSERT INTO Itens (IdProduto, IdOrdemServico) VALUES (@idProduto, @idOrdemServico)";

        //        var parametros = new
        //        {
        //            idProduto = item,
        //            idOrdemServico
        //        };
        //        try
        //        {
        //            using (var connection = new SqlConnection(_connection))
        //            {
        //                connection.Execute(sql, parametros);
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            Console.WriteLine($"Erro ao salvar Item {item}, para a OS {idOrdemServico}. Erro: {ex.Message}");
        //        }
        //    }
        //}
        //public float CalcularTotalOrdemServico(int idOrdemServico)
        //{
        //    var query = @"SELECT (SELECT SUM(pr.ValorPeca) FROM Servicos s
        //                INNER JOIN OrdensServico os on s.IdServico = os.IdServico
        //                INNER JOIN Itens p on p.IdOrdemServico = os.IdOrdemServico
        //                INNER JOIN Produtos pr on p.IdProduto = pr.IdProduto
        //                WHERE os.IdOrdemServico = @idOrdemServico) + (SELECT s.ValorServico FROM Servicos s
        //                INNER JOIN OrdensServico os on s.IdServico = os.IdServico WHERE IdOrdemServico = @idOrdemServico) as ValorTotalServico";
        //    var parametros = new
        //    {
        //        idOrdemServico
        //    };
        //    using (var connection = new SqlConnection(_connection))
        //    {
        //        var res = connection.QuerySingle<float>(query, parametros);
        //        return res;
        //    }
        //}
        //public void InserirProfissionalOS(List<int> idItens, int idOrdemServico)
        //{
        //    foreach (var item in idItens)
        //    {
        //        var sql = @"INSERT INTO Execucao (IdProfissional, IdOrdemServico) VALUES (@idProfissional, @idOrdemServico)";
        //        var parametros = new
        //        {
        //            idProfissional = item,
        //            idOrdemServico
        //        };
        //        try
        //        {
        //            using (var connection = new SqlConnection(_connection))
        //            {
        //                connection.Execute(sql, parametros);
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            Console.WriteLine($"Erro ao salvar Item {item}, para a OS {idOrdemServico}. Erro: {ex.Message}");
        //        }
        //    }
        //}
        //public void InserirProdutoOS(List<int> idItens, int idOrdemServico)
        //{
        //    foreach (var item in idItens)
        //    {
        //        var sql = @"INSERT INTO Itens (IdProduto, IdOrdemServico) VALUES (@idProduto, @idOrdemServico)";
        //        var parametros = new
        //        {
        //            idProduto = item,
        //            idOrdemServico
        //        };
        //        try
        //        {
        //            using (var connection = new SqlConnection(_connection))
        //            {
        //                connection.Execute(sql, parametros);
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            Console.WriteLine($"Erro ao salvar Item {item}, para a OS {idOrdemServico}. Erro: {ex.Message}");
        //        }
        //    }
        //}

        //public float FaturamentoBruto()
        //{
        //    var query = "SELECT(SELECT SUM(TotalGeral) FROM OrdensServico)";


        //    using (var connection = new SqlConnection(_connection))
        //    {
        //        var res = connection.QuerySingle<float>(query);
        //        return res;
        //    }
        //}
        //private List<ProdutosDto> BuscarProdutosDaOrdem(int id)
        //{
        //    try
        //    {
        //        var query = @"select i.IdProduto, DescricaoPeca, ValorPeca from Itens i 
        //                    inner join Produtos p on i.IdProduto = p.IdProduto
        //                    where i.IdOrdemServico = @idOrdensServico";

        //        var parametros = new
        //        {
        //            idOrdensServico = id
        //        };

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            return connection.Query<ProdutosDto>(query, parametros).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return null;
        //    }
        //}
        //private List<ProfissionaisDto> BuscarProfissionaisDaOrdem(int id)
        //{
        //    try
        //    {
        //        var query = @"select i.IdProfissional, NomeProfissional, CargoProfissional from execucao i 
        //                    inner join Profissionais p on i.IdProfissional = p.IdProfissional
        //                    where i.IdOrdemServico = @idOrdensServico";

        //        var parametros = new
        //        {
        //            idOrdensServico = id
        //        };

        //        using (var connection = new SqlConnection(_connection))
        //        {
        //            return connection.Query<ProfissionaisDto>(query, parametros).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro: " + ex.Message);
        //        return null;
        //    }
        //}

    }
}
