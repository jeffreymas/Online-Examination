#pragma checksum "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f38b3fa722ffbd455ff2ffc53c75e259ace80cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Profile.cshtml", typeof(AspNetCore.Views_Account_Profile))]
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
#line 1 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\_ViewImports.cshtml"
using ExamOnlineClient;

#line default
#line hidden
#line 2 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\_ViewImports.cshtml"
using ExamOnlineClient.Models;

#line default
#line hidden
#line 1 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Account\Profile.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f38b3fa722ffbd455ff2ffc53c75e259ace80cd", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4278384e0eb77a721edc8fa7b67c71ee04e00835", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/html/dist/assets/img/admin-avatar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
            BeginContext(125, 492, true);
            WriteLiteral(@"
<div class=""page-wrapper"">
    <!-- START HEADER-->
    <!-- END SIDEBAR-->
    <div class=""content-wrapper"">
        <div class=""page-content fade-in-up"">
            <div class=""row"">
                <div class=""col-lg-12 col-md-4"">
                    <div class=""ibox"">
                        <div class=""ibox-body text-center"">
                            <h1 class=""admin-info"">Welcome</h1>
                            <div class=""m-t-20"">
                                ");
            EndContext();
            BeginContext(617, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "057286df881c4633a5a8835cb7cb78a9", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(689, 104, true);
            WriteLiteral("\r\n                            </div>\r\n                            <h5 class=\"font-strong m-b-10 m-t-10\">");
            EndContext();
            BeginContext(794, 33, false);
#line 20 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Account\Profile.cshtml"
                                                             Write(Context.Session.GetString("name"));

#line default
#line hidden
            EndContext();
            BeginContext(827, 68, true);
            WriteLiteral("</h5>\r\n\r\n                            <div class=\"m-b-20 text-muted\">");
            EndContext();
            BeginContext(896, 33, false);
#line 22 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Account\Profile.cshtml"
                                                      Write(Context.Session.GetString("role"));

#line default
#line hidden
            EndContext();
            BeginContext(929, 184, true);
            WriteLiteral("</div>\r\n                            \r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
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
