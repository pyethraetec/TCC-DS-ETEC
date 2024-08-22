let email, nome, usuario, senha, csenha;
        email = document.getElementById("email");
        nome = document.getElementById("nome");
        usuario = document.getElementById("usuario");
        senha = document.getElementById("senha");
        csenha = document.getElementById("csenha");




function alert22(){
    email.style = "";
    nome.style = "";
    usuario.style = "";
    senha.style = "";
    csenha.style = "";
  if(email.value == ""){
    alert ("Preencha o 1° campo");
    email.style="border:2px solid red;";
      return false;

  }

else if(nome.value == ""){
    alert ("Preencha o 2° campo");
    nome.style="border:2px solid red;";
    return false;
}



else if(usuario == ""){
  alert ("Preencha o 3° campo");
  usuario.style="border:2px solid red;";
}

else if(senha == ""){
  alert ("Preencha o 4° campo");
  senha.style="border:2px solid red;";
}


else if(csenha == ""){
  alert ("Preencha o 5° campo");
  csenha.style="border:2px solid red;";
}


return true;
  }
