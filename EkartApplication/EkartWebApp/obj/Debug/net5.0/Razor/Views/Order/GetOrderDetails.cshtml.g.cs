#pragma checksum "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dcd70c656561e868231c20e7bc3e67b68a832c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_GetOrderDetails), @"mvc.1.0.view", @"/Views/Order/GetOrderDetails.cshtml")]
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
#line 1 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\_ViewImports.cshtml"
using EkartWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\_ViewImports.cshtml"
using EkartWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dcd70c656561e868231c20e7bc3e67b68a832c6", @"/Views/Order/GetOrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17a5349cd7acd5454ff1710dd775ac0aacea6f71", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_GetOrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EkartCommon.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlaceOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
  
    ViewData["Title"] = "GetOrderDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h4>OrderDetails</h4>
<hr />
<div class=""container"">
    <div class=""row"">
        <div class=""col-12 col-md-4"">
            <div class=""card "">
                <div class=""card-header bg-primary font-weight-bold text-white"">
                    <label class=""card-text"">Order Details</label>
                </div>
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-12"">
                            <label for=""orderId"" class=""font-weight-bold"">OrderID:</label>
                            <span id=""orderId"" class=""card-text"">");
#nullable restore
#line 19 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                            Write(Model.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-12"">
                            <label for=""Date Time"" class=""font-weight-bold"">Date Time</label>
                            <span id=""Date Time"" class=""card-text"">");
#nullable restore
#line 25 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                              Write(Model.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-12"">
                            <label for=""OrderAmount"" class=""font-weight-bold"">OrderAmount</label>
                            <span id=""OrderAmount"" class=""card-text"">");
#nullable restore
#line 31 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                                Write(Model.OrderAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-12"">
                            <label for=""OrderExpDD"" class=""font-weight-bold"">Expected Date</label>
                            <span id=""OrderExpDD"" class=""card-text"">");
#nullable restore
#line 37 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                               Write(Model.ExceptedDeliveryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-12 col-md-4"">
            <div class="" card "">
                <div class=""card-header bg-primary font-weight-bold text-white"">
                    <label class=""card-text"">
                        customer Details
                    </label>
                </div>
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-12 "">
                            <label for=""customerName "" class=""font-weight-bold"">Customer Name:</label>
                            <span id=""customerName"">");
#nullable restore
#line 54 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                               Write(Model.Customer.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                        <div class=""col-12 "">
                            <label for=""customerMobileNo "" class=""font-weight-bold"">CustomerMobile No:</label>
                            <span id=""customerMobileNo"">");
#nullable restore
#line 58 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                   Write(Model.Customer.CustomerMobileNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"col-12 \">\r\n                            <label for=\"customerEmailId\" class=\"font-weight-bold\">CustomerEmailID:</label>\r\n                            <span id=\"customerEmailId\">");
#nullable restore
#line 62 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                  Write(Model.Customer.EmailID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-12 col-md-4"">
            <div class="" card "">
                <div class=""card-header bg-primary font-weight-bold text-white"">
                    <label class=""card-text"">
                        customer Address Details
                    </label>
                </div>
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-12 "">
                            <label for=""stName"" class=""font-weight-bold"">Street Name:</label>
                            <span id=""stName"">");
#nullable restore
#line 79 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                         Write(Model.Customer.CustomerAddress.StName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"col-12 \">\r\n                            <label for=\"City\" class=\"font-weight-bold\">City:</label>\r\n                            <span id=\"city\">");
#nullable restore
#line 83 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                       Write(Model.Customer.CustomerAddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"col-12 \">\r\n                            <label for=\"State\" class=\"font-weight-bold\">State:</label>\r\n                            <span id=\"State\">");
#nullable restore
#line 87 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                        Write(Model.Customer.CustomerAddress.State);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="" row "">
        <div class="" col-12"">
            <div class="" card my-3"">
                <div class=""card-header bg-success"">
                    <label class=""font-weight-bold text-white"">Cart Item</label>
                </div>
                <div class=""card-body"">
                    <div class="" table-responsive"">
                        <table class=""table"" width=""100%"">
                            <thead>
                                <tr>
                                    <th>Price</th>
                                    <th>Qty</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 110 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                 foreach (var item in Model.OrderItems)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>&#x20B9 ");
#nullable restore
#line 113 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 114 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                       Write(item.Qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 116 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div>
                <div class=""card-footer"">
                    <div class="" d-flex justify-content-between"">
                        <div class=""font-weight-bold"">Order Total:</div>
                        <div class=""font-weight-bold"">
                            &#x20B9 ");
#nullable restore
#line 125 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                               Write(Model.OrderAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 132 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
     if(Model.OrderStatus.OrderStatusId == (int)EkartCommon.Models.OrderstatusType.ORDERECEVIED)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3dcd70c656561e868231c20e7bc3e67b68a832c615175", async() => {
                WriteLiteral("\r\n            Add To Delivery\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 134 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
                                                                                                   WriteLiteral(Model.OrderId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 137 "E:\.NET\Application\EkartApplication\EkartWebApp\Views\Order\GetOrderDetails.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3dcd70c656561e868231c20e7bc3e67b68a832c617934", async() => {
                WriteLiteral("Back To Delivery");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EkartCommon.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
