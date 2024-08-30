var email, senha;

email = document.getElementById("email");
senha = document.getElementById("senha");

function login(){
    email.style = "";
    senha.style = "";

    if(email.value == ""){
        alert("Digite o seu e-mail");
        email.style = "border:2px solid red;";
        return false;
    }

    if(senha.value == ""){
        alert("Digite a sua senha");
        senha.style = "border:2px solid red;";
        return false;
    }

    return true;
}