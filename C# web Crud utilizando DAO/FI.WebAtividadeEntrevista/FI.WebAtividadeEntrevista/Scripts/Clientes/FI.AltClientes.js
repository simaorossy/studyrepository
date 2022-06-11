
$(document).ready(function () {




    if (obj) {
        $('#formCadastro #CPF').val(obj.CPF);
        $('#formCadastro #Nome').val(obj.Nome);
        $('#formCadastro #CEP').val(obj.CEP);
        $('#formCadastro #Email').val(obj.Email);
        $('#formCadastro #Sobrenome').val(obj.Sobrenome);
        $('#formCadastro #Nacionalidade').val(obj.Nacionalidade);
        $('#formCadastro #Estado').val(obj.Estado);
        $('#formCadastro #Cidade').val(obj.Cidade);
        $('#formCadastro #Logradouro').val(obj.Logradouro);
        $('#formCadastro #Telefone').val(obj.Telefone);

        


    }

    $('#formCadastro').submit(function (e) {
        e.preventDefault();


        var obj = [];

        $("#table_beneficiarios tr").each(function () {

            var idBen = $(this).attr("data-bId");
            var nome = $(this).find(".bNome").text();
            var cpf = $(this).find(".bCPF").text();

            var o = {
                Id: idBen,
                CPF: cpf,
                Nome: nome
            }

            obj.push(o);
        })



        
        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#Nome").val(),
                "CEP": $(this).find("#CEP").val(),
                "CPF": $(this).find("#CPF").val(),
                "Email": $(this).find("#Email").val(),
                "Sobrenome": $(this).find("#Sobrenome").val(),
                "Nacionalidade": $(this).find("#Nacionalidade").val(),
                "Estado": $(this).find("#Estado").val(),
                "Cidade": $(this).find("#Cidade").val(),
                "Logradouro": $(this).find("#Logradouro").val(),
                "Telefone": $(this).find("#Telefone").val(),
                "benModel": obj,
                "ArrIdBeneficiariosExcluir": idDelete
            },
            error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
            success:
            function (r) {
                ModalDialog("Sucesso!", r)
                $("#formCadastro")[0].reset();                                
                window.location.href = urlRetorno;
            }
        });
    })
    
})

//Variaveis da tabela Beneficiarios
var idAlt = 0;
var idDelete = [];

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');

}


//metodo para validar CPF
function ValidaCPF(cpf) {

    cpf = cpf.replace('.', '').replace('.', '').replace('-', '')

    if (cpf.length == 11) {
        var v = [];

        //Calcula o primeiro dígito de verificação.
        v[0] = 1 * cpf[0] + 2 * cpf[1] + 3 * cpf[2];
        v[0] += 4 * cpf[3] + 5 * cpf[4] + 6 * cpf[5];
        v[0] += 7 * cpf[6] + 8 * cpf[7] + 9 * cpf[8];
        v[0] = v[0] % 11;
        v[0] = v[0] % 10;

        //Calcula o segundo dígito de verificação.
        v[1] = 1 * cpf[1] + 2 * cpf[2] + 3 * cpf[3];
        v[1] += 4 * cpf[4] + 5 * cpf[5] + 6 * cpf[6];
        v[1] += 7 * cpf[7] + 8 * cpf[8] + 9 * v[0];
        v[1] = v[1] % 11;
        v[1] = v[1] % 10;


        //Retorna Verdadeiro se os dígitos de verificação são os esperados.
        if ((v[0] != cpf[9]) || (v[1] != cpf[10])) {
            return false
        }
        return true
    }
    else {       
        return false
    }

    //var RegraValida = cpf;
    //var cpfValido = /^(([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11}))$/;
    //if (cpfValido.test(RegraValida) == true) {
    //    return true
    //} else {
    //    return false
    //}
}

//metodo para retornar CPF com mascara
function mCPF(cpf) {
    var cpfMask = cpf
    cpfMask = cpfMask.replace(/\D/g, "")
    cpfMask = cpfMask.replace(/(\d{3})(\d)/, "$1.$2")
    cpfMask = cpfMask.replace(/(\d{3})(\d)/, "$1.$2")
    cpfMask = cpfMask.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    return cpfMask;
}



document.getElementById("CPF").addEventListener("blur", function (event) {
    var cpf = document.getElementById("CPF").value;
    var valido = ValidaCPF(cpf)
    if (valido == true) {
        $('#formCadastro #CPF').css('border', '1px solid green');
    } else {
        $('#formCadastro #CPF').css('border', '1px solid red');
    }
    var maskCPF = mCPF(cpf)
    $('#formCadastro #CPF').val(maskCPF);
}, true);






//MODAL BENEFICIARIOS
$("#btn_beneficiarios").click(function () {
    $("#modal_beneficiarios").modal("show");
})


document.getElementById("modal_beneficiarios_CPF").addEventListener("blur", function (event) {
    var maskcpf = mCPF(document.getElementById("modal_beneficiarios_CPF").value);
    $('#modal_beneficiarios_CPF').val(maskcpf);
}, true);


//Botão incluir
$("#modal_beneficiarios_incluir").click(function () {

    $("#span_alert_bCPF").addClass("d-none")
    $("#span_alert_bCPF").text("")

    var bcpf = $("#modal_beneficiarios_CPF").val();
    var bnome = $("#modal_beneficiarios_nome").val();
    var bCpfValido = ValidaCPF(bcpf);
    var bCpfCheck = CheckHasCPF(bcpf);

    if (bCpfValido == false || bCpfCheck == true) {

        $('#modal_beneficiarios_CPF').css('border', '1px solid red');

        if (bCpfValido == false) {
            $("#span_alert_bCPF").removeClass("d-none")
            $("#span_alert_bCPF").text("CPF inválido")
        }

        if (bCpfCheck == true) {
            $("#span_alert_bCPF").removeClass("d-none")
            $("#span_alert_bCPF").text("CPF ja cadastrado")
        }

    } else {

        $("#span_alert_bCPF").addClass("d-none")
        $("#span_alert_bCPF").text("")

        $('#modal_beneficiarios_CPF').css('border', '1px solid silver');

        var linha = '<tr data-bId="' + idAlt + '">                                                                                                                  ' +
            '           <td class="bCPF" >' + bcpf + '</td>                                                                                                  ' +
            '           <td class="bNome" >' + bnome + '</td>                                                                                                 ' +
            '           <td>                                                                                                               ' +
            '               <button class="btn btn-sm btn-info modal_beneficiarios_alterar" onclick="alterar_beneficiario(this)" style="margin-right:10px;" >Alterar</button>   ' +
            '               <button class="btn btn-sm btn-info modal_beneficiarios_excluir" onclick="excluir_beneficiario(this)" >Excluir</button>                              ' +
            '           </td>                                                                                                              ' +
            '       </tr>                                                                                                                  ';

        $("#table_beneficiarios tbody").append(linha);
        $("#modal_beneficiarios_CPF").val('');
        $("#modal_beneficiarios_nome").val('');

    }

    idAlt = 0;

})


function CheckHasCPF(cpf) {

    var hasCPF = false;

    $("#table_beneficiarios .bCPF").each(function () {
        if (cpf == $(this).text()) {
            hasCPF = true;
        }
    })

    return hasCPF;
}



//botao alterar
function alterar_beneficiario(comp) {

    var idAlterar = $(comp).parent().parent().attr('data-bId');
    var bCPFAlt = $(comp).parent().parent().find('.bCPF').text();
    var bNomeAlt = $(comp).parent().parent().find('.bNome').text();

    console.log("idAlterar= " + idAlterar)

    idAlt = idAlterar;

    $("#modal_beneficiarios_CPF").val(bCPFAlt);
    $("#modal_beneficiarios_nome").val(bNomeAlt);

    $(comp).parent().parent().remove();

}


//botao excluir
function excluir_beneficiario(comp) {

    var idExcluir = $(comp).parent().parent().attr('data-bId');
    $(comp).parent().parent().remove();

    idDelete.push(idExcluir);

    console.log(idDelete);

}
