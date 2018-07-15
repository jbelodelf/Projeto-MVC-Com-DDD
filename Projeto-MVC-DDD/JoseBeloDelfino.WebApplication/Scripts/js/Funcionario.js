"use script";
var Funcionario = {
    Listar: function () {
        var nome = $("#NomePesquisar").val();

        var div = $("#ListarFuncionarios");
        div.empty();

        var token = localStorage.getItem('jtoken');
        var url = "/Funcionario/ListarFuncionarios";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { Nome: nome, Token: token }
            , cache: false
        }).done(function (data) {
            if (data == "Unauthorized") {
                localStorage.removeItem('jtoken');
                window.location.href = "/Login/Login";
            }

            div.html(data);

         }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception)
        });
    },

    NovoFuncionario: function () {
        var token = localStorage.getItem('jtoken');
        var id = $("#IdFuncionario").val()
        window.location.href = "/Funcionario/Create?Token=" + token + "&Id=" + id;
    },

    Deletar: function (id) {
        bootbox.confirm({
            message: 'Deseja realmente excluir este registro?',
            buttons: {
                confirm: {
                    label: 'sim',
                    className: 'btn btn-primary botao-confirmar-sim',
                },
                cancel: {
                    label: 'não',
                    className: 'btn btn btn-danger botao-confirmar-nao',
                }
            },
            callback: function (result) {
                if (!result) {
                    return;
                }

                var token = localStorage.getItem('jtoken');
                var url = "/Funcionario/Delete";
                $.ajax({
                    url: url
                    , datatype: "json"
                    , type: "GET"
                    , async: false
                    , data: { Id: id, Token: token }
                    , cache: false
                }).done(function (data) {
                    if (data.retorno == "Unauthorized") {
                        localStorage.removeItem('jtoken');
                        window.location.href = "/Login/Login";
                    }
                    else {
                        window.location.href = "/Funcionario/Index";
                    }

                }).fail(function (jqXHR, exception) {
                    TratamentoDeErro(jqXHR, exception)
                });
            }
        })
    },

    Editar: function (id) {
        var token = localStorage.getItem('jtoken');
        window.location.href = "/Funcionario/Edit?Id=" + id + "&token=" + token;
    },

    SalvarFuncionario: function () {
        Funcionario.Validar();
        var isValid = $("#frmFuncionario").valid();
        if (!isValid) { return }

        bootbox.confirm({
            message: 'Deseja gravar os dados?',
            buttons: {
                confirm: {
                    label: 'sim',
                    className: 'btn btn-primary botao-confirmar-sim',
                },
                cancel: {
                    label: 'não',
                    className: 'btn btn btn-danger botao-confirmar-nao',
                }
            },
            callback: function (result) {
                if (!result) {
                    return;
                }
                var funcionarioViewModel = {
                    Nome: $("#Nome").val()
                    , Cpf: $("#Cpf").val()
                    , Rg: $("#Rg").val()
                    , Endereco: $("#Endereco").val()
                    , Cep: $("#Cep").val()
                    , Cidade: $("#Cidade").val()
                    , Estado: $("#Estado").val()
                    , Pais: $("#Pais").val()
                    , IdSupervisor: $("#IdSupervisor").val()
                    , IdDepartamento: $("#IdDepartamento").val()
                    , IdCargo: $("#IdCargo").val()
                    , IdFuncionario: $("#IdFuncionario").val()
                }

                var token = localStorage.getItem('jtoken');
                var url = "/Funcionario/Salvar";
                $.ajax({
                    url: url
                    , datatype: "json"
                    , type: "POST"
                    , async: false
                    , data: { funcionario: funcionarioViewModel, Token: token }
                    , cache: false
                }).done(function (data) {
                    if (data.retorno == "Unauthorized") {
                        localStorage.removeItem('jtoken');
                        window.location.href = "/Login/Login";
                    }
                    else {
                        window.location.href = "/Funcionario/Index";
                    }

                }).fail(function (jqXHR, exception) {
                    TratamentoDeErro(jqXHR, exception)
                });
            }
        });
    },

    VoltarFuncionario: function () {
        window.location.href = "/Funcionario/Index";
    },

    Validar: function () {
        var validator = $("#frmFuncionario").validate();
        validator.destroy();

        $("#frmFuncionario").validate({
           ignore: [],
           rules: {
                Nome: {
                    required: true,
                },
                Cpf: {
                    required: true,
                },
                Rg: {
                    required: true,
                },
                Endereco: {
                    required: true,
                },
                Cep: {
                    required: true,
                },
                Cidade: {
                    required: true,
                },
                Estado: {
                    required: true,
                },
                Pais: {
                    required: true,
                },
                ComboCargo: {
                   required: true,
                },
                ComboDepartamento: {
                   required: true,
                },
                ComboSupervisor: {
                   required: true,
                }
            },
            messages: {
                Nome: {
                    required: "Nome é obrigatória!!!",
                },
                Cpf: {
                    required: "CPF é obrigatória!!!",
                },
                Rg: {
                    required: "RG é obrigatória!!!",
                },
                Endereco: {
                    required: "Endereço é obrigatória!!!",
                },
                Cep: {
                    required: "CEP é obrigatória!!!",
                },
                Cidade: {
                    required: "Cidade é obrigatória!!!",
                },
                Estado: {
                    required: "Estado é obrigatória!!!",
                },
                Pais: {
                    required: "País é obrigatória!!!",
                },
                ComboCargo: {
                    required: "Cargo é obrigatória!!!",
                },
                ComboDepartamento: {
                    required: "Departamento é obrigatória!!!",
                },
                ComboSupervisor: {
                    required: "Supervisor é obrigatória!!!",
                }

            }
        });
    }
}

$(document).ready(function () {
    $("#btPesquisar").on("click", function () {
        Funcionario.Listar();
    });

    $("#btNovo").on("click", function () {
        Funcionario.NovoFuncionario();
    });

    $("#btSalvar").on("click", function () {
        Funcionario.SalvarFuncionario();
    });

    $("#btPesquisar").trigger("click");
})
