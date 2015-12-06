namespace HTMLGenerator
{
    public class TemplateContentText : TemplateContent
    {
        public string StringType { get; set; }

        public TemplateContentText(string uid, string stringType, string content, string margins)
        {
            Uid = uid;
            StringType = stringType;
            Content = content;
            Margins = margins;
        }

        public override string GenerateHtml()
        {
            return "<" + StringType +
                " style=\"margin:" + Margins +
                "\" id=\"" + Uid + "\">" +
                Content + "</" + StringType + ">";
        }

        public TemplateContentText() { }
    }
}