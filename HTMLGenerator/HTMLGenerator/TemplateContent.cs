namespace HTMLGenerator
{
    public abstract class TemplateContent : Template
    {
        //ItemContent
        public string Content { get; set; }

        //Margins
        public string Margins { get; set; }

        public abstract string GenerateHtml();
    }
}