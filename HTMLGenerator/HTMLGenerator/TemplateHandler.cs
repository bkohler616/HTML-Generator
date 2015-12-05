using System.Collections.Generic;

namespace HTMLGenerator
{
    public abstract class TemplateHandler : TemplateItem
    {
        public List<TemplateItem> ItemHold { get; set; }
        public string StartDiv { get; set; }
        public string EndDiv { get; set; }
    }
}