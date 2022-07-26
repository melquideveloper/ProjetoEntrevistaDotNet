// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Função responsável por fechar a mensagem de alert do CREATE, UPDATE E DELETE de registros
$('.close-alert').click(function () {
    $('.alert').hide('hide');
})


//função responsável por validar o email no cadastrado e edição
$('#emailCadastro').blur( function () {
    var re = /([A-Z0-9a-z_-][^@])+?@[^$#<>?]+?\.[\w]{2,4}/.test(this.value);
    if (!re) {
        $('#error').show();
    } else {
        $('#error').hide();
    }
})