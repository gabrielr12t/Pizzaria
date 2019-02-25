$(function () {
    $('#example1').DataTable()
    $('#example2').DataTable({
        'paging': true,
        'lengthChange': false,
        'searching': false,
        'ordering': true,
        'info': true,
        'autoWidth': false
    })
})




$(function () {
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });


    //Initialize Select2 Elements
    $('.select2').select2()

    //Datemask dd/mm/yyyy
    $('.data').inputmask('__/__/____', {
        'placeholder': 'dd/mm/aaaa'
    })
    $('.cep').inputmask('99999-999', {
        'placeholder': '_____-___'
    })
    $('.cpf').inputmask('999.999.999-99', {
        'placeholder': '___.___.___-__'
    })
    $('.telefone').inputmask('(99) 9999-9999', {
        'placeholder': '(00) 0000-0000'
    });
    $('.celular').inputmask('(99) 9 9999-9999', {
        'placeholder': '(00) 0 0000-0000'
    });

    $('.soNumero').inputmask('00000', {
        'placeholder': '125g'
    });

    //Datemask2 mm/dd/yyyy
    $('#datemask2').inputmask('mm/dd/yyyy', {
        'placeholder': 'mm/dd/yyyy'
    })
    //Money Euro
    $('[data-mask]').inputmask()

    $(".preco").maskMoney({
        prefix: 'R$ ',
        allowNegative: false,
        thousands: '.',
        decimal: ',',
        affixesStay: false
    });

    //Date range picker
    $('#reservation').daterangepicker()
    //Date range picker with time picker
    $('#reservationtime').daterangepicker({
        timePicker: true,
        timePickerIncrement: 30,
        format: 'MM/DD/YYYY h:mm A'
    })
    //Date range as a button
    $('#daterange-btn').daterangepicker({
        ranges: {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        startDate: moment().subtract(29, 'days'),
        endDate: moment()
    },
        function (start, end) {
            $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'))
        }
    )

    //Date picker
    $('#datepicker').datepicker({
        autoclose: true
    })

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    })
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
        checkboxClass: 'icheckbox_minimal-red',
        radioClass: 'iradio_minimal-red'
    })
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    })

    //Colorpicker
    $('.my-colorpicker1').colorpicker()
    //color picker with addon
    $('.my-colorpicker2').colorpicker()

    //Timepicker
    $('.timepicker').timepicker({
        showInputs: false
    })

})


// ===================================================================
// ===================================================================
// ===================================================================// ===================================================================
// ===================================================================
// ===================================================================// ===================================================================
// ===================================================================
// ===================================================================// ===================================================================
// ===================================================================
// ===================================================================// ===================================================================
// ===================================================================
// ===================================================================// ===================================================================
// ===================================================================
// ===================================================================


// ----------------------  CARRINHO PEDIDO ----------------------------------------
//-----------------------  PAGINA PEDIDO   --------------------------------

function CarregarProduto(idCategoria) {
    $.ajax({
        dataType: "json",
        type: "POST",
        url: '/Administrativa/CarregarProdutos',
        data: {
            'Id': idCategoria
        },
        success: function (dados) {
            var prod = "";
            var nome = "";
            var NomeProduto = "";
            var cont = 0;
            var valor = 0;
            var id = 0;
            if (dados.length != 0) {
                $(dados).each(function (i) {
                    if (nome != dados[i].nome && cont != 0) {
                        prod += "<p>Cód " + dados[i - 1].idProduto + "</p>"
                        prod += "</div>"
                        prod += "</div>"
                        prod += "<div class='price'>" + dados[i - 1].preco + "</div>"
                        prod += "<div class='quantity'>"
                        prod += "</div>"
                        prod += "<div class='remove'>"
                        prod += '<button class="btn btn-success" onclick="addCarrinho(' + id + ', ' + dados[valor].preco + ', ' + "\'" + dados[valor].nome + "\'" + ')" >Adicionar <i class="fa fa-plus"></i></button>'
                        prod += "</div>"
                        prod += "</div>";
                    }

                    if (nome != dados[i].nome) {
                        prod += "<div class='basket-product'>"
                        prod += "<div class='item'>"
                        prod += "<div class='product-image'>"
                        prod += "<img src='/images/ImagemProduto/301120184751281.jpg' alt='Placholder Image 2' class='product-frame'>"
                        prod += "</div>"
                        prod += "<div class='product-details'>"
                        prod += "<h3><strong> " + dados[i].nome + "</strong></h3>"
                    }
                    nome = dados[i].nome

                    prod += "<p><strong>" + dados[i].ingrediente + "</strong></p>"
                    cont++;
                    valor = cont - 1;
                    id = dados[i].idProduto;
                    NomeProduto = dados[valor].nome;
                });
                prod += "<p>Cód " + dados[valor].idProduto + "</p>"
                prod += "</div>"
                prod += "</div>"
                prod += "<div class='price'>" + dados[valor].preco + "</div>"
                prod += "<div class='quantity'>"
                prod += "</div>"
                prod += "<div class='remove'>"
                prod += '<button class="btn btn-success" onclick="addCarrinho(' + id + ', ' + dados[valor].preco + ', ' + "\'" + dados[valor].nome + "\'" + ')" >Adicionar <i class="fa fa-plus"></i></button>'
                prod += "</div>"
                prod += "</div>";
                $('#prods').html(prod);
            } else {
                $('#prods').html("");
                $('#prods').html("<h3>Não há produtos nesta categoria</h3>");

            }
        },
        error: function (error) {
            alert('Erro')
        }
    });
}

// = = = = = = = = = = = = =  = == = =  =  = == = 
var produtosVet = new Array();
var total = 0;
var carrinho = "";

function addCarrinho(idProd, valor, nomeProduto) {
    carrinho = "";
    var Id = idProd;
    var Valor = valor;
    var Nome = nomeProduto;

    let index = produtosVet.findIndex(val => val.id == Id);
    if (index < 0) {
        produtosVet.push({ id: Id, nome: Nome, quantidade: 1, valor: parseFloat(Valor) });
    } else {
        $(produtosVet).each(function (i) {
            if (produtosVet[i].id == Id) {
                produtosVet[i].quantidade += 1;
                produtosVet[i].valor = Valor;
            }
        });
    }
    ExibirCarrinho();
}

function ExibirCarrinho() {
    total = 0;
    $(produtosVet).each(function (i) {
        total += produtosVet[i].valor * produtosVet[i].quantidade;
    });
    //exibir Carrinho
    $(produtosVet).each(function (i) {
        carrinho += '<div class="row">'
        carrinho += '<div class="col-md-12">'
        carrinho += '<div class="col-md-5">'
        carrinho += '<strong>' + produtosVet[i].quantidade + ' x ' + produtosVet[i].nome + '</strong>'
        carrinho += '</div>'
        carrinho += '<div class="col-md-4">'
        carrinho += '<p>R$ ' + produtosVet[i].valor + '</p>'
        carrinho += '</div>'
        carrinho += '<div class="col-md-1">'
        carrinho += '<a href="#" data-toggle="tooltip" onclick="RemoverItem(' + produtosVet[i].id + ')" title="Remover do carrinho!"><i style="font-size:23px" class="fa fa-remove "></i></a>'
        carrinho += '</div>'
        carrinho += '<div class="col-md-1">'
        carrinho += '<a href="#" data-toggle="tooltip" onclick="ExcluirItem(' + produtosVet[i].id + ')" title="Excluir do carrinho!"><i style="font-size:23px" class="fa fa-trash "></i></a>'
        carrinho += '</div>'
        carrinho += '</div>'
        carrinho += '</div>';
    })
    $("#basket-total").html(total.toFixed(2));
    $("#itemCarrinho").html(carrinho);
    VerifyEmptyCart();
}


function RemoverItem(idRemover) {
    var id = idRemover;
    let index = produtosVet.findIndex(val => val.id == id);
    if (produtosVet[index].quantidade > 1) {
        produtosVet[index].quantidade -= 1;
    } else {
        produtosVet.splice(index, 1);
    }
    carrinho = "";
    ExibirCarrinho();
    VerifyEmptyCart();
}

function ExcluirItem(idExcluir) {
    var id = idExcluir;
    let index = produtosVet.findIndex(val => val.id == id);
    produtosVet.splice(index, 1);
    carrinho = "";
    ExibirCarrinho();
    VerifyEmptyCart();
}

function ZerarCarrionho() {
    produtosVet = new Array();
    total = 0;
    var carrinho = "";
    $("#itemCarrinho").html(carrinho);
    $("#basket-total").html(total.toFixed(2));
    VerifyEmptyCart();
}

//FINALIZAR PEDIDO
function VerifyEmptyCart() {
    $(document).ready(function () {
        $('.telefone').inputmask('(99) 9999-9999', {
            'placeholder': '(  )     -    '
        });
    });
    //Initialize Select2 Elements
    var html = '';
    if (produtosVet.length > 0) {
        html += '<div class="col-lg-12">'
        html += '<div class="col-lg-12">'
        html += '<label>Telefone: </label>'
        html += '<input class="form-control telefone" id="telefone"><br><div id="MsgTelefone"></div><br>'
        html += '</div><br>'
        html += '<hr><Br>'
        html += '<div class="col-lg-5">'
        html += '<button class="btn btn-success" onclick="Finalizar();" >Concluir</button>'
        html += '</div>'
        html += '</div><br><br>';
    } else {
        html = '<br><div class="col-lg-12"><span class="text-danger pull-right">Adicione item no carrinho para finalizar</span></div>';
    }

    $("#ExibirInput").html(html);
}

function Finalizar() {
    var envio = document.getElementById("IdFormaEnvio").value;
    if (envio == "") {
        $("#selecioneForma").html("<span class='text-danger'>Selecione uma forma de envio</span>");
        return;
    } else {
        $("#selecioneForma").html("");
    }
    var tel = document.getElementById("telefone").value;
    if (tel == "") {
        $("#MsgTelefone").html("<span class='text-danger'>Digite o telefone do cliente</span> ");
        return;
    }
    $(produtosVet).each(function (i) {
        produtosVet[i].valor = produtosVet[i].valor.toString().replace(".", ",");
    });

    $("#MsgTelefone").html("");
    $.ajax({
        dataType: "JSON",
        type: "POST",
        url: '/Administrativa/FinalizarPedido',
        data: {
            'Telefone': tel,
            'Carrinho': produtosVet
            // 'Envio': envio
        },
        success: function (dados) {
            var opts = "";
            if (dados != null) {
                $("#pgPedido").html("");
                opts += '<div id="EscolherEndereco">'
                opts += '<div class="box box-warning">';
                opts += '<div class="box-header with-border">'
                opts += '<h3 class="box-title">Escolha o endereço de entrega</h3>'
                opts += '</div>'
                opts += '<div class="box-body">'
                opts += '<form role="form">'
                opts += '<div class="form-group" id = "opts" >'
                $(dados).each(function (i) {
                    opts += '<div class="radio">'
                    opts += '<label>'
                    opts += '<input type="radio" name="optionsRadios" id="' + dados[i].idEndereco + '" value=""' + dados[i].idEndereco + '"" checked>'
                    opts += '<strong>Rua: </strong> ' + dados[i].rua + ', <strong> Bairro:  </strong>' + dados[i].bairro + ',<strong> Número: </strong>' + dados[i].numero + ', <strong>Cidade: '+dados[i].cidade+'</strong>   '
                    opts += '</label>'
                    opts += '</div> '
                    opts += '</div>  '
                });
                opts += '<div class="summary-delivery">'
                opts += '<select id="IdFormaEnvio" class="form-control" asp-items="ViewBag.FormaEntrega">'
                opts += '<option value="" selected disabled hidden>Forma de envio</option>'
                opts += '</select>'
                opts += '<label id="selecioneForma"></label>'
                opts += '</div>'
                opts += '</form>'
                opts += '</div>'
                opts += '</div>'
                opts += '</div > '
                $("#teste").html(opts);
            } else {
                $(function () {
                    $('#myModal').modal('show');
                });
            }
        }
    });
}

// FIM CARRINHO -------------------------------------------------------------------
// --------------------------------------------------------------------------------
// --------------------------------------------------------------------------------
// --------------------------------------------------------------------------------


// $(".ChamaModal").click(function () {
//     $("#myModal").modal("show");
//     var dados = $(this).attr("rel").split("|");
//     $("#IdE").val(dados[0]);
//     $("#QuantidadeE").val(dados[1]);
//     $("#NomeE").val(dados[2]);
// });

$(".ModalEditarIng").click(function () {
    $("#ModalEditIngrediente").modal("show");
    var dados = $(this).attr("rel").split("|");
    $("#IdE").val(dados[0]);
    $("#QuantidadeE").val(dados[1]);
    $("#NomeE").val(dados[2]);
});


// exibindo produtos pelo secect da dropdown pg: cadastrarProdutos
$('select').change(function () {
    var id = ($(this).val());
    $.ajax({
        dataType: "json",
        type: "POST",
        url: '/Administrativa/RecebeIdProduto',
        data: {
            'Id': id
        },
        success: function (dados) {
            var conteudo = "</br>";
            if (dados.length > 0) {
                conteudo += "<p style='font-size:20px'>" + dados.length + " produtos cadastrados nesta categoria</p></br>";
            }
            $(dados).each(function (i) {
                if (dados[i].foto == null) {
                    conteudo += "<div class='well'><div><form enctype='multipart/form-data' method='POST'><input type='file' onchange='UploadImage(" + dados[i].idProduto + ", id)' name='file-to-upload' id='file-to-upload'></form><strong>" + dados[i].nome + "</strong> - &nbsp Preço: " + dados[i].valorAtual + "</div></div>&nbsp;";
                } else {
                    conteudo += "<div class='well col-lg-12'>&nbsp;<strong>" + dados[i].nome + "</strong> - &nbsp Preço: " + dados[i].valorAtual + "</div>";
                }
            });
            $('#recebe').html(conteudo);
        },
        error: function (error) {
            alert('Erro')
        }
    });
});
// adicionando imagens da tabela de produtos
function UploadImage(idProd, foto) {

    var input = document.getElementById(foto);
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]);
    }


    swal({
        title: "Salvar foto",
        text: "Você quer salvar esta foto para este produto?",
        icon: "success",
        buttons: true,

    })
        .then((salvar) => {
            if (salvar) {
                $.ajax({
                    dataType: "json",
                    type: "POST",
                    url: '/Administrativa/SalvarFoto',
                    data: {
                        'Id': idProd,
                        formData
                    },
                    processData: false,  // tell jQuery not to process the data
                    contentType: false,
                    success: function (data) {
                        swal("Show! Foto salva com sucesso", {
                            icon: "success",
                        });
                    },
                    error: function (error) {
                        swal("Ops! Algo deu errado", {
                            icon: "warning",
                        });
                    }
                });

            } else {
                swal("Sem problemas");
            }
        });
}
// ----------------------------------------------------------------

//validar cadastrarProduto


// checkbox criando inputs e pegando valores inseridos e enviando para o controller pg: cadastrarProdutos
var listCheck = [];
var vetEnviarController = [];
var i = 0;
function funcaoCheckbox(idIng, nomeIng) {
    vetEnviarController = [];
    var conteudo = "";
    let index = listCheck.findIndex(val => val.id == idIng);
    if (index < 0) {
        listCheck.push({ id: idIng, nome: nomeIng });
    } else {
        listCheck.splice(index, 1);
    }

    var entrou = true;
    $(listCheck).each(function (j) {
        if (entrou) {
            conteudo = "<h4>Coloque a quantidade gasta dos ingredientes nesse produto</h4>";
            entrou = false;
        }
        conteudo += " <label>" + listCheck[j].nome + "</label> <input id='ids" + j + "'  onblur='PegarQuantidadeIng(" + listCheck[j].id + ",ids" + j + ")' class='form-control telefone' />";
    });
    $('#ckbInputs').html(conteudo);
}

function PegarQuantidadeIng(id, quantidade) {
    let index = vetEnviarController.findIndex(val => val.idIng == id);

    if (index != -1) {
        vetEnviarController[index] = ({ idIng: id, quantidadeIng: quantidade.value });
    }
    if (id != "" && quantidade.value != "" && index < 0) {
        vetEnviarController.push({ idIng: id, quantidadeIng: quantidade.value });
    }
}

// validando inputs da pg cadastrarProduto
function validar() {
    var categoria = document.getElementById("CategoriaId").value;
    var nome = document.getElementById("Nome").value;
    var ValorProduto = document.getElementById("ValorAtual").value;
    var minutos = document.getElementById("TempoProduzir").value;

    if (categoria != "" && nome != "" && ValorProduto != "" && minutos != null) {
        var produto = new Object();
        produto.Nome = nome;
        produto.CategoriaId = categoria;
        produto.ValorAtual = ValorProduto;
        produto.TempoProduzir = minutos;
        produto.ValorAntigo = 0;
        EnviarController(produto)
    } else {
        if (categoria == "") {
            $('#lblCategoriaId').html("Selecione uma categoria");
        } else {
            $('#lblCategoriaId').html("");
        }

        if (nome == "") {
            $('#lblNome').html("Digite o nome do produto");
        } else {
            $('#lblNome').html("");
        }

        if (ValorProduto == "") {
            $('#lblValorAtual').html("Digite o valor do produto");
        } else {
            $('#lblValorAtual').html("");
        }

        if (minutos == "") {
            $('#lblTempoProduzir').html("Digite o tempo para produção do produto");
        } else {
            $('#lblTempoProduzir').html("");
        }
    }
}


function EnviarController(prodObjeto) {
    $.ajax({
        dataType: "json",
        type: "POST",
        url: '/Administrativa/CadastrarProduto',
        data: {
            'Ingredientes': vetEnviarController,
            'Produto': prodObjeto
            //fdata
        },

        success: function (data) {
            var nome = data.nome;
            swal("Tudo certo!", "" + nome + " cadastrado", "success");
            setTimeout(function () {
                window.location.reload();
            }, 2300);
        },
        error: function (error) {
            alert('Erro')
        }
    });
};
 // -----------------------------------------------------


//pegar valores checkbox

// $(document).ready(function(){
//     $('#checkboxlistIng').click(function () {
//         var text = "";
//         $('#checkboxlistIng: checked').each(function () {
//             text += $(this).val() + ',';
//         });
//         text = text.substring(0, text.length - 1);
//         $("#selectedtext").val(text);
//     });
// });


