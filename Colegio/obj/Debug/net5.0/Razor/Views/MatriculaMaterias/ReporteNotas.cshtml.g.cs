#pragma checksum "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "330a2b31d80ca94aab4e9787887f8584783642b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MatriculaMaterias_ReporteNotas), @"mvc.1.0.view", @"/Views/MatriculaMaterias/ReporteNotas.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"330a2b31d80ca94aab4e9787887f8584783642b9", @"/Views/MatriculaMaterias/ReporteNotas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfa1853a8c691f0101d531ab64ace8c4ff951462", @"/Views/_ViewImports.cshtml")]
    public class Views_MatriculaMaterias_ReporteNotas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Colegio.Dtos.ReporteCalificacionesDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Reporte notas</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.Periodo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.IdentificacionAlumno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCompletoAlumno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n         \r\n            <th>\r\n                ");
#nullable restore
#line 23 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.CodigoMateria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreMateria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.IdentificacionProfesor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCompletoProfesor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.Nota));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayNameFor(model => model.Aprueba));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 43 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.Periodo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdentificacionAlumno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreCompletoAlumno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.CodigoMateria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreMateria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdentificacionProfesor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreCompletoProfesor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 68 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nota));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 71 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
           Write(Html.DisplayFor(modelItem => item.Aprueba));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 76 "G:\Proyecto\PruebasTecnicas\Colegio\Colegio\Views\MatriculaMaterias\ReporteNotas.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Colegio.Dtos.ReporteCalificacionesDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
