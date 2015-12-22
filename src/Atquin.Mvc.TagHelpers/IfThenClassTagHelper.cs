using Microsoft.AspNet.Razor.TagHelpers;

namespace Atquin.Mvc.TagHelpers
{
    [HtmlTargetElement("span", Attributes = IfAttributeName)]
    [HtmlTargetElement("span", Attributes = ThenClassAttributeName)]
    public class IfThenClassTagHelper : TagHelper
    {
        private const string IfAttributeName = "if";
        private const string ThenClassAttributeName = "then-class";

        [HtmlAttributeName(IfAttributeName)]
        public bool If { get; set; }

        [HtmlAttributeName(ThenClassAttributeName)]
        public string ThenClass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (If)
                output.Attributes.Add("class", ThenClass);
        }
    }
}
