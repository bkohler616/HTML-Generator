using System.Collections.Generic;

namespace HTMLGenerator
{
    public abstract class TemplateHandler : Template
    {
        public string StartDiv { get; set; }
        public string EndDiv { get; set; }
    }
}