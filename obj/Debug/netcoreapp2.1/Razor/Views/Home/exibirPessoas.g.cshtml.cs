#pragma checksum "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\exibirPessoas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed2185865e757030be02b4c713cf978d8e09373f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_exibirPessoas), @"mvc.1.0.view", @"/Views/Home/exibirPessoas.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/exibirPessoas.cshtml", typeof(AspNetCore.Views_Home_exibirPessoas))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed2185865e757030be02b4c713cf978d8e09373f", @"/Views/Home/exibirPessoas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"728eef76e2e5f40e6c6eb4d8fc1f92a76516a834", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_exibirPessoas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationCommerce.Models.Pessoa>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\exibirPessoas.cshtml"
  
    foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(101, 49, true);
            WriteLiteral("        <div class=\"pull-left\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 150, "\"", 173, 1);
#line 7 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\exibirPessoas.cshtml"
WriteAttributeValue("", 156, item.CaminhoFoto, 156, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(174, 60, true);
            WriteLiteral(" class=\"img-circle\" alt=\"User Image\">\r\n            <p>Nome: ");
            EndContext();
            BeginContext(235, 9, false);
#line 8 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\exibirPessoas.cshtml"
                Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(244, 22, true);
            WriteLiteral("</p>\r\n        </div>\r\n");
            EndContext();
#line 10 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\exibirPessoas.cshtml"
    }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationCommerce.Models.Pessoa>> Html { get; private set; }
    }
}
#pragma warning restore 1591
