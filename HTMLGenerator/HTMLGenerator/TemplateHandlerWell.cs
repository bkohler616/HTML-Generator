using System.Collections.Generic;

namespace HTMLGenerator
{
    public class TemplateHandlerWell : TemplateHandler
    {

        public List<TemplateItem> ItemHold { get; set; }
        public TemplateHandlerWell(string uid)
        {
            Uid = uid;
            StartDiv = "<div id=\"uid\" class=\"well\">";
            EndDiv = "</div>";
        }
    }
}