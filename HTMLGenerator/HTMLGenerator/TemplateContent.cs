namespace HTMLGenerator
{
    public abstract class TemplateContent : TemplateItem
    {
        //ItemContent
        public string Content { get; set; }

        //Margins
        public int MarginTop { get; set; }
        public int MarginLeft { get; set; }
        public int MarginRight { get; set; }
        public int MarginBottom { get; set; }
    }
}