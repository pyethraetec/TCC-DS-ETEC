<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tineabook</title>
</head>
<body>
    <!--Sessão de cadastro-->
    <div class="w3-container w3-display-middle">
        <h2>Cadastro de Usuário</h2>
          
        <form action="" method="post" class="w3-xlarge">
          <table>
            <tr>
                <td>E-mail:</td>
                <td><input type="email" name="email" required></td>
            </tr>
            <tr>
              <td>Nome:</td>
              <td><input type="text" name="nome" required></td>
            </tr>
            <tr>
                <td>Usuário:</td>
                <td><input type="text" name="apelido" required></td>
            </tr>
            
            <tr>
              <td>Insira sua senha:</td>
              <td><input type="password" name="senha" required></td>
            </tr>
            <tr>
                <td>Confirma sua senha:</td>
                <td><input type="password" name="confirma_senha" required></td>
            </tr>
            <tr>
                <td>Selecione sua data de nascimento:</td>
                <td><input type="date" name="data_nasc" /></td>
            </tr>
            <tr>
              <td>
                <br>
                <!--Botão cadastro-->
                <button type="submit" class="w3-button w3-green w3-large">Cadastrar</button></td>
              <td align="right">
                <br>
                <!--Botão voltar index-->
                <a href="login.php" class="w3-button w3-red w3-large">Voltar ao Início</a></td>
            </tr>
          </table>
        </form>
        <?php

        if($_SERVER["REQUEST_METHOD"] == "POST"){

            $email = $_POST["email"];
            $nome = $_POST["nome"];
            $apelido = $_POST["apelido"];
            $senha = $_POST["senha"];
            $confirma_senha = $_POST["confirma_senha"];
            $data_nasc = $_POST["data_nasc"];

            if ($senha !== $confirma_senha) {
                echo "As senhas não coincidem!";
                exit();
            }

            $conexao = mysqli_connect("localhost", "aluno", "aluno.etec", "usuario");

            if($conexao == false){
                die("A conexão falhou: " . mysqli_connect_error());
            }

            $query2 = mysqli_query($conexao, "SELECT * FROM usuarios WHERE apelido = '$apelido'");
            if(mysqli_num_rows($query2) >= 1){
              echo "Apelido já existente!";
              exit();
            }
            
            $query1 = mysqli_query($conexao, "SELECT * FROM usuarios WHERE email = '$email'");

            if(mysqli_num_rows($query1) >= 1){
              echo "E-mail já existente!";
              exit();
            }

            $query = mysqli_query($conexao, "INSERT INTO usuarios (nome, apelido, data_nasc, email, senha) VALUES ('$nome','$apelido','$data_nasc', '$email', '$senha')");

            if($query){
                header("Location: home.php");
                exit();
            }
            else{
                echo "Erro ao efetuar o cadastro: " . mysqli_error($conexao);
            }
        }
        ?>
      </div>
</body>
</html>
