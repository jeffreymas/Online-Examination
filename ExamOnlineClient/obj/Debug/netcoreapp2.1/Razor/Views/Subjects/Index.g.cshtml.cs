#pragma checksum "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Subjects\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7caa07f54500db4425c2e357932270445814199a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subjects_Index), @"mvc.1.0.view", @"/Views/Subjects/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Subjects/Index.cshtml", typeof(AspNetCore.Views_Subjects_Index))]
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
#line 1 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Subjects\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7caa07f54500db4425c2e357932270445814199a", @"/Views/Subjects/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4278384e0eb77a721edc8fa7b67c71ee04e00835", @"/Views/_ViewImports.cshtml")]
    public class Views_Subjects_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Script/SubjectScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Subjects\Index.cshtml"
  
    var name = Context.Session.GetString("uname");
    var role = Context.Session.GetString("role");


#line default
#line hidden
#line 7 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Subjects\Index.cshtml"
  
    ViewData["Title"] = "Subjects";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
            BeginContext(238, 698, true);
            WriteLiteral(@"
<div class=""content-wrapper"">
    <!-- START PAGE CONTENT-->
    <!-- Modal -->
    <div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header no-bd"">
                    <h5 class=""modal-title""><span class=""fw-mediumbold"">Subject List</span></h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>

                <div class=""modal-body"">
                    ");
            EndContext();
            BeginContext(936, 593, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73cf74779cf541318880337338a5a5d0", async() => {
                BeginContext(942, 580, true);
                WriteLiteral(@"
                        <div class=""row"">
                            <input type=""text"" id=""Id"" name=""Id"" class=""form-control"" hidden>
                            <div class=""col-sm-12"">
                                <div class=""form-group form-group-default"">
                                    <label>Subject</label>
                                    <input type=""text"" id=""Name"" name=""Name"" class=""form-control"" placeholder=""Subject"">
                                </div>
                            </div>
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1529, 804, true);
            WriteLiteral(@"
                </div>
                <div class=""modal-footer no-bd"">
                    <button type=""button"" id=""add"" class=""btn btn-outline-success"" data-dismiss=""modal"" onclick=""Save();"">Insert</button>
                    <button type=""button"" id=""update"" class=""btn btn-outline-warning"" data-dismiss=""modal"" onclick=""Update();"">Update</button>
                    <button type=""button"" class=""btn btn-outline-danger"" data-dismiss=""modal"">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div class=""page-heading"">
        <h1 class=""page-title"">Subject List</h1>
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item"">
                <a href=""/""><i class=""la la-home font-20""></i></a>
            </li>
        </ol>
");
            EndContext();
#line 55 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Subjects\Index.cshtml"
         if (role == "Admin")
        {

#line default
#line hidden
            BeginContext(2375, 331, true);
            WriteLiteral(@"            <div data-toggle=""modal"" data-target=""#myModal"" onclick=""ClearScreen();"">
                <button class=""btn btn-outline-success btn-circle"" data-toggle=""tooltip"" data-placement=""right"" data-animation=""false"" title=""Add"">
                    <i class=""fa fa-plus""></i>
                </button>
            </div>
");
            EndContext();
#line 62 "C:\Users\Jepri\Documents\GitHub\Kelompok1_Exam-Online_Rio_Aldy_Jepri\Kelompok1_Exam-Online_Rio_Aldy_Jepri\ExamOnlineClient\Views\Subjects\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2717, 85, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"page-content fade-in-up\">\r\n        <div class=\"ibox\">\r\n");
            EndContext();
            BeginContext(2925, 564, true);
            WriteLiteral(@"            <div class=""ibox-body"">
                    <table class=""table table-striped table-bordered table-hover"" id=""TblSubject"" cellspacing=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>Subject</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                    </table>
            </div>
        </div>
    </div>
    <!-- END PAGE CONTENT-->
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3506, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3512, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebfd7845c7784cb2adcc7a7e93146356", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3564, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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