#pragma checksum "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba773ec42e99e95e1480e9c1142781737d143452"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\_ViewImports.cshtml"
using Core_To_Do;

#line default
#line hidden
#line 5 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
using Core_To_Do.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba773ec42e99e95e1480e9c1142781737d143452", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4b679e9a8adcd33cce4158127fb447d246c9a41", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ToDoItemModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(99, 218, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Your to do list!</h1>\r\n    \r\n    <div>Click to mark your item complete.</div>\r\n\r\n    <div id=\"app\">\r\n        <div class=\"to-do-list\" data-server-rendered=\"true\">\r\n");
            EndContext();
#line 14 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
             foreach (ToDoItemModel i in Model)
            {

#line default
#line hidden
            BeginContext(381, 54, true);
            WriteLiteral("                <div class=\"to-do-item\" data-item-id=\"");
            EndContext();
            BeginContext(437, 4, false);
#line 16 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
                                                  Write(i.id);

#line default
#line hidden
            EndContext();
            BeginContext(442, 18, true);
            WriteLiteral("\" data-completed=\"");
            EndContext();
            BeginContext(462, 32, false);
#line 16 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
                                                                           Write(i.completed.ToString().ToLower());

#line default
#line hidden
            EndContext();
            BeginContext(495, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(499, 7, false);
#line 16 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
                                                                                                                Write(i.label);

#line default
#line hidden
            EndContext();
            BeginContext(507, 48, true);
            WriteLiteral("<button class=\"delete-button\">X</button></div>\r\n");
            EndContext();
#line 17 "C:\Users\Alfe\source\repos\Core-To-Do\Core-To-Do\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(570, 209, true);
            WriteLiteral("        </div>\r\n        <div class=\"to-do-list_new-task-area\">\r\n            Task\r\n            <input id=\"new-task-input\" type=\"text\" />\r\n        </div>\r\n        <button>Save Item</button>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ToDoItemModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591