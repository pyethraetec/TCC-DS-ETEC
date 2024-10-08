using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//
app.MapGet("/consultaUsuarios", () =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = 
        "server=localhost;" +
        "password= ;" +
        "User Id=root;" +
        "database=tineabookbd;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("SELECT * FROM usuarios",conexao);

    DataTable dados = new DataTable();
    dados.Load(sql.ExecuteReader());

    conexao.Close();

    return Results.Ok(JsonDocument.Parse(JsonConvert.SerializeObject(dados)));
})
.WithName("ListarAluno");


//Cadastro Usuários
app.MapPost("/cadastrarUsuario", ([FromBody] JsonObject dados) =>
{
    // Verificando se algum campo necessário está vazio
    if (
        string.IsNullOrEmpty((string)dados["nome"]) ||
        string.IsNullOrEmpty((string)dados["apelido"]) ||
        string.IsNullOrEmpty((string)dados["data_nasc"]) ||
        string.IsNullOrEmpty((string)dados["email"]) ||
        string.IsNullOrEmpty((string)dados["senha"]) ||
        string.IsNullOrEmpty((string)dados["bio"])
    )
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }

    // String de conexão ao banco de dados
    string connectionString = "server=localhost;password=;User Id=root;database=tineabookbd;";

    using (MySqlConnection conexao = new MySqlConnection(connectionString))
    {
        try
        {
            conexao.Open();

            MySqlCommand sql = new MySqlCommand(
                "INSERT INTO usuarios (nome, apelido, data_nasc, email, senha, bio) " +
                "VALUES (@nome, @apelido, @data_nasc, @email, @senha, @bio)",
                conexao
            );

            sql.Parameters.AddWithValue("@nome", dados["nome"]);
            sql.Parameters.AddWithValue("@apelido", dados["apelido"]);
            sql.Parameters.AddWithValue("@data_nasc", dados["data_nasc"]);
            sql.Parameters.AddWithValue("@email", dados["email"]);
            sql.Parameters.AddWithValue("@senha", dados["senha"]);
            sql.Parameters.AddWithValue("@bio", dados["bio"]);

            var retorno = sql.ExecuteNonQuery();

            if (retorno == 1)
            {
                return Results.Ok("Cadastro realizado com sucesso!");
            }
            else
            {
                return Results.Problem("Oh não! Seu cadastro deu errado :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar o cadastro: {error.Message}");
        }
    }
})
.WithName("cadastrarUsuario");


//Alterar informações da conta do usuário
app.MapPost("/alterarUsuario/apelido/{idUsuario}", ([FromBody] JsonObject dados, string id) =>
{
    if (
        string.IsNullOrEmpty((string)dados["Apelido"])
    )
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }


    // String de conexão ao banco de dados
    string connectionString = "server=localhost;password=;User Id=root;database=tineabookbd;";

    using (MySqlConnection conexao = new MySqlConnection(connectionString))
    {
        try
        {
            conexao.Open();
            //UPDATE TABELA SET COLUNA = ""; WHERE ID = @ID; 
            MySqlCommand sql = new MySqlCommand("UPDATE usuarios SET apelido = @apelido WHERE id = @id", conexao);
            sql.Parameters.AddWithValue("@apelido", dados["Apelido"]);
            sql.Parameters.AddWithValue("@id", id);

            var retorno = sql.ExecuteNonQuery();

            if (retorno == 1)
            {
                return Results.Ok("Cadastro realizado com sucesso!");
            }
            else
            {
                return Results.Problem("Oh não! Seu cadastro deu errado :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar o cadastro: {error.Message}");
        }
    }
})
.WithName("alterarUsuarioApelido");


//Alterar informações da conta do usuário
app.MapPost("/alterarUsuario/bio/{idUsuario}", ([FromBody] JsonObject dados, string id) =>
{
    if (
        string.IsNullOrEmpty((string)dados["bio"])
    )
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }


    // String de conexão ao banco de dados
    string connectionString = "server=localhost;password=;User Id=root;database=tineabookbd;";

    using (MySqlConnection conexao = new MySqlConnection(connectionString))
    {
        try
        {
            conexao.Open();
            //UPDATE TABELA SET COLUNA = ""; WHERE ID = @ID; 
            MySqlCommand sql = new MySqlCommand("UPDATE usuarios SET bio = @bio WHERE id = @id", conexao);
            sql.Parameters.AddWithValue("@bio", dados["Bio"]);
            sql.Parameters.AddWithValue("@id", id);

            var retorno = sql.ExecuteNonQuery();

            if (retorno == 1)
            {
                return Results.Ok("Cadastro realizado com sucesso!");
            }
            else
            {
                return Results.Problem("Oh não! Seu cadastro deu errado :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar o cadastro: {error.Message}");
        }
    }
})
.WithName("alterarUsuarioBio");


app.MapDelete("/excluirUsuario/{idUsuario}", ([FromBody] JsonObject dados, string id) =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=escola;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("DELETE FROM aluno WHERE id = @id", conexao);
    sql.Parameters.AddWithValue("@id", id);

    var retorno = sql.ExecuteNonQuery();

    conexao.Close();

    if (retorno == 1)
    {
        return Results.Ok();
    }
    else
    {
        return Results.Problem();
    }

})
.WithName("excluirUsuario");





//LIVROS

app.MapGet("/consultaLivros", () =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString =
        "server=localhost;" +
        "password= ;" +
        "User Id=root;" +
        "database=tineabookbd;";

    conexao.Open();

    MySqlCommand sql = new MySqlCommand("SELECT * FROM livros", conexao);

    DataTable dados = new DataTable();
    dados.Load(sql.ExecuteReader());

    conexao.Close();

    return Results.Ok(JsonDocument.Parse(JsonConvert.SerializeObject(dados)));
})
.WithName("consultaLivros");


//Cadastro Usuários
app.MapPost("/cadastrarLivro", ([FromBody] JsonObject dados) =>
{
    // Verificando se algum campo necessário está vazio
    if (
        string.IsNullOrEmpty((string)dados["nome"]) ||
        string.IsNullOrEmpty((string)dados["apelido"]) ||
        string.IsNullOrEmpty((string)dados["data_nasc"]) ||
        string.IsNullOrEmpty((string)dados["email"]) ||
        string.IsNullOrEmpty((string)dados["senha"]) ||
        string.IsNullOrEmpty((string)dados["bio"])
    )
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }

    // String de conexão ao banco de dados
    string connectionString = "server=localhost;password=;User Id=root;database=tineabookbd;";

    using (MySqlConnection conexao = new MySqlConnection(connectionString))
    {
        try
        {
            conexao.Open();

            MySqlCommand sql = new MySqlCommand(
                "INSERT INTO usuarios (nome, apelido, data_nasc, email, senha, bio) " +
                "VALUES (@nome, @apelido, @data_nasc, @email, @senha, @bio)",
                conexao
            );

            sql.Parameters.AddWithValue("@nome", dados["nome"]);
            sql.Parameters.AddWithValue("@apelido", dados["apelido"]);
            sql.Parameters.AddWithValue("@data_nasc", dados["data_nasc"]);
            sql.Parameters.AddWithValue("@email", dados["email"]);
            sql.Parameters.AddWithValue("@senha", dados["senha"]);
            sql.Parameters.AddWithValue("@bio", dados["bio"]);

            var retorno = sql.ExecuteNonQuery();

            if (retorno == 1)
            {
                return Results.Ok("Cadastro realizado com sucesso!");
            }
            else
            {
                return Results.Problem("Oh não! Seu cadastro deu errado :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar o cadastro: {error.Message}");
        }
    }
})
.WithName("cadastrarLivro");



app.Run();
