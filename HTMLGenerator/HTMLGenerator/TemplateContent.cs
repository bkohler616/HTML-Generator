namespace HTMLGenerator
{
    public abstract class TemplateContent : TemplateItem
    {
        //ItemContent
        public string Content { get; set; }

        //Margins
        public string Margins { get; set; }

        public abstract string GenerateHtml();
    }
}