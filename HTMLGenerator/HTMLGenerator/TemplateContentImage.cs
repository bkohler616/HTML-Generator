namespace HTMLGenerator
{
    public class TemplateContentImage : TemplateContent
    {
        //Physical properties
        public string Width { get; set; }
        public string Height { get; set; }

        public TemplateContentImage(string uid, string itemLoc, string margins, string width, string height)
        {
            Content = itemLoc;
            Uid = uid;
            Margins = margins;
            Width = width;
            Height = height;
        }

        public override string GenerateHtml()
        {
            //TODO: Finish generation of images. (first move images to directory)
            string builder = "<";

            return builder;
        }
    }
}