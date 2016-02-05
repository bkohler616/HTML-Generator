namespace HTMLGenerator
{
    public abstract class Template
    {
        /// <summary>
        ///     The Unique ID of the item. (should be required when making a template item)
        /// </summary>
        public string Uid { get; set; }
        public int Depth { get; set; }

        public static string BuildHelper(Template item)
        {
            string builder = "";

            //Check if handler
            if (item is TemplateHandlerWell)
            {
                var tempItem = (TemplateHandlerWell) item;
                builder += tempItem.StartDiv;
                foreach (var newItem in tempItem.ItemHold)
                {
                    //TODO: Add depth according to ItemTree
                }
                builder += tempItem.EndDiv;
            }
            else if (item is TemplateHandlerMultiCol)
            {
                var tempItem = (TemplateHandlerMultiCol)item;
                builder += tempItem.StartDiv;
                foreach (var newItem in tempItem.ColumnArray)
                {
                    //TODO: Add depth according to ItemTree
                }
                builder += tempItem.EndDiv;
            }
            else if (item is TemplateHandlerColumn)
            {
                var tempItem = (TemplateHandlerWell)item;
                builder += tempItem.StartDiv;
                foreach (var newItem in tempItem.ItemHold)
                {
                    //TODO: Add depth according to ItemTree
                }
                builder += tempItem.EndDiv;
            }
            //Item Content
            else if (item is TemplateContentText)
            {
                var tempItem = (TemplateContentText) item;
                builder += tempItem.GenerateHtml();
            }
            else if (item is TemplateContentImage)
            {
                var tempItem = (TemplateContentImage)item;
                builder += tempItem.GenerateHtml();
            }

            return builder;
        }
    }
}