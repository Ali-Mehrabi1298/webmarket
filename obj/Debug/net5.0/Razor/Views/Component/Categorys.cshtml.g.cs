#pragma checksum "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Component\Categorys.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aef4a41fd0469cd0261888df2173604f2a2e10f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Component_Categorys), @"mvc.1.0.view", @"/Views/Component/Categorys.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aef4a41fd0469cd0261888df2173604f2a2e10f0", @"/Views/Component/Categorys.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82549c231a25413c5ba7edd5dc739ac35e79db5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Component_Categorys : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShowGroupCategory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n    \r\n\r\n   \r\n<ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 9 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Component\Categorys.cshtml"
     foreach (var item in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item\"><a");
            BeginWriteAttribute("href", " href=\"", 167, "\"", 205, 4);
            WriteAttributeValue("", 174, "/Group/", 174, 7, true);
#nullable restore
#line 12 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Component\Categorys.cshtml"
WriteAttributeValue("", 181, item.GroupId, 181, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 194, "/", 194, 1, true);
#nullable restore
#line 12 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Component\Categorys.cshtml"
WriteAttributeValue("", 195, item.Name, 195, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 12 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Component\Categorys.cshtml"
                                                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 13 "G:\Users\ALimehrabi\source\repos\ShoppDJ\ShoppDJ\Views\Component\Categorys.cshtml"
   
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</ul>\r\n  \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShowGroupCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
