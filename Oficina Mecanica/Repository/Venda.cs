using Oficina_Mecanica.ViewModelsAtualizar;
using Oficina.Modelos;
using Oficina_Mecanica.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMecanica.Repositories
{
    public class ClienteRepository
    {
        private readonly string _connection = @"Data Source=ITELABD021\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";
        //private readonly string _connection = @"Data Source=\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";

        public bool Salvar(CadastrarVendaServicoViewModel CadastrarVendaServicoViewModel)
        {
            try
            {
                int idOrdemCriada = -1;
                var query = @"INSERT INTO OrdensServico 
                              (IdCliente, IdProfissional, IdServico) OUTPUT INSERTED.IdOrdemServico VALUES (@idCliente,@idProfissional,@idServico)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idCliente", cadastrarVendaServicoViewModel.IdCliente);
                    command.Parameters.AddWithValue("@idProfissional", cadastrarVendaServicoViewModel.IdProfissional);
                    command.Parameters.AddWithValue("@idServico", cadastrarVendaServicoViewModel.IdServico);
                    command.Connection.Open();
                    idOrdemCriada = (int)command.ExecuteScalar();
                }

                VincularItensOs(cadastrarVendaServicoViewModel.IdItens, idOrdemCriada);

                var os = BuscarPorIDVendaServico(idOrdemCriada);

                if (os != null)
                {
                    os.TotalGeral = CalcularTotalVendaServico(IdVendaServico);
                    AtualizarTotalGeralOs(os);
                }

                Console.WriteLine("Venda Servico cadastrada com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
        public void AtualizarTotalGeralOs(VendaServico IdvendaServico)
        {
            try
            {
                var query = @"UPDATE VendaServico SET TotalGeral = @totalGeral WHERE IdVendaServico = @idvendaServico";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idvendaServico", vendaServico.IdVendaServico);
                    command.Parameters.AddWithValue("@totalGeral", ordensServicoDto.TotalGeral);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public OrdensServicoDto BuscarPorIDOrdemServico(int id)
        {
            OrdensServicoDto ordensServicoDto;
            try
            {
                var query = @"SELECT IdOrdemServico, IdCliente, IdProfissional, IdServico, TotalGeral FROM OrdensServico WHERE IdOrdemServico = @id";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    ordensServicoDto = connection.QueryFirst<OrdensServicoDto>(query, parametros);
                }

                if (ordensServicoDto != null)
                {
                    ordensServicoDto.Itens = BuscarProdutosDaOrdem(id);
                }
                if (ordensServicoDto != null)
                {
                    ordensServicoDto.execucao = BuscarProfissionaisDaOrdem(id);
                }

                return ordensServicoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public List<OrdensServicoDto> BuscarTodos()
        {
            List<OrdensServicoDto> ordensServicoEncontrados;
            try
            {
                var query = @"SELECT IdOrdemServico, IdCliente, IDProfissional, IdServico, IdProduto, TotalGeral FROM OrdensServico";

                using (var connection = new SqlConnection(_connection))
                {
                    ordensServicoEncontrados = connection.Query<OrdensServicoDto>(query).ToList();
                }
                return ordensServicoEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public void Atualizar(OrdensServico ordensServico, int id)
        {
            try
            {
                var query = @"UPDATE OrdensServico SET IdCliente = @idCliente, IdProfissional = @idProfissional, IdServico = @idServico, IdProduto = @idProduto, TotalGeral = @totalGeral
                            WHERE IdOrdemServico = @idOrdemServico";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idCliente", id);
                    command.Parameters.AddWithValue("@idProfissional", ordensServico.IdProfissional);
                    command.Parameters.AddWithValue("@idServico", ordensServico.IdServico);
                    command.Parameters.AddWithValue("@idProduto", ordensServico.IdProduto);
                    command.Parameters.AddWithValue("@totalGeral", ordensServico.TotalGeral);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public OrdensServicoDto Confirmar(int idOrdemServico)
        {
            var ordemServico = new OrdensServicoDto();
            try
            {
                var query = "SELECT * FROM OrdensServico WHERE IdOrdemServico = @idOrdemServico";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        idOrdemServico
                    };
                    ordemServico = connection.QueryFirstOrDefault<OrdensServicoDto>(query, parametros);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                ordemServico = null;
            }
            return ordemServico;
        }
        public void VincularItensOs(List<int> idItens, int idOrdemServico)
        {
            foreach (var item in idItens)
            {
                var sql = @"INSERT INTO Itens (IdProduto, IdOrdemServico) VALUES (@idProduto, @idOrdemServico)";

                var parametros = new
                {
                    idProduto = item,
                    idOrdemServico
                };
                try
                {
                    using (var connection = new SqlConnection(_connection))
                    {
                        connection.Execute(sql, parametros);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Erro ao salvar Item {item}, para a OS {idOrdemServico}. Erro: {ex.Message}");
                }
            }
        }
        public float CalcularTotalOrdemServico(int idOrdemServico)
        {
            var query = @"SELECT (SELECT SUM(pr.ValorPeca) FROM Servicos s
                        INNER JOIN OrdensServico os on s.IdServico = os.IdServico
                        INNER JOIN Itens p on p.IdOrdemServico = os.IdOrdemServico
                        INNER JOIN Produtos pr on p.IdProduto = pr.IdProduto
                        WHERE os.IdOrdemServico = @idOrdemServico) + (SELECT s.ValorServico FROM Servicos s
                        INNER JOIN OrdensServico os on s.IdServico = os.IdServico WHERE IdOrdemServico = @idOrdemServico) as ValorTotalServico";
            var parametros = new
            {
                idOrdemServico
            };
            using (var connection = new SqlConnection(_connection))
            {
                var res = connection.QuerySingle<float>(query, parametros);
                return res;
            }
        }
        public void InserirProfissionalOS(List<int> idItens, int idOrdemServico)
        {
            foreach (var item in idItens)
            {
                var sql = @"INSERT INTO Execucao (IdProfissional, IdOrdemServico) VALUES (@idProfissional, @idOrdemServico)";
                var parametros = new
                {
                    idProfissional = item,
                    idOrdemServico
                };
                try
                {
                    using (var connection = new SqlConnection(_connection))
                    {
                        connection.Execute(sql, parametros);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Erro ao salvar Item {item}, para a OS {idOrdemServico}. Erro: {ex.Message}");
                }
            }
        }
        public void InserirProdutoOS(List<int> idItens, int idOrdemServico)
        {
            foreach (var item in idItens)
            {
                var sql = @"INSERT INTO Itens (IdProduto, IdOrdemServico) VALUES (@idProduto, @idOrdemServico)";
                var parametros = new
                {
                    idProduto = item,
                    idOrdemServico
                };
                try
                {
                    using (var connection = new SqlConnection(_connection))
                    {
                        connection.Execute(sql, parametros);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Erro ao salvar Item {item}, para a OS {idOrdemServico}. Erro: {ex.Message}");
                }
            }
        }

        public float FaturamentoBruto()
        {
            var query = "SELECT(SELECT SUM(TotalGeral) FROM OrdensServico)";


            using (var connection = new SqlConnection(_connection))
            {
                var res = connection.QuerySingle<float>(query);
                return res;
            }
        }
        private List<ProdutosDto> BuscarProdutosDaOrdem(int id)
        {
            try
            {
                var query = @"select i.IdProduto, DescricaoPeca, ValorPeca from Itens i 
                            inner join Produtos p on i.IdProduto = p.IdProduto
                            where i.IdOrdemServico = @idOrdensServico";

                var parametros = new
                {
                    idOrdensServico = id
                };

                using (var connection = new SqlConnection(_connection))
                {
                    return connection.Query<ProdutosDto>(query, parametros).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        private List<ProfissionaisDto> BuscarProfissionaisDaOrdem(int id)
        {
            try
            {
                var query = @"select i.IdProfissional, NomeProfissional, CargoProfissional from execucao i 
                            inner join Profissionais p on i.IdProfissional = p.IdProfissional
                            where i.IdOrdemServico = @idOrdensServico";

                var parametros = new
                {
                    idOrdensServico = id
                };

                using (var connection = new SqlConnection(_connection))
                {
                    return connection.Query<ProfissionaisDto>(query, parametros).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

    }
}
