#pragma checksum "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f6391b9e2a5b42b617708012781d071830fed95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Isveren_Index), @"mvc.1.0.view", @"/Views/Isveren/Index.cshtml")]
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
#line 1 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\_ViewImports.cshtml"
using IsciTakipSistemi.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\_ViewImports.cshtml"
using IsciTakipSistemi.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f6391b9e2a5b42b617708012781d071830fed95", @"/Views/Isveren/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8e498a870c4e08559b9d7c1f855ed5a5b91fe2e", @"/Views/_ViewImports.cshtml")]
    public class Views_Isveren_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ITS.CORE.Dto.CreateIsverenDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Isveren", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IsverenDetay", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
  
	ViewData["Title"] = "Index";
	Layout = "~/Views/Shared/View.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""table-wrapper"">
	<div class=""table-title"">
		<div class=""row"">
			<div class=""col-sm-12 "">

				<h4 style=""padding:1rem;color:white; font-size: 1.5rem; float: left;"">İşveren İşlemleri</h4>

			</div>

		</div>
	</div>
	<div class=""table-responsive"">
		<table class=""table table-striped"">
			<thead>
				<tr>

					<th scope=""col"">İşveren Adı</th>
					<th scope=""col"">İşveren Soyadı</th>
					<th scope=""col"">
						İşvren Detay
					</th>
					
				</tr>
			</thead>
			<tbody>
");
#nullable restore
#line 32 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
                 foreach (var i in Model)
				{



#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<tr>\r\n\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 38 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
                       Write(i.IsverenAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td>");
#nullable restore
#line 39 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
                       Write(i.IsverenSoyadi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f6391b9e2a5b42b617708012781d071830fed955446", async() => {
                WriteLiteral("<i class=\'bx bx-calendar\' style=\'color:rgba(30,194,210,0.99);font-size: 1.7rem \'></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-isverenadi", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
                                                                                            WriteLiteral(i.IsverenAdi);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isverenadi"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-isverenadi", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isverenadi"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
                                                                                                                                    WriteLiteral(i.IsverenSoyadi);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isverensoyadi"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-isverensoyadi", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isverensoyadi"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 46 "C:\Users\hüseyin\source\repos\IsciTakipSistemi\IsciTakipSistemi.UI\Views\Isveren\Index.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tbody>\r\n\t\t</table>\r\n\t</div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ITS.CORE.Dto.CreateIsverenDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
