#pragma checksum "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "124661db79b735ca4b98e69708f83197b721d637"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProfesorAsignaturas_Index), @"mvc.1.0.view", @"/Views/ProfesorAsignaturas/Index.cshtml")]
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
#nullable restore
#line 1 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\_ViewImports.cshtml"
using Colegio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\_ViewImports.cshtml"
using Colegio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"124661db79b735ca4b98e69708f83197b721d637", @"/Views/ProfesorAsignaturas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfa1853a8c691f0101d531ab64ace8c4ff951462", @"/Views/_ViewImports.cshtml")]
    public class Views_ProfesorAsignaturas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Colegio.Dtos.ProfesorAsignaturaDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
Write(ViewData["vwProfesorNombreFull"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>\r\n\r\n    ");
#nullable restore
#line 11 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
Write(Html.ActionLink("",
 "Create",
 "ProfesorAsignaturas",
 new { ProfesorId = @ViewData["vwProfesorId"] },
 new { @class = "btn btn-primary fas fa-plus-circle" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Materia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Materia.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 35 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
           Write(Html.ActionLink(" ",
                  "Edit",
                  "ProfesorAsignaturas",
                  new
                  {
                      id = item.Id,
                      ProfesorId = item.ProfesorId
                  },
                  new { @class = "btn btn-primary fas fa-edit btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                ");
#nullable restore
#line 46 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
           Write(Html.ActionLink(" ",
                  "Delete",
                  "ProfesorAsignaturas",
                  new
                  {
                      id = item.Id,
                      ProfesorId = item.ProfesorId
                  },
                 new { @class = "btn btn-primary fas fa-trash btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 58 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\ProfesorAsignaturas\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Colegio.Dtos.ProfesorAsignaturaDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591