using System.IO;
using System.Reflection;

namespace HTMLGenerator
{
    public class TemplateContentImage : TemplateContent
    {
        public TemplateContentImage(string uid, string itemLoc, string margins, string width, string height)
        {
            Content = itemLoc;
            Uid = uid;
            Margins = margins;
            Width = width;
            Height = height;
        }

        public TemplateContentImage()
        {
        }

        //Physical properties
        private string Width { get; set; }
        private string Height { get; set; }

        public override string GenerateHtml()
        {
            var fileDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory + "\\Output\\Images\\";
            var builder = "<img src=\"" + fileDir + Content + "\" style=\"Height:" + Height +
                          ";Width:" + Width + ";\">";

            return builder;
        }
    }
}