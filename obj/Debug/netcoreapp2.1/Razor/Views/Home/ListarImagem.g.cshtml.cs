#pragma checksum "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\ListarImagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd241110c99675c8150ce169a38d96f1aff771d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ListarImagem), @"mvc.1.0.view", @"/Views/Home/ListarImagem.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ListarImagem.cshtml", typeof(AspNetCore.Views_Home_ListarImagem))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd241110c99675c8150ce169a38d96f1aff771d5", @"/Views/Home/ListarImagem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"728eef76e2e5f40e6c6eb4d8fc1f92a76516a834", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ListarImagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationCommerce.Models.Foto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 18, true);
            WriteLiteral("<p>Olá mundo</p>\r\n");
            EndContext();
#line 3 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\ListarImagem.cshtml"
      
        foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(127, 16, true);
            WriteLiteral("            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 143, "\"", 162, 1);
#line 6 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\ListarImagem.cshtml"
WriteAttributeValue("", 149, item.Caminho, 149, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(163, 42, true);
            WriteLiteral(" class=\"img-rounded\" alt=\"Cinque Terre\">\r\n");
            EndContext();
#line 7 "C:\Users\Gabriel\Documents\Projetos\ApplicationCommerce\Views\Home\ListarImagem.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationCommerce.Models.Foto>> Html { get; private set; }
    }
}
#pragma warning restore 1591