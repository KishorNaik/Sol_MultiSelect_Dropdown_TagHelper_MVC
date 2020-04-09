using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sol_Demo.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("multi-select")]
    public class MultiSelectRazorTagHelper : TagHelper
    {
        private readonly IHtmlHelper htmlHelper = null;

        private const string ItemSourceAttributeName = "item-source";
        private const string SelectedItemsAttributeName = "selected-items";
        private const string ClassAttributeName = "class";

        public MultiSelectRazorTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        [HtmlAttributeName(ItemSourceAttributeName)]
        public IEnumerable<SelectListItem> ItemSource { set; get; }

        [HtmlAttributeName(SelectedItemsAttributeName)]
        public ModelExpression SelectedItems { set; get; }

        [HtmlAttributeName(ClassAttributeName)]
        public String Class { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var content = await htmlHelper?.PartialAsync("~/TagHelpers/_MultiSelectPartialView.cshtml", this);

            output.Content.SetHtmlContent(content);
        }
    }
}
