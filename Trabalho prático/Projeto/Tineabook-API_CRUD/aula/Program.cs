using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


//Cadastro Usuários
app.MapPost("/verificaLogin", ([FromBody] JsonObject dados) =>
{
    // Verificando se algum campo necessário está vazio
    if (
        string.IsNullOrEmpty((string)dados["email"]) ||
        string.IsNullOrEmpty((string)dados["senha"]) 
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
                "INSERT INTO usuarios (email, senha) " +
                "VALUES (@email, @senha)",
                conexao
            );

            sql.Parameters.AddWithValue("@email", dados["email"]);
            sql.Parameters.AddWithValue("@senha", dados["senha"]);

            var retorno = sql.ExecuteNonQuery();


            if (retorno == 1)
            {
                return Results.Ok("Login autorizado!");
            }
            else
            {
                return Results.Problem("Erro ao logar :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar o cadastro: {error.Message}");
        }
    }
})
.WithName("verificaLogin");



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




//Cadastro Usuários
app.MapPost("/cadastrarLivros", ([FromBody] JsonObject dados) => 
{ 
    // Verificando se algum campo necessário está vazio
    if (
        string.IsNullOrEmpty((string)dados["titulo"]) ||
        string.IsNullOrEmpty((string)dados["autor"]) ||
        string.IsNullOrEmpty((string)dados["edicao"]) ||
        string.IsNullOrEmpty((string)dados["total_paginas"]) ||
        string.IsNullOrEmpty((string)dados["formato_livro"])
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
                "INSERT INTO livros (titulo, autor, edicao, total_paginas, formato_livro) " +
                "VALUES (@titulo, @autor, @edicao, @total_paginas, @formato_livro)",
                conexao
            );

            sql.Parameters.AddWithValue("@titulo", dados["titulo"]);
            sql.Parameters.AddWithValue("@autor", dados["autor"]);
            sql.Parameters.AddWithValue("@edicao", dados["edicao"]);
            sql.Parameters.AddWithValue("@total_paginas", dados["total_paginas"]);
            sql.Parameters.AddWithValue("@formato_livro", dados["formato_livro"]);

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
.WithName("cadastrarLivros");



app.MapPost("/criarResenha", ([FromBody] JsonObject dados ) =>
{
    if (
        string.IsNullOrEmpty((string)dados["id_usuario"]) ||
        string.IsNullOrEmpty((string)dados["id_livro"]) ||
        string.IsNullOrEmpty((string)dados["data"]) ||
        string.IsNullOrEmpty((string)dados["status"]) ||
        string.IsNullOrEmpty((string)dados["estrelas"]) ||
        string.IsNullOrEmpty((string)dados["resenha"])       
    )
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }

    string connectionString = "server=localhost;password=;User Id=root;database=tineabookbd;";

    using (MySqlConnection conexao = new MySqlConnection(connectionString))
    {
        try
        {
            conexao.Open();

            MySqlCommand sql = new MySqlCommand(
                "INSERT INTO avaliacao (id_usuario, id_livro, data, estrelas, resenha) " +
                "VALUES (@id_usuario, @id_livro, @data, @estrelas, @resenha)",
            conexao
            );

            sql.Parameters.AddWithValue("@id_usuario", dados["id_usuario"]);
            sql.Parameters.AddWithValue("@id_livro", dados["id_livro"]);
            sql.Parameters.AddWithValue("@data", dados["data"]);
            sql.Parameters.AddWithValue("@estrelas", dados["estrelas"]);
            sql.Parameters.AddWithValue("@resenha", dados["resenha"]);

            var retorno = sql.ExecuteNonQuery();

            if (retorno == 1)
            {
                return Results.Ok("Resenha realizada com sucesso!");
            }
            else
            {
                return Results.Problem("Algo deu errado :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar a resenha: {error.Message}");
        }
    }
})
.WithName("criarResenha");


app.MapPost("/addHistorico", ([FromBody] JsonObject dados) =>
{
    if (
        string.IsNullOrEmpty((string)dados["id_usuario"]) ||
        string.IsNullOrEmpty((string)dados["id_livro"]) ||
        string.IsNullOrEmpty((string)dados["data"]) ||
        string.IsNullOrEmpty((string)dados["pagsLidas"])
    )
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }

    string connectionString = "server=localhost;password=;User Id=root;database=tineabookbd;";

    using (MySqlConnection conexao = new MySqlConnection(connectionString))
    {
        try
        {
            conexao.Open();

            MySqlCommand sql = new MySqlCommand(
                "INSERT INTO avaliacao (id_usuario, id_livro, data, pagsLidas) " +
                "VALUES (@id_usuario, @id_livro, @data, @pagsLidas)",
            conexao
            );

            sql.Parameters.AddWithValue("@id_usuario", dados["id_usuario"]);
            sql.Parameters.AddWithValue("@id_livro", dados["id_livro"]);
            sql.Parameters.AddWithValue("@data", dados["data"]);
            sql.Parameters.AddWithValue("@status", dados["pagsLidas"]);

            var retorno = sql.ExecuteNonQuery();

            if (retorno == 1)
            {
                return Results.Ok("Resenha realizada com sucesso!");
            }
            else
            {
                return Results.Problem("Algo deu errado :(");
            }
        }
        catch (Exception error)
        {
            return Results.Problem($"Erro ao realizar a resenha: {error.Message}");
        }
    }
})
.WithName("addHistorico");



app.Run();
