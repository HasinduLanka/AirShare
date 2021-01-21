#pragma checksum "D:\My Projects\C# Git\AirShare\AirShare\Pages\OpenHLnk.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3a97f0af1865308ef4146c050c1e5d4d03f695c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AirShare.Pages.Pages_OpenHLnk), @"mvc.1.0.razor-page", @"/Pages/OpenHLnk.cshtml")]
namespace AirShare.Pages
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
#line 3 "D:\My Projects\C# Git\AirShare\AirShare\Pages\OpenHLnk.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\My Projects\C# Git\AirShare\AirShare\Pages\OpenHLnk.cshtml"
using System.IO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/hlnk/{PFileName}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3a97f0af1865308ef4146c050c1e5d4d03f695c", @"/Pages/OpenHLnk.cshtml")]
    public class Pages_OpenHLnk : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "D:\My Projects\C# Git\AirShare\AirShare\Pages\OpenHLnk.cshtml"
  
    //[Parameter] string PFileName ;

    string H = Uri.UnescapeDataString(HttpContext.Request.QueryString.Value.TrimStart('?')).Trim('"');
    HashLink HL = HashLinks.GetLink(H);

    if (HL == null)
    {
        HttpContext.Response.Clear();
        HttpContext.Response.StatusCode = 404;
        return;
    }



    if (HL.Type == HashLink.HashLinkType.File)
    {

        string url = HL.Data;

        Console.WriteLine("Hash Link Downloading " + url);
        FileInfo file = new FileInfo(url);

        HttpContext.Response.Clear();
        HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + file.Name);
        HttpContext.Response.Headers.Add("Content-Length", (file.Length + 2).ToString());
        HttpContext.Response.ContentType = "application/octet-stream";
        await HttpContext.Response.SendFileAsync(new Microsoft.Extensions.FileProviders.Physical.PhysicalFileInfo(file));

    }
    else if (HL.Type == HashLink.HashLinkType.HashedDirectory)
    {
        HashedDirectory HD = Core.FromJSON<HashedDirectory>(HL.Data);

        Console.WriteLine("Hashed Directory Downloading " + HD.BasePath);

        string Name = System.IO.Path.GetFileName(HD.BasePath);



        HttpContext.Response.Clear();
        HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + Name + HD.GetExtention());
        HttpContext.Response.ContentType = "application/octet-stream";
        // foreach (string s in HD.Enumerate())
        //{
        // await HttpContext.Response.WriteAsync(s);
        //}
        await HttpContext.Response.WriteAsync(HD.GenerateString());

    }




#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Components.NavigationManager NavMan { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_OpenHLnk> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_OpenHLnk> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_OpenHLnk>)PageContext?.ViewData;
        public Pages_OpenHLnk Model => ViewData.Model;
    }
}
#pragma warning restore 1591