#pragma checksum "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Home\OnlinePayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d2dfe127935449c17a0da30279817773a6241ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OnlinePayment), @"mvc.1.0.view", @"/Views/Home/OnlinePayment.cshtml")]
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
#line 1 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\_ViewImports.cshtml"
using ShoppDJ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\_ViewImports.cshtml"
using ShoppDJ.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d2dfe127935449c17a0da30279817773a6241ea", @"/Views/Home/OnlinePayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82549c231a25413c5ba7edd5dc739ac35e79db5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OnlinePayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Home\OnlinePayment.cshtml"
  
    ViewData["Title"] = "OnlinePayment";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>OnlinePayment</h1>\r\n\r\n<h1>کد پیگیری ");
#nullable restore
#line 7 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Home\OnlinePayment.cshtml"
         Write(ViewBag.code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
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
