using System.Collections.Generic;

namespace HTMLGenerator
{
    public abstract class TemplateHandler : TemplateItem
    {
        public string StartDiv { get; set; }
        public string EndDiv { get; set; }
    }
}