#pragma checksum "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da02b83b7571cb60c79aa0303f76c0b070798b61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funcionario_Pedido), @"mvc.1.0.view", @"/Views/Funcionario/Pedido.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Funcionario/Pedido.cshtml", typeof(AspNetCore.Views_Funcionario_Pedido))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\_ViewImports.cshtml"
using ApplicationCommerce;

#line default
#line hidden
#line 2 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\_ViewImports.cshtml"
using ApplicationCommerce.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da02b83b7571cb60c79aa0303f76c0b070798b61", @"/Views/Funcionario/Pedido.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"728eef76e2e5f40e6c6eb4d8fc1f92a76516a834", @"/Views/_ViewImports.cshtml")]
    public class Views_Funcionario_Pedido : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml"
  
ViewData["Title"] = "Pedido";
Layout = "~/Views/Shared/Funcionario.cshtml";

#line default
#line hidden
            BeginContext(85, 425, true);
            WriteLiteral(@" <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
  <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>

<div id=""fh5co-menus"" data-section=""menu"">
    <div class=""container"">
        <div class=""row text-center fh5co-heading row-padded"">
            <div class=""col-md-6  "">
                <h2 class=""heading to-animate"">Cardápio</h2>
");
            EndContext();
#line 13 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml"
                  
                List<Categoria> categorias = ViewBag.Categorias;
                    foreach (var item in categorias)
                    {

#line default
#line hidden
            BeginContext(673, 41, true);
            WriteLiteral("                    <button type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 714, "\"", 759, 3);
            WriteAttributeValue("", 724, "CarregarProdutos(", 724, 17, true);
#line 17 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml"
WriteAttributeValue("", 741, item.IdCategoria, 741, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 758, ")", 758, 1, true);
            EndWriteAttribute();
            BeginContext(760, 22, true);
            WriteLiteral(" class=\"btn btn-info\">");
            EndContext();
            BeginContext(783, 9, false);
#line 17 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml"
                                                                                                        Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(792, 11, true);
            WriteLiteral("</button>\r\n");
            EndContext();
#line 18 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml"
                    }
                    

#line default
#line hidden
            BeginContext(849, 4243, true);
            WriteLiteral(@"            </div>
        </div>

        <div class=""row row-padded"">
            <div class=""col-md-12"">
                <div class=""fh5co-food-menu to-animate-2"">
                    <!-- <h2 class=""fh5co-dishes"">CATEGORIA</h2> -->
                    <ul id=""produtos"">

                        <!-- <li>
                            <div class=""fh5co-food-desc"">
                                <figure>
                                    <img src=""~/images/imagemProduto/transferir.jpg"" class=""img-responsive"" alt=""Free HTML5 Templates by FREEHTML5.co"">
                                </figure>
                                <div>
                                    <h3>Pineapple Juice</h3>
                                    <p>Far far away, behind the word mountains.</p>
                                </div>
                            </div>
                            <div class=""fh5co-food-pricing"">
                                $17.50
                            </div>
       ");
            WriteLiteral(@"                 </li> -->

                    </ul>
                </div>
            </div>
        </div>
         
            
        

    </div>
</div>






<script>
    function CarregarProdutos(id) {

        var idCategoria = id;
        if (idCategoria != 0) {
            var Barrapesquisa = '<input type=""text"" placeholder=""Procure o produto.."" class=""form-control"" name=""search"">';
            $(""#barraPesquisa"").html(Barrapesquisa);

            $.ajax({
                dataType: ""json"",
                type: ""POST"",
                url: '/Funcionario/CarregarProdutos',
                data: {
                    'Id': idCategoria
                },

                success: function (data) {
                    var exibir = """";
                    var produto = """";
                    var fechar = false;
                    var cont = 0;
                    var con = 0;

                    if (data.length > 0) {
                        $(data).each(f");
            WriteLiteral(@"unction (i) {

                            if (produto != data[i].nome && cont != 0) {
                                exibir += '</div>'
                                exibir += '</div>'
                                exibir += '<div class=""fh5co-food-pricing"">'
                                exibir += 'R$' + data[i - 1].preco + '';
                                exibir += '</div><div class=""fh5co-food-pricing""><a href=""#""><i class=""fa fa-cart-plus fa-2x""></i></a></div>'
                                exibir += '</li>';
                            }
                            if (produto != data[i].nome) {
                                exibir += '<li>'
                                exibir += '<div class=""fh5co-food-desc"">'
                                exibir += '<figure>'
                                exibir += '<img src=""/images/ImagemProduto/transferir.jpg"" class=""img-responsive"" alt=""Free HTML5 Templates by FREEHTML5.co"">'
                                exibir += '</figure>'");
            WriteLiteral(@"
                                exibir += '<div>'
                                exibir += '<h3>' + data[i].nome + '</h3>';

                            }
                            exibir += '<p>' + data[i].ingrediente + '</p>';

                            produto = data[i].nome;
                            cont++;
                            con = i;

                            if (data.length == i + 1) {
                                exibir += '</div>'
                                exibir += '</div>'
                                exibir += '<div class=""fh5co-food-pricing"">'
                                exibir += 'R$' + data[con].preco + '';
                                exibir += '</div><div class=""fh5co-food-pricing""><a href=""#""><i class=""fa fa-cart-plus fa-2x""></i></a></div>'
                                exibir += '</li>';

                            }
                        });
                    }else{
                        exibir = ""<p>Não há produtos</p>""");
            WriteLiteral(";\r\n                    }\r\n\r\n\r\n                    $(\'#produtos\').html(exibir);\r\n                }\r\n            });\r\n        }\r\n    }\r\n</script>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5110, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 133 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Funcionario\Pedido.cshtml"
  await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
