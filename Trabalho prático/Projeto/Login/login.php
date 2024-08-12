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
        <h2>Login</h2>
          
        <!--Forms-->
        <form action="" method="post" class="w3-xlarge">
          <table>
            <tr>
                <td>E-mail:</td>
                <td><input type="email" name="email" required></td>
            </tr>            
            <tr>
              <td>Senha:</td>
              <td><input type="password" name="senha" required></td>
            </tr>
            <tr> 
              
            <td>
            <!--Botão Login-->
              <button onclick="document.getElementById('id01').style.display='block'" class="w3-button w3-green w3-large">Entrar</button>
            </td>
                
            <!--Botão redefinir senha-->
            <td align="right">                  
              <a href="recuperar.php" class="w3-button w3-red w3-large">Esqueceu sua senha?</a>
            </td>

            <tr>
            <!--Botão Cadastre-->
              <td>
                Não tem uma conta?
                <a href="cadastro.php" class="w3-button w3-red w3-large">Cadastre-se!</a>
              </td>
              </tr>
            </tr>
          </table>
        </form>

        <?php
        if($_SERVER["REQUEST_METHOD"] == "POST"){

            $email = $_POST["email"];
            $senha = $_POST["senha"];

            $conexao = mysqli_connect("localhost", "root", "", "usuario");

            if($conexao == false){
                die("A conexão falhou: " . mysqli_connect_error());
            }
            
            $query = mysqli_query($conexao, "SELECT * FROM usuarios WHERE email = '$email' AND senha = '$senha'");

            if(mysqli_num_rows($query) > 0){
                header("Location: home.php");
                exit();
            } else {
                echo "E-mail ou senha incorretos!";
            }
        }
        ?>
          
      </div>
</body>
</html>