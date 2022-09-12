using Oficina_Mecanica.Dtos;
using Oficina.Modelos;
using Oficina_Mecanica.ViewModels;
using System;
using System.ServiceProcess;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina_Mecanica.Repositories
{
    public class ProdutosRepository
    {
        private readonly string _connection = @"Data Source=DESKTOP-8JAGM2K\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";
        //private readonly string _connection = @"Data Source=\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";


        public bool Salvar(CadastrarProdutoViewModel salvarProdutoViewModel)
        {
            try
            {

        //public string Descricao_Marca { get; set; }

                var query = @"INSERT INTO Produtos (IdProduto, Estoque_IdEstoque, Descricao, Un, Descricao_Marca, Codigo, Valor_Custo, Valor_Avista, valor_Prazo ) VALUES (@idProduto,@estoque_idEstoque,@descrição,@un,@descricao_marca,@codigo,@valor_custo,@valor_aVista.@valor_aPrazo)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idProduto", salvarProdutoViewModel.IdProduto);
                    command.Parameters.AddWithValue("@estoque_idEstoque", salvarProdutoViewModel.Estoque_IdEstoque);
                    command.Parameters.AddWithValue("@descrição", salvarProdutoViewModel.Descricao);
                    command.Parameters.AddWithValue("@un", salvarProdutoViewModel.Un);
                    command.Parameters.AddWithValue("@descricao_marca", salvarProdutoViewModel.Descricao_Marca);
                    command.Parameters.AddWithValue("@codigo", salvarProdutoViewModel.Codigo);
                    command.Parameters.AddWithValue("@valor_custo", salvarProdutoViewModel.Valor_Custo);
                    command.Parameters.AddWithValue("@valor_aVista", salvarProdutoViewModel.Valor_Avista);
                    command.Parameters.AddWithValue("@valor_aPrazo", salvarProdutoViewModel.valor_Prazo);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Peça cadastrada com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;

            }
        }
        public List<ProdutoDtos> BuscarPorNome(string nome)
        {
            List<ProdutoDtos> produtosEncontrados;
            try
            {
                var query = @"SELECT IdProduto, Descricao, Valor_Custo FROM Produtos WHERE DescricaoPeca = @nome";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    produtosEncontrados = connection.Query<ProdutoDtos>(query, parametros).ToList();
                }
                return produtosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public List<ProdutoDtos> BuscarTodos()
        {
            List<ProdutoDtos> produtosEncontrados;
            try
            {
                var query = @"SELECT IdProduto, Descricao, Valor_Custo FROM Produtos";

                using (var connection = new SqlConnection(_connection))
                {
                    produtosEncontrados = connection.Query<ProdutoDtos>(query).ToList();
                }
                return produtosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public void Atualizar(Produto produtos, int id)
        {
            // Acrescentar UN(unidade?)

            try
            {
                var query = @"UPDATE Produtos SET Descricao, Valor_Custo, Valor_Avista, Valor_Aprazo = @descricao,@Valor_Custo, @Valor_Avista,@valor_Prazo WHERE IdProduto = @idProduto";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idProduto", id);
                    command.Parameters.AddWithValue("@descricaoPeca", produtos.Descricao);
                    command.Parameters.AddWithValue("@valor_custo", produtos.Valor_Custo);
                    command.Parameters.AddWithValue("@valor_aVista", produtos.Valor_Avista);
                    command.Parameters.AddWithValue("@valor_aPrazo", produtos.Valor_Aprazo);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public ProdutoDtos Confirmar(int idProduto)
        {
            var produto = new ProdutoDtos();
            try
            {
                var query = "SELECT * FROM Produtos WHERE IdProduto = @idProduto";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        idProduto
                    };
                    produto = connection.QueryFirstOrDefault<ProdutoDtos>(query, parametros);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                produto = null;
            }
            return produto;
        }
        public void Deletar(int id)
        {
            try
            {
                var query = "DELETE FROM Produtos WHERE idProduto = @id";
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
    }

    public class CadastrarProdutoViewModel
    {
    }
}
