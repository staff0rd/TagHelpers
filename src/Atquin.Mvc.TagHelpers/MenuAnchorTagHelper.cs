using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.TagHelpers;
using Microsoft.AspNet.Mvc.ViewFeatures;

namespace Atquin.Mvc.TagHelpers
{
    [HtmlTargetElement("li", Attributes = TextAttributeName)]
    [HtmlTargetElement("li", Attributes = ControllerAttributeName)]
    [HtmlTargetElement("li", Attributes = ActionAttributeName)]
    public class MenuAnchorTagHelper : TagHelper
    {
        private const string TextAttributeName = "text";
        private const string ActionAttributeName = "action";
        private const string ControllerAttributeName = "controller";
        private const string BadgeAttributeName = "badge";

        [HtmlAttributeName(TextAttributeName)]
        public string Text { get; set; }

        [HtmlAttributeName(ControllerAttributeName)]
        public string Controller { get; set; }

        [HtmlAttributeName(ActionAttributeName)]
        public string Action { get; set; }

        [HtmlAttributeName(BadgeAttributeName)]
        public int? Badge { get; set; }

        protected IUrlHelper _urlHelper { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public MenuAnchorTagHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string actionName = ViewContext.RouteData.Values["action"].ToString().ToLower();
            string controllerName = ViewContext.RouteData.Values["controller"].ToString().ToLower();
            if (Action.ToLower() == actionName && controllerName == Controller.ToLower())
            {
                output.Attributes.Add("class", "active");
            }

            var url = _urlHelper.Action(Action, Controller);

            var text = Text;
            if (Badge.HasValue)
                text += $" <span class='badge'>{ Badge.Value }</span>";

            output.Content.SetHtmlContent($"<a href='{url}'>{text}</a>");
        }
    }
}
