#pragma checksum "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7258d30d4a01c5c1d24f922ab8fc1919f94a0bbe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Index), @"mvc.1.0.view", @"/Views/Invoice/Index.cshtml")]
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
#line 1 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\_ViewImports.cshtml"
using Likvido.Invoice.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\_ViewImports.cshtml"
using Likvido.Invoice.App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7258d30d4a01c5c1d24f922ab8fc1919f94a0bbe", @"/Views/Invoice/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb50da5548fa1e3fc913bce08d5d3cb6e948619e", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceListRootViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table table-striped"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Created Date</th>
            <th scope=""col"">Currency</th>
            <th scope=""col"">Net Amount</th>
            <th scope=""col"">Gross Amount</th>
            <th scope=""col"">Vat Amount</th>
            <th scope=""col"">Comments</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 16 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
         for (int i = 0; i < Model.Data.Count; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 19 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
                            Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
               Write(Model.Data[i].Attributes.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
               Write(Model.Data[i].Attributes.Currency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
               Write(Model.Data[i].Attributes.NetAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
               Write(Model.Data[i].Attributes.GrossAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
               Write(Model.Data[i].Attributes.VatAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
               Write(Model.Data[i].Attributes.InvoiceComments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\Onur\source\repos\Likvido\Likvido.Invoice.App\Views\Invoice\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceListRootViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591