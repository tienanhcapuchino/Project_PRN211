#pragma checksum "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "512070ef14786bb527167cf817e8ed1a7b5bd1d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Header), @"mvc.1.0.view", @"/Views/Shared/Header.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"512070ef14786bb527167cf817e8ed1a7b5bd1d4", @"/Views/Shared/Header.cshtml")]
    #nullable restore
    public class Views_Shared_Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<header>
    <!-- header inner -->
    <div class=""header"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-3 col logo_section"">
                    <div class=""full"">
                        <div class=""center-desk"">
");
#nullable restore
#line 11 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                             if (ViewBag.Users is not null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"logo\">\r\n                                    <a style=\"font-size: 25px;\" href=\"/Home/Admin\">Tien Anh Capuchino</a>\r\n                                </div>\r\n");
#nullable restore
#line 16 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"logo\">\r\n                                    <a style=\"font-size: 25px;\" href=\"Home\">Tien Anh Capuchino</a>\r\n                                </div>\r\n");
#nullable restore
#line 22 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </div>
                <div class=""col-xl-9 col-lg-9 col-md-9 col-sm-9"">
                    <nav class=""navigation navbar navbar-expand-md navbar-dark "">
                        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarsExample04"" aria-controls=""navbarsExample04"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                            <span class=""navbar-toggler-icon""></span>
                        </button>
                        <div class=""collapse navbar-collapse"" id=""navbarsExample04"">
                            <ul class=""navbar-nav mr-auto"">
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#about"">About</a>
                                </li>
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#contact"">Contact us</a>
       ");
            WriteLiteral("                         </li>\r\n");
#nullable restore
#line 40 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                                 if (ViewBag.Users is not null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"nav-item\" style=\"color: aliceblue;\">\r\n                                        Hello: ");
#nullable restore
#line 43 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                                           Write(ViewBag.Users);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </li>\r\n");
#nullable restore
#line 45 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n");
#nullable restore
#line 47 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                             if (ViewBag.Users is null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"sign_btn\"><a href=\"/Home/Login\">Login</a></div>\r\n");
#nullable restore
#line 50 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""sign_btn""><a href=""/Home/logOut"">Log out</a></div>
                                <div class=""sign_btn"">
                                    <div class=""dropdown"">
                                        <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                            Menu
                                        </button>
                                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                                            <a class=""dropdown-item"" href=""/Employee/UpdateProfile"">Profile</a>
                                            <a class=""dropdown-item"" href=""/Employee/ChangePass"">Change password</a>
                                        </div>
                                    </div>
                                </div>
");
#nullable restore
#line 65 "D:\FPT University\SUMMER 2022\PRN211\Project\Project_PRN211\Project_PRN211\Views\Shared\Header.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</header>
<!-- end header inner -->
<!-- end header -->
<!-- banner -->
<section class=""banner_main"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""text-bg"">
                    <div class=""padding_lert"">
                        <h1>WELCOME TO Tien Anh Capuchino'S HOTEL</h1>
                        <span>Established in 2022</span>
                        <p>This hotel is established based on project subject PRN211. It is also a self-catering hotel with only one employee and all positions</p>
                        <a href=""https://tienanhcapuchino.github.io/info_of_tienanh/"">More Infomation</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
