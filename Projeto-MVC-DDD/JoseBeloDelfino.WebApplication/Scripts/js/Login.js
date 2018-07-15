"use script";
var Login = {

    Logar: function (login, senha) {
        localStorage.getItem('jtoken', '');
        var url = "/Login/Login";

        $.ajax({
            url: url
            , datatype: "json"
            , type: "POST"
            , async: false
            , data: { LoginFuncionario: login, SenhaHash: senha }
            , cache: false
        }).done(function (data) {

            var login = {
                grant_type: 'password',
                username: data.Login,
                password: data.SenhaHash
            }
            $.ajax({
                url: "http://localhost:21963/api/autentication/token",
                type: 'post',
                contentType: 'x-www-form-urlencoded',
                data: login
            }).done(function (data) {
                localStorage.setItem('jtoken', data.access_token);
                window.setTimeout(function () {
                    window.location = "/Funcionario/Index?Token=" + data.access_token;
                }, 3000);
            })
            .fail(function (data) {
                Mensagem("Funcionário ou Senha inválida!!!", "Erro");
            });
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception)
        });
    }
}

$(document).ready(function () {

    $("#btLogar").click(function () {
        var login = $("#LoginFuncionario").val();
        var senha = $("#SenhaHash").val();
        var loginValido = false;
        var sanhaValido = false;

        if (login == "") {
            $("#LoginFuncionario").css({ 'border': '1px solid #FF0000' });
            Mensagem("Login e senha são obrigatórios!", "Erro");
        }
        else {
            $("#LoginFuncionario").css({ 'border': '1px solid #D8D8D8' });
            loginValido = true;
        }
        if (senha == "") {
            $("#SenhaHash").css({ 'border': '1px solid #FF0000' });
            Mensagem("Login e senha são obrigatórios!", "Erro");
        }
        else {
            $("#SenhaHash").css({ 'border': '1px solid #D8D8D8' });
            sanhaValido = true;
        }

        if (loginValido && sanhaValido) {
            Login.Logar(login, senha);
        }
    });

    $("#LoginFuncionario").blur(function () {
        $("#LoginFuncionario").css({ 'border': '1px solid #D8D8D8' });
    })

    $("#SenhaHash").blur(function () {
        $("#SenhaHash").css({ 'border': '1px solid #D8D8D8' });
    })
})

function Mensagem(mensagem, tipo, time, funcionalidade) {
    if (tipo == "" || tipo == undefined) {
        tipo = "erro";
    }

    var div = $("#mensagem");

    if (($("#myModalContent").data('bs.modal') || {}).isShown) {
        div = $("#mensagemModal");
    }

    if ($("#mySidenav").css("width") == "400px") {
        div = $("#mensagemNav");
    }

    if (($("#myModal").data('bs.modal') || {}).isShown) {
        div = $("#mensagemModalDelete");
    }

    div.html("");
    div.removeClass();

    switch (tipo.toLowerCase()) {
        case "sucesso":
            div.addClass("alert alert-success");
            break;
        case "info":
            div.addClass("alert alert-info");
            break;
        case "erro":
            div.addClass("alert alert-danger");
            break;
        case "aviso":
            div.addClass("alert alert-warning");
            break;
    }

    if (time === undefined) time = 10000;

    if (time == 0) {
        div.html(mensagem)
            .show();
    } else {
        div.html(mensagem)
            .show()
            .fadeOut(time);
    }

    location.href = "#";
    location.href = "#mensagem";
}

function ValidarElementoCustomizadoSimples(element, error, valid) {
    if (valid) {
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
    } else {
        var span = $("<span>");
        span.addClass("help-error");
        span.html(error);

        $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
    }
}

