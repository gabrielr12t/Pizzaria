#pragma checksum "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f683657a395ffe4878b3d700417dc28019e153d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrativa_CadastrarProduto), @"mvc.1.0.view", @"/Views/Administrativa/CadastrarProduto.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrativa/CadastrarProduto.cshtml", typeof(AspNetCore.Views_Administrativa_CadastrarProduto))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f683657a395ffe4878b3d700417dc28019e153d5", @"/Views/Administrativa/CadastrarProduto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"728eef76e2e5f40e6c6eb4d8fc1f92a76516a834", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrativa_CadastrarProduto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("pegarId();"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("CategoriaId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration:underline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "cadastraringrediente", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
  
ViewData["Title"] = "CadastrarProduto";
Layout = "~/Views/Shared/Administrativa.cshtml";

#line default
#line hidden
            BeginContext(102, 666, true);
            WriteLiteral(@"
 <style>
    .image-upload > input
    {
        display: none;
    }

    .image-upload img
    {
        width: 80px;
        cursor: pointer;
    }
 </style> 


<section id=""content"" class=""content"">
    <!-- Small boxes (Stat box) -->
    <div class=""row"">
        <div class=""col-lg-6"">
            <!-- <form asp-action=""CadastrarProduto"" asp-controller=""Administrativa"" method=""post"" enctype=""multipart/form-data"">  
                <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div> -->

                 <div class=""form-group"">
                    <label class=""control-label"">Categoria</label>
                    ");
            EndContext();
            BeginContext(768, 215, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28f475fbe289492a859797cf22cb8665", async() => {
                BeginContext(866, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(892, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c5e5b72c6264f48b6f058ff5092dc81", async() => {
                    BeginContext(934, 9, true);
                    WriteLiteral("Selecione");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(952, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#line 31 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Categoria;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(983, 1418, true);
            WriteLiteral(@"
                    <span id=""lblCategoriaId"" class=""text-danger""></span>
                </div>

                <div class=""form-group"">
                    <label class=""control-label"">Nome</label>
                    <input id=""Nome""   autofocus placeholder=""Ex: Calabresa"" class=""form-control"" />
                    <span id=""lblNome"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label class=""control-label"">Valor</label>
                    <input id=""ValorAtual""   placeholder=""Ex: 45,90"" class=""form-control preco"" />
                    <span id=""lblValorAtual"" class=""text-danger""></span>
                </div>

                <div class=""form-group"">
                    <label class=""control-label"">Tempo para produzir este produto</label>
                    <input id=""TempoProduzir""   placeholder=""Ex: 10"" class=""form-control"" />
                    <span id=""lblTempoProduzir"" class=""text-danger""></span>
            ");
            WriteLiteral(@"    </div>
                <!-- <div class=""form-group"">
                    <label class=""control-label"">Insira uma foto do produto</label>
                    <input id=""files"" name=""files"" type=""file"" class=""form-control"" />
                    <span id=""lblFoto"" class=""text-danger""></span>
                </div> -->

                <div class=""form-group"">

                    ");
            EndContext();
            BeginContext(2402, 23, false);
#line 61 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2425, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 63 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
                      
                    List<ApplicationCommerce.Models.Ingrediente> ingredientes = ViewBag.Ingredientes;



#line default
#line hidden
            BeginContext(2560, 75, true);
            WriteLiteral("                        <h4>Selecione os ingredientes para este produto ou ");
            EndContext();
            BeginContext(2635, 135, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90e56a32b16d4f66b1f763f4b7e55dbb", async() => {
                BeginContext(2739, 27, true);
                WriteLiteral("Adicionar mais ingredientes");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2770, 13, true);
            WriteLiteral("</h4><br />\r\n");
            EndContext();
#line 69 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
                        int i = 0;
                        //class="flat-red"
                        foreach (var item in ingredientes)
                        {


#line default
#line hidden
            BeginContext(2952, 91, true);
            WriteLiteral("                            <label>\r\n                                <input type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3043, "\"", 3067, 1);
#line 75 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
WriteAttributeValue("", 3048, item.IdIngrediente, 3048, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3068, 28, true);
            WriteLiteral(" name=\"selectedIngredientes\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3096, "\"", 3157, 6);
            WriteAttributeValue("", 3106, "funcaoCheckbox(\'", 3106, 16, true);
#line 75 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
WriteAttributeValue("", 3122, item.IdIngrediente, 3122, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 3141, "\',", 3141, 2, true);
            WriteAttributeValue(" ", 3143, "\'", 3144, 2, true);
#line 75 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
WriteAttributeValue("", 3145, item.Nome, 3145, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 3155, "\')", 3155, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", "\r\n                                    value=\"", 3158, "\"", 3222, 1);
#line 76 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
WriteAttributeValue("", 3203, item.IdIngrediente, 3203, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3223, 43, true);
            WriteLiteral("></input>\r\n                                ");
            EndContext();
            BeginContext(3267, 9, false);
#line 77 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
                           Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(3276, 65, true);
            WriteLiteral("<span>&nbsp;&nbsp;</span>\r\n                            </label>\r\n");
            EndContext();
#line 79 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"

                            i++;
                        }
                    

#line default
#line hidden
            BeginContext(3427, 547, true);
            WriteLiteral(@"
                </div>

                <div class=""form-group"">
                    <label id=""ckbInputs""></label>
                </div>

                <br />
                <div class=""form-group"">
                    <button  onclick=""validar()"" class=""btn btn-success"">Cadastrar</button>
                </div>

          

        </div>

          <div class=""col-lg-6"">            
                <label class=""col-lg-12"" id=""recebe""><label>
            
        </div>                
    </div>
</section>


");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3992, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 108 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Administrativa\CadastrarProduto.cshtml"
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
