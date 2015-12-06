using System.Collections.Generic;

namespace HTMLGenerator
{
    public class TemplateHandlerColumn : TemplateHandler
    {
        public List<TemplateItem> ItemHold { get; set; }
        public int NewColSize { get; set; }

        public TemplateHandlerColumn(string newUid, int newColSize)
        {
            Uid = newUid;
            NewColSize = newColSize;
            StartDiv = "<div class=\"col-md-" + NewColSize + "\">";
            EndDiv = "</div>";
        }
        public TemplateHandlerColumn() { }
    }
}