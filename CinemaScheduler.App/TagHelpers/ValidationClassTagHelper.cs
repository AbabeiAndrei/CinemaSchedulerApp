using System.Linq;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CinemaScheduler.App.TagHelpers
{
    [HtmlTargetElement("div", Attributes = VALIDATION_FOR_ATTRIBUTE_NAME + "," + VALIDATION_ERROR_CLASS_NAME)]
    public class ValidationClassTagHelper : TagHelper
    {
        private const string VALIDATION_FOR_ATTRIBUTE_NAME = "pf-validation-for";
        private const string VALIDATION_ERROR_CLASS_NAME = "pf-validationerror-class";

        [HtmlAttributeName(VALIDATION_FOR_ATTRIBUTE_NAME)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(VALIDATION_ERROR_CLASS_NAME)]
        public string ValidationErrorClass { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ViewContext.ViewData.ModelState.TryGetValue(For.Name, out var entry);

            if (entry == null || !entry.Errors.Any()) 
                return;

            var tagBuilder = new TagBuilder("div");

            tagBuilder.AddCssClass(ValidationErrorClass);
            output.MergeAttributes(tagBuilder);
        }
    }
}
