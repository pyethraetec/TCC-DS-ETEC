var email, nome, usuario, senha, csenha;
        email = document.getElementById("email");
        nome = document.getElementById("nome");
        usuario = document.getElementById("usuario");
        senha = document.getElementById("senha");
        csenha = document.getElementById("csenha");




function cadastro(){
    email.style = "";
    nome.style = "";
    usuario.style = "";
    senha.style = "";
    csenha.style = "";
  if(email.value == ""){
    alert ("Digite o seu e-mail");
    email.style="border:2px solid red;";
      return false;

  }

else if(nome.value == ""){
    alert ("Digite o seu nome");
    nome.style="border:2px solid red;";
    return false;
}



else if(usuario == ""){
  alert ("Qual o seu apelido");
  usuario.style="border:2px solid red;";
}

else if(senha == ""){
  alert ("Digite sua senha");
  senha.style="border:2px solid red;";
}


else if(csenha != senha){
  alert ("As senhas não batem");
  csenha.style="border:2px solid red;";
}


return true;
  }
