#pragma checksum "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80b0bd6324cf28623b45daad457e322813de8f66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrativa_Estoque), @"mvc.1.0.view", @"/Views/Administrativa/Estoque.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrativa/Estoque.cshtml", typeof(AspNetCore.Views_Administrativa_Estoque))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80b0bd6324cf28623b45daad457e322813de8f66", @"/Views/Administrativa/Estoque.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"728eef76e2e5f40e6c6eb4d8fc1f92a76516a834", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrativa_Estoque : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
  
    ViewData["Title"] = "Estoque";
    Layout = "~/Views/Shared/Administrativa.cshtml";

#line default
#line hidden
            BeginContext(99, 537, true);
            WriteLiteral(@"

 
    <!-- Content Header (Page header) -->
    <!-- Main content -->
    <section class=""content"">
        <!-- Small boxes (Stat box) -->
        <div class=""row"">
            
            <!-- ./col -->
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-green"">
                    <div class=""inner"">
                        <h3>53<sup style=""font-size: 20px"">%</sup></h3>

                        <p>Bounce Rate</p>
                    </div>
");
            EndContext();
            BeginContext(775, 476, true);
            WriteLiteral(@"                    <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-yellow"">
                    <div class=""inner"">
                        <h3>44</h3>

                        <p>User Registrations</p>
                    </div>
");
            EndContext();
            BeginContext(1399, 470, true);
            WriteLiteral(@"                    <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-xs-6"">
                <!-- small box -->
                <div class=""small-box bg-red"">
                    <div class=""inner"">
                        <h3>65</h3>

                        <p>Unique Visitors</p>
                    </div>
");
            EndContext();
            BeginContext(2000, 201, true);
            WriteLiteral("                    <a href=\"#\" class=\"small-box-footer\">More info <i class=\"fa fa-arrow-circle-right\"></i></a>\r\n                </div>\r\n            </div>\r\n            <!-- ./col -->\r\n        </div>\r\n");
            EndContext();
#line 62 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
          
            if (ViewData["ingredientes"] != null)
            {

#line default
#line hidden
            BeginContext(2279, 973, true);
            WriteLiteral(@"                <div class=""box"">
                    <div class=""box-header"">
                        <h3 class=""box-title"">Todos ingredientes do sistema</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class=""box-body"">
                        <table id=""example1"" class=""table table-bordered  table-hover"">
                            <thead>
                                <tr>
                                    <th>Nome</th>
                                    <th>Quantidade em estoque</th>
                                    <th>Preço do quilo</th>
                                    <th>Data modificação</th>
                                    <th>Quantidade máxima</th>
                                    <th>Pocentagem</th>
                                    <th>Número</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 84 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                 foreach (var item in ViewData["ingredientes"] as List<Ingrediente>)
                                {
                                    double precoKilo;
                                    double quantidade;
                                    double qtdMaxima;
                                    double estoque = 0;

                                    string barra = "";
                                    string cor = "";
                                    precoKilo = (Convert.ToDouble(item.PrecoQuilo));
                                    quantidade = (Convert.ToDouble(item.Quantidade));
                                    qtdMaxima = (Convert.ToDouble(item.QuantidadeMaxima));

                                    if (quantidade > 0)
                                    {
                                        estoque = Math.Round((quantidade / 1000), 2);
                                        precoKilo = Math.Round(((quantidade / 1000) * precoKilo), 2);
                                        quantidade = Math.Round(((Convert.ToDouble(quantidade) / qtdMaxima) * 100), 0);
                                    }
                                    else
                                    {
                                        precoKilo = 0;
                                    }

                                    if (quantidade >= 75)
                                    {
                                        barra = "success";
                                        cor = "green";

                                    }
                                    if (quantidade >= 50 && quantidade < 75)
                                    {
                                        barra = "success";//precisa ser um verde mais fraco
                                        cor = "green";
                                    }
                                    if (quantidade < 50 && quantidade > 25)
                                    {
                                        barra = "warning";
                                        cor = "yellow";
                                    }
                                    if (quantidade <= 25)
                                    {
                                        barra = "danger";
                                        cor = "red";
                                    }

#line default
#line hidden
            BeginContext(5697, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(5784, 9, false);
#line 130 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                       Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(5793, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5845, 15, false);
#line 131 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                       Write(item.Quantidade);

#line default
#line hidden
            EndContext();
            BeginContext(5860, 56, true);
            WriteLiteral(" g</td>\r\n                                        <td>R$ ");
            EndContext();
            BeginContext(5917, 15, false);
#line 132 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                          Write(item.PrecoQuilo);

#line default
#line hidden
            EndContext();
            BeginContext(5932, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(5984, 35, false);
#line 133 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                       Write(item.DataAdicao.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(6019, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(6071, 21, false);
#line 134 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                       Write(item.QuantidadeMaxima);

#line default
#line hidden
            EndContext();
            BeginContext(6092, 187, true);
            WriteLiteral(" g</td>\r\n                                        <td>\r\n                                            <div class=\"progress progress-xs\">\r\n                                                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 6279, "\"", 6319, 3);
            WriteAttributeValue("", 6287, "progress-bar", 6287, 12, true);
            WriteAttributeValue(" ", 6299, "progress-bar-", 6300, 14, true);
#line 137 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
WriteAttributeValue("", 6313, barra, 6313, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("style", " style=\"", 6320, "\"", 6347, 3);
            WriteAttributeValue("", 6328, "width:", 6328, 6, true);
#line 137 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
WriteAttributeValue(" ", 6334, quantidade, 6335, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 6346, "%", 6346, 1, true);
            EndWriteAttribute();
            BeginContext(6348, 157, true);
            WriteLiteral("></div>\r\n                                            </div>\r\n                                        </td>\r\n                                        <td><span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 6505, "\"", 6526, 3);
            WriteAttributeValue("", 6513, "badge", 6513, 5, true);
            WriteAttributeValue(" ", 6518, "bg-", 6519, 4, true);
#line 140 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
WriteAttributeValue("", 6522, cor, 6522, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6527, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(6529, 10, false);
#line 140 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                                                   Write(quantidade);

#line default
#line hidden
            EndContext();
            BeginContext(6539, 60, true);
            WriteLiteral("  %</span></td>\r\n                                    </tr>\r\n");
            EndContext();
#line 142 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
                                }

#line default
#line hidden
            BeginContext(6634, 674, true);
            WriteLiteral(@"

                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Nome</th>
                                    <th>Quantidade</th>
                                    <th>Preço do quilo</th>
                                    <th>Data modificação</th>
                                    <th>Quantidade máxima</th>
                                    <th>Pocentagem</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
");
            EndContext();
#line 160 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(7356, 56, true);
            WriteLiteral("                <p>Não há ingredientes cadastrados</p>\r\n");
            EndContext();
#line 164 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
            }
        

#line default
#line hidden
            BeginContext(7438, 31, true);
            WriteLiteral("        \r\n    </section>\r\n \r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(7487, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 171 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\Estoque.cshtml"
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