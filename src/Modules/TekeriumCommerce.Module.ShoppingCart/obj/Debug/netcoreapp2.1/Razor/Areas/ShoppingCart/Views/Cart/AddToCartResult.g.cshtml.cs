#pragma checksum "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a5aa7cc6ef6cc1afb6a59cde22feb3a77630d81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ShoppingCart_Views_Cart_AddToCartResult), @"mvc.1.0.view", @"/Areas/ShoppingCart/Views/Cart/AddToCartResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ShoppingCart/Views/Cart/AddToCartResult.cshtml", typeof(AspNetCore.Areas_ShoppingCart_Views_Cart_AddToCartResult))]
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
#line 1 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a5aa7cc6ef6cc1afb6a59cde22feb3a77630d81", @"/Areas/ShoppingCart/Views/Cart/AddToCartResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7976ffb29ac9a08b0e32b8b5be67fb7dde55dab", @"/Areas/ShoppingCart/Views/_ViewImports.cshtml")]
    public class Areas_ShoppingCart_Views_Cart_AddToCartResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels.AddToCartResult>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(91, 357, true);
            WriteLiteral(@"
<div class=""modal-header"">
    <h5 class=""modal-title"" id=""myModalLabel"">The product has been added to your cart</h5>
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
</div>
<div class=""modal-body"">
    <div class=""row"">
        <div class=""col-md-3"">
            <img");
            EndContext();
            BeginWriteAttribute("alt", " alt=\"", 448, "\"", 472, 1);
#line 10 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
WriteAttributeValue("", 454, Model.ProductName, 454, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(473, 18, true);
            WriteLiteral(" class=\"img-fluid\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 491, "\"", 516, 1);
#line 10 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
WriteAttributeValue("", 497, Model.ProductImage, 497, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(517, 67, true);
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <h4>");
            EndContext();
            BeginContext(585, 17, false);
#line 13 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
           Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(602, 23, true);
            WriteLiteral("</h4>\r\n            <h6>");
            EndContext();
            BeginContext(626, 19, false);
#line 14 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
           Write(Model.VariationName);

#line default
#line hidden
            EndContext();
            BeginContext(645, 67, true);
            WriteLiteral("</h6>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
            EndContext();
            BeginContext(713, 14, false);
#line 17 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
       Write(Model.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(727, 3, true);
            WriteLiteral(" x ");
            EndContext();
            BeginContext(731, 32, false);
#line 17 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
                         Write(Model.ProductPrice.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(763, 136, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-7\">\r\n            You have <span class=\"cart-item-count\">");
            EndContext();
            BeginContext(900, 19, false);
#line 22 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
                                              Write(Model.CartItemCount);

#line default
#line hidden
            EndContext();
            BeginContext(919, 106, true);
            WriteLiteral("</span> products in your cart\r\n        </div>\r\n        <div class=\"col-md-5\">\r\n            Cart Subtotal: ");
            EndContext();
            BeginContext(1026, 30, false);
#line 25 "C:\Users\Miri\Desktop\tekerium\Failed\tekeriumcommerce\src\Modules\TekeriumCommerce.Module.ShoppingCart\Areas\ShoppingCart\Views\Cart\AddToCartResult.cshtml"
                      Write(Model.CartAmount.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(1056, 167, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-light\" data-dismiss=\"modal\">Continue shopping</button>\r\n    ");
            EndContext();
            BeginContext(1223, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2188b24b7a7e439ba500b537bc39f208", async() => {
                BeginContext(1276, 9, true);
                WriteLiteral("View cart");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1289, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TekeriumCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels.AddToCartResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
