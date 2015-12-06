namespace HTMLGenerator
{
    public abstract class TemplateItem
    {
        /// <summary>
        ///     The Unique ID of the item. (should be required when making a template item)
        /// </summary>
        public string Uid { get; set; }
        public int Depth { get; set; }

        public static string BuildHelper(TemplateItem item)
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
            else if (item is TemplateContentText)
            {
                //TODO: Finish Text (see Modify Item for more to finish)
            }
            else if (item is TemplateContentImage)
            {
                //TODO: Finish Image (add reference images)
            }

            return builder;
        }
    }
}