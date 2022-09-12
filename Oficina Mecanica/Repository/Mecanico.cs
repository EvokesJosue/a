using Dapper;
using Oficina_Mecanica.Dtos;
using Oficina_Mecanica.ViewModels;
using Oficina_Mecanica.Repository;
using Oficina.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Oficina_Mecanica.Repository
{
    public class MecanicoRepository
    {
        private readonly string _connection = @"Data Source=DESKTOP-8JAGM2K\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";
        //private readonly string _connection = @"Data Source=\SQLEXPRESS;Initial Catalog=Oficina_Mecanica;Integrated Security=True;";

        public bool Salvar(CadastrarMecanicoViewModel salvarMecanicoViewModel)
        {
            try
            {
                var query = @"INSERT INTO Mecanico (IdMecanico, Usuario_IdUsuario, Apelido, Funcao) VALUES (@idMecanico,@usuario_idUsuario,@apelido,@funcao)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idMecanico", salvarMecanicoViewModel.IdMecanico);
                    command.Parameters.AddWithValue("@usuario_idUsuario", salvarMecanicoViewModel.Usuario_IdUsuario);
                    command.Parameters.AddWithValue("@apelido", salvarMecanicoViewModel.Apelido);
                    command.Parameters.AddWithValue("@funcao", salvarMecanicoViewModel.Funcao);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Profissional Cadastrado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
        public List<MecanicoDtos> BuscarPorNome(string nome)
        {
            List<MecanicoDtos> mecanicosEncontrados;
            try
            {
                var query = @"SELECT IdMecanico, Usuario_IdUsuario, Funcao FROM Mecanico WHERE IdMecanico = @idMecanico";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    mecanicosEncontrados = connection.Query<MecanicoDtos>(query, parametros).ToList();

                    return mecanicosEncontrados;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public List<MecanicoDtos> BuscarTodos()
        {
            List<MecanicoDtos> mecnicosEncontrados;
            try
            {
                var query = @"SELECT IdMecanico, Usuario_IdUsuario, Apelido, Funcao FROM Mecanico";

                using (var connection = new SqlConnection(_connection))
                {
                    mecnicosEncontrados = connection.Query<MecanicoDtos>(query).ToList();
                }
                return mecnicosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public void Atualizar(Mecanico mecanico, int id, string Apelido, string Funcao)
        {
            try
            {
                var query = @"UPDATE Mecanico set IdMecancio = (@idMecanico,@usuario_idUsuario,@apelido,@funcao WHERE IdMecanico, Usuario_IdUsuario, Apelido, Funcao = @idMecanico";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idMecanico", Mecanico.IdMecancio);
                    command.Parameters.AddWithValue("@usuario_idUsuario", Mecanico.Usuario_IdUsuario);
                    command.Parameters.AddWithValue("@apelido", Apelido);
                    command.Parameters.AddWithValue("@funcao", Funcao);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public MecanicoDtos Confirmar(int IdMecanico)
        {
            var mecanico = new MecanicoDtos();
            try
            {
                var query = "SELECT * FROM Mecanico WHERE IdMecanico = @idMecanico";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        IdMecanico
                    };
                    mecanico = connection.QueryFirstOrDefault<MecanicoDtos>(query, parametros);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                mecanico = null;
            }
            return mecanico;
        }
        public void Deletar(int IdMecanico, object Funcao)
        {
            try
            {
                var query = "DELETE FROM Mecanico WHERE IdMecanico = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idMecanico", Mecanico.IdMecancio);
                    command.Parameters.AddWithValue("@usuario_idUsuario", Mecanico.Usuario_IdUsuario);
                    object Apelido = null;
                    command.Parameters.AddWithValue("@apelido", Apelido);
                    command.Parameters.AddWithValue("@funcao", Funcao);
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

    public class CadastrarMecanicoViewModel
    {
        public object IdMecanico { get; internal set; }
        public object Usuario_IdUsuario { get; internal set; }
        public object Apelido { get; internal set; }
        public object Funcao { get; internal set; }
    }
}
