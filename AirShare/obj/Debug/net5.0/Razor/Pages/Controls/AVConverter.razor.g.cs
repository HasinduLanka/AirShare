#pragma checksum "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "839393ec8aace8a5c8e3687c328218fd0c39ab9c"
// <auto-generated/>
#pragma warning disable 1591
namespace AirShare.Pages.Controls
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using AirShare.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using AirShare.Pages.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\My Projects\C# Git\AirShare\AirShare\_Imports.razor"
using Xabe.FFmpeg;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
using AirShare;

#line default
#line hidden
#nullable disable
    public partial class AVConverter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "height-card box-margin");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "card");
            __builder.OpenElement(4, "video");
            __builder.AddAttribute(5, "class", "card-img-top");
            __builder.AddAttribute(6, "src", 
#nullable restore
#line 22 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                           $"{NavMan.BaseUri}OpenVideoStream/{Uri.EscapeDataString(FileEntry.Name)}?" + Uri.EscapeDataString(System.IO.Path.Combine(Path, FileEntry.Name))

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(7, "controls");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n\r\n        ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "card-body text-center");
            __builder.OpenElement(11, "h5");
            __builder.AddAttribute(12, "class", "mt-20");
            __builder.OpenElement(13, "a");
            __builder.AddAttribute(14, "class", "text-dark");
            __builder.AddContent(15, 
#nullable restore
#line 26 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                      FileEntry.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n\r\n            ");
            __builder.AddMarkupContent(17, "<p class=\"card-text\">Select Type And Quality To Convert Video...</p>");
#nullable restore
#line 30 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
             if (info == null)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(18, "p");
            __builder.AddAttribute(19, "class", "card-text");
            __builder.OpenElement(20, "button");
            __builder.AddAttribute(21, "class", "btn btn-sm btn-primary");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                                     GetInfo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(23, "Get Info");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 35 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "table-responsive");
            __builder.OpenElement(26, "table");
            __builder.AddAttribute(27, "class", "file-ex table-borderless table-nowrap");
            __builder.OpenElement(28, "thead");
            __builder.OpenElement(29, "tr");
            __builder.AddMarkupContent(30, "<th>Size</th>\r\n                                ");
            __builder.OpenElement(31, "th");
            __builder.AddContent(32, 
#nullable restore
#line 43 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                     Core.GetSizeString(info.Size)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                            ");
            __builder.OpenElement(34, "tr");
            __builder.AddMarkupContent(35, "<th>Duration</th>\r\n                                ");
            __builder.OpenElement(36, "th");
            __builder.AddContent(37, 
#nullable restore
#line 47 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                     info.Duration

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n                            ");
            __builder.OpenElement(39, "tr");
            __builder.AddMarkupContent(40, "<th>Codec</th>\r\n                                ");
            __builder.OpenElement(41, "th");
            __builder.AddContent(42, 
#nullable restore
#line 51 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                     info.VideoStreams?.FirstOrDefault().Codec

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n                            ");
            __builder.OpenElement(44, "tr");
            __builder.AddMarkupContent(45, "<th>Framerate</th>\r\n                                ");
            __builder.OpenElement(46, "th");
            __builder.AddContent(47, 
#nullable restore
#line 55 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                     info.VideoStreams?.FirstOrDefault().Framerate

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(48, " FPS");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n                            ");
            __builder.OpenElement(50, "tr");
            __builder.AddMarkupContent(51, "<th>Bitrate</th>\r\n                                ");
            __builder.OpenElement(52, "th");
            __builder.AddContent(53, 
#nullable restore
#line 59 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                     info.VideoStreams?.FirstOrDefault().Bitrate

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(54, " bits");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n                            ");
            __builder.OpenElement(56, "tr");
            __builder.AddMarkupContent(57, "<th>StreamType</th>\r\n                                ");
            __builder.OpenElement(58, "th");
            __builder.AddContent(59, 
#nullable restore
#line 63 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                     info.VideoStreams?.FirstOrDefault().StreamType

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 68 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(60, "<hr>\r\n\r\n            ");
            __builder.OpenElement(61, "div");
            __builder.AddAttribute(62, "class", "form-row");
            __builder.OpenElement(63, "div");
            __builder.AddAttribute(64, "class", "form-group" + " col-md-" + (
#nullable restore
#line 72 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                SelType == "Video"?"6":"12"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(65, "<label>Type</label>\r\n                    ");
            __builder.OpenElement(66, "select");
            __builder.AddAttribute(67, "class", "form-control");
            __builder.AddAttribute(68, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 74 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                        SelType

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(69, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SelType = __value, SelType));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(70, "option");
            __builder.AddAttribute(71, "value", "-");
            __builder.AddAttribute(72, "selected");
            __builder.AddAttribute(73, "disabled");
            __builder.AddContent(74, "Choose Type");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                        ");
            __builder.OpenElement(76, "option");
            __builder.AddAttribute(77, "value", "Audio");
            __builder.AddContent(78, "Extract Audio");
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n                        ");
            __builder.OpenElement(80, "option");
            __builder.AddAttribute(81, "value", "Video");
            __builder.AddContent(82, "Download Video");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 80 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                 if (SelType == "Video")
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(83, "div");
            __builder.AddAttribute(84, "class", "form-group col-md-6");
            __builder.AddMarkupContent(85, "<label>Quality</label>\r\n                        ");
            __builder.OpenElement(86, "select");
            __builder.AddAttribute(87, "class", "form-control");
            __builder.AddAttribute(88, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 84 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                            SelQuality

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(89, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SelQuality = __value, SelQuality));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(90, "option");
            __builder.AddAttribute(91, "value", "-");
            __builder.AddAttribute(92, "selected");
            __builder.AddAttribute(93, "disabled");
            __builder.AddContent(94, "Choose Quality");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n                            ");
            __builder.OpenElement(96, "option");
            __builder.AddAttribute(97, "value", "1080p");
            __builder.AddContent(98, "1080p");
            __builder.CloseElement();
            __builder.AddMarkupContent(99, "\r\n                            ");
            __builder.OpenElement(100, "option");
            __builder.AddAttribute(101, "value", "720p");
            __builder.AddContent(102, "720p");
            __builder.CloseElement();
            __builder.AddMarkupContent(103, "\r\n                            ");
            __builder.OpenElement(104, "option");
            __builder.AddAttribute(105, "value", "640p");
            __builder.AddContent(106, "640p");
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n                            ");
            __builder.OpenElement(108, "option");
            __builder.AddAttribute(109, "value", "360p");
            __builder.AddContent(110, "360p");
            __builder.CloseElement();
            __builder.AddMarkupContent(111, "\r\n                            ");
            __builder.OpenElement(112, "option");
            __builder.AddAttribute(113, "value", "144p");
            __builder.AddContent(114, "144p");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 93 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(115, "\r\n            ");
            __builder.OpenElement(116, "div");
            __builder.AddAttribute(117, "class", "form-row");
#nullable restore
#line 96 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                 if (SelType == "Audio" || SelType == "Video")
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(118, "div");
            __builder.AddAttribute(119, "class", "form-group col-md-6");
            __builder.AddMarkupContent(120, "<label>Format</label>\r\n                        ");
            __builder.OpenElement(121, "select");
            __builder.AddAttribute(122, "class", "form-control");
            __builder.AddAttribute(123, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 100 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                            SelFormat

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(124, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SelFormat = __value, SelFormat));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(125, "option");
            __builder.AddAttribute(126, "value", "-");
            __builder.AddAttribute(127, "selected");
            __builder.AddAttribute(128, "disabled");
            __builder.AddContent(129, "Choose Format");
            __builder.CloseElement();
#nullable restore
#line 102 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                             if (SelType == "Audio")
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(130, "option");
            __builder.AddAttribute(131, "value", "MP3");
            __builder.AddContent(132, "MP3");
            __builder.CloseElement();
            __builder.AddMarkupContent(133, "\r\n                                ");
            __builder.OpenElement(134, "option");
            __builder.AddAttribute(135, "value", "M4A");
            __builder.AddContent(136, "M4A");
            __builder.CloseElement();
            __builder.AddMarkupContent(137, "\r\n                                ");
            __builder.OpenElement(138, "option");
            __builder.AddAttribute(139, "value", "OGG");
            __builder.AddContent(140, "OGG");
            __builder.CloseElement();
#nullable restore
#line 107 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                            }
                            else if (SelType == "Video")
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(141, "option");
            __builder.AddAttribute(142, "value", "ORI");
            __builder.AddContent(143, "Original Format");
            __builder.CloseElement();
#nullable restore
#line 111 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 114 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(144, "div");
            __builder.AddAttribute(145, "class", "form-group" + " col-md-" + (
#nullable restore
#line 115 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                (SelType == "Audio" || SelType == "Video")?"6":"12"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(146, "<label class=\"text-white\">Convert</label>\r\n                    ");
            __builder.OpenElement(147, "button");
            __builder.AddAttribute(148, "class", "btn" + " btn-sm" + " btn-warning" + " text-white" + " " + (
#nullable restore
#line 117 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                                       (SelType == "Audio" || SelType == "Video")?"":"disabled"

#line default
#line hidden
#nullable disable
            ) + " ");
            __builder.AddAttribute(149, "style", "width:100%");
            __builder.AddAttribute(150, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 117 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                                                                                                                                Convert

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(151, "Convert");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(152, "\r\n\r\n            <hr>");
#nullable restore
#line 167 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
             if (!string.IsNullOrWhiteSpace(FileUrl))
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(153, "div");
            __builder.AddAttribute(154, "class", "row align-items-center justify-content-between");
            __builder.OpenElement(155, "div");
            __builder.AddAttribute(156, "class", "col-12");
            __builder.OpenElement(157, "div");
            __builder.AddAttribute(158, "class", "input-group mb-0");
            __builder.OpenElement(159, "input");
            __builder.AddAttribute(160, "type", "text");
            __builder.AddAttribute(161, "class", "form-control");
            __builder.AddAttribute(162, "placeholder", "File URL");
            __builder.AddAttribute(163, "readonly");
            __builder.AddAttribute(164, "value", 
#nullable restore
#line 172 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                                                                            FileUrl

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(165, "\r\n                            ");
            __builder.OpenElement(166, "div");
            __builder.AddAttribute(167, "class", "input-group-append");
            __builder.AddMarkupContent(168, "<button class=\"btn btn-secondary\" type=\"button\"><i class=\"fa fa-copy\"></i></button>\r\n                                ");
            __builder.OpenElement(169, "a");
            __builder.AddAttribute(170, "class", "btn btn-success active");
            __builder.AddAttribute(171, "href", 
#nullable restore
#line 175 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
                                                                         FileUrl

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(172, "target", "_blank");
            __builder.AddMarkupContent(173, "<i class=\"fa fa-download\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 180 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 186 "D:\My Projects\C# Git\AirShare\AirShare\Pages\Controls\AVConverter.razor"
       
    [Parameter] public string Path { get; set; }
    [Parameter] public FSEntry FileEntry { get; set; }
    IMediaInfo info;

    public string SelType
    {
        get
        {
            return _SelType;
        }
        set
        {
            _SelType = value;
            SelFormat = "-";
            SelQuality = "-";
        }
    }
    string _SelType;
    string FileUrl, SelFormat, SelQuality;

    string FileHashLink(string fp)
    {
        string fnme = System.IO.Path.GetFileName(fp);
        string ename = Uri.EscapeDataString(fnme);

        string H = HashLinks.AddFile(fp, 2);

        return $"{NavMan.BaseUri}hlnk/{ename}?{H}";
    }

    async void Convert()
    {
        if (SelType == "Audio")
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Tmp\", System.IO.Path.ChangeExtension(FileEntry.Name, SelFormat.ToLower()));
            if (SelFormat == "MP3")
            {
                string s = System.IO.Path.Combine(Path, FileEntry.Name);
                var res = await AVC.ExtractAudio(s, path);
                FileUrl = FileHashLink(path);
            }

        }
        else if (SelType == "Video")
        {

        }
        StateHasChanged();
    }

    async void GetInfo()
    {
        info = await AVC.GetMediaInfo(System.IO.Path.Combine(Path, FileEntry.Name));
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserData Userdata { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.NavigationManager NavMan { get; set; }
    }
}
#pragma warning restore 1591
