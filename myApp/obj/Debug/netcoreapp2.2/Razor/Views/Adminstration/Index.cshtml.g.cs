#pragma checksum "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7639f12bc0adbb1e819429ef2f21c7a313b42a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Adminstration_Index), @"mvc.1.0.view", @"/Views/Adminstration/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Adminstration/Index.cshtml", typeof(AspNetCore.Views_Adminstration_Index))]
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
#line 2 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using myApp.Models;

#line default
#line hidden
#line 3 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using myApp.Models.ViewModels;

#line default
#line hidden
#line 4 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using myApp.Models.Repositry;

#line default
#line hidden
#line 5 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using myApp.Models.Attributes;

#line default
#line hidden
#line 6 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using myApp.Models.Claims;

#line default
#line hidden
#line 7 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 8 "D:\Asp.net Core\myApp\myApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7639f12bc0adbb1e819429ef2f21c7a313b42a6", @"/Views/Adminstration/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d0d12198847256cbba32fb3f031d7148be4acfd", @"/Views/_ViewImports.cshtml")]
    public class Views_Adminstration_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Adminstration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
  
    ViewData["Title"] = "Roles";
    Layout = "~/Views/Shared/_Layout.cshtml";
    bool IsInClaim = (await authorizationService.AuthorizeAsync(User, "CUDRole")).Succeeded;

#line default
#line hidden
            BeginContext(268, 18, true);
            WriteLiteral("\r\n<h1>Roles</h1>\r\n");
            EndContext();
#line 10 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
 if (IsInClaim)
{

#line default
#line hidden
            BeginContext(306, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(310, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7639f12bc0adbb1e819429ef2f21c7a313b42a66501", async() => {
                BeginContext(364, 12, true);
                WriteLiteral("Add New Role");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(380, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 13 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
}

#line default
#line hidden
            BeginContext(385, 157, true);
            WriteLiteral("<table class=\"table\" id=\"tbl\">\r\n    <thead>\r\n        <tr>\r\n            <th>ID</th>\r\n            <th>Name</th>\r\n        <tr></tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 22 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(591, 11, true);
            WriteLiteral("        <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 602, "\"", 615, 1);
#line 24 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
WriteAttributeValue("", 607, item.Id, 607, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(616, 19, true);
            WriteLiteral(">\r\n            <td>");
            EndContext();
            BeginContext(636, 7, false);
#line 25 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
           Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(643, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(667, 9, false);
#line 26 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
           Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(676, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 27 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
             if (IsInClaim)
            {

#line default
#line hidden
            BeginContext(727, 42, true);
            WriteLiteral("                <td>\r\n                    ");
            EndContext();
            BeginContext(769, 352, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7639f12bc0adbb1e819429ef2f21c7a313b42a610045", async() => {
                BeginContext(833, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(859, 78, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7639f12bc0adbb1e819429ef2f21c7a313b42a610452", async() => {
                    BeginContext(929, 4, true);
                    WriteLiteral("Edit");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-RoleID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 31 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
                                                   WriteLiteral(item.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["RoleID"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-RoleID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["RoleID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(937, 177, true);
                WriteLiteral("\r\n                        <button type=\"submit\" onclick=\"return confirm(\'Are You Sure You Want To Delete This Role?\')\" class=\"btn btn-info\">Delete</button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 30 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
                                                WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1121, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 35 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1161, 17, true);
            WriteLiteral("\r\n        </tr>\r\n");
            EndContext();
#line 38 "D:\Asp.net Core\myApp\myApp\Views\Adminstration\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1189, 28, true);
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService authorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
