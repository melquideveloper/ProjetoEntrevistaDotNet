// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Função para ativação da DATATABLE que já esta traduzido.
$(document).ready(function () {
    LoadDataTable('#TableCliente');
    LoadDataTable('#TableUsuario');
    //linhas responsável por validação de email
    validaEmail('#emailCliente','#btnCadCliente');
    validaEmail('#emailUsuario', '#btnCadUser');
})

//
function LoadDataTable(id) {
    $(id).DataTable({
        "ordering": true, //ativar e desativa ordenação
        "paging": true,  //ativar e desativa paginação
        "searching": true,//ativar e desativa procura
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

//Função responsável por fechar a mensagem de alert do CREATE, UPDATE E DELETE de registros
$('.close-alert').click(function () {
    $('.alert').hide('hide');
})

/*$('.alert').show(function () {

    $('.alert').slideUp(3000).delay(900); 

});*/

//função responsável por validar o email no cadastrado
function validaEmail(id, btn) {
    $(id).blur(function () {
        var re = /([A-Z0-9a-z_-][^@])+?@[^$#<>?]+?\.com/.test(this.value);
        if (!re) {
            $('#errorEmail').show();
            $(btn).prop("disabled", true);
        } else {
            $('#errorEmail').hide();
            $(btn).prop("disabled", false);
        }
    })
}

