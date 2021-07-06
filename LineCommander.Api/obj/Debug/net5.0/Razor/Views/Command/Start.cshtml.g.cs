#pragma checksum "C:\Users\jackc\Documents\GitHub\LineCommanderWeb\LineCommander.Api\Views\Command\Start.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c5df8c1e95c794c4f3747be71e7eeef0746dc5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Command_Start), @"mvc.1.0.view", @"/Views/Command/Start.cshtml")]
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
#line 1 "C:\Users\jackc\Documents\GitHub\LineCommanderWeb\LineCommander.Api\Views\_ViewImports.cshtml"
using LineCommander.Api;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jackc\Documents\GitHub\LineCommanderWeb\LineCommander.Api\Views\_ViewImports.cshtml"
using LineCommander.Api.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c5df8c1e95c794c4f3747be71e7eeef0746dc5d", @"/Views/Command/Start.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"350d4be57688aaa291e317c9a04a48191df6c5f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Command_Start : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StartCommandModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jackc\Documents\GitHub\LineCommanderWeb\LineCommander.Api\Views\Command\Start.cshtml"
  
    ViewData["Title"] = "CMD";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c5df8c1e95c794c4f3747be71e7eeef0746dc5d3357", async() => {
                WriteLiteral("\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""text-center form-floating"">
    <h1 class=""display-4"">What do you need?</h1>
    <div>
        <textarea id=""commandOutput"" disabled style=""width:70vw;height:40vh;white-space: pre-wrap;"">
        </textarea>
    </div>
    <div>
        <input style=""width:65vw"" id=""commandInput"" type=""text"" name=""command""");
            BeginWriteAttribute("value", " value=\"", 506, "\"", 514, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
        <button id=""sendCommandButton"" style=""width:5vw"">></button>
    </div>
</div>

<script>
    $('#commandInput').focus();
    const sendCommand = () => {
        const output = $('#commandOutput');
        const input = $('#commandInput').val();
        const sessionId = '");
#nullable restore
#line 27 "C:\Users\jackc\Documents\GitHub\LineCommanderWeb\LineCommander.Api\Views\Command\Start.cshtml"
                      Write(Model.SessionId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        output.append('\r\n------>' + input);
        $('#commandInput').val('');

        $.get(""/command/send?sessionId="" + sessionId + ""&command="" + input, function(response) {
            
            response.messages.forEach(message => {
                output.append('\r\n' + message);
            });

            // IDK why I have to do it this way, whatever.
            const outy = document.getElementById('commandOutput')
            outy.scrollTop = outy.scrollHeight;
        });
    };

    $('#commandInput').keypress(function(event){
        if(event.keyCode == 13){
            sendCommand();
        }
    });

    $(""#sendCommandButton"").click(sendCommand);

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StartCommandModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
