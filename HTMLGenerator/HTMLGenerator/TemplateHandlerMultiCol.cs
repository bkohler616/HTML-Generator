namespace HTMLGenerator
{
    public class TemplateHandlerMultiCol : TemplateHandler
    {
        public TemplateHandlerColumn[] ColumnArray { get; set; }
        
        public int ColAmount { get; set; }
        /// <summary>
        ///     Column array can only be 2-4.
        /// </summary>
        /// <param name="colAmount"></param>
        /// <returns></returns>
        public TemplateHandlerMultiCol(string uid, int colAmount)
        {
            Uid = uid;
            ColAmount = colAmount;
            ColumnArray = new TemplateHandlerColumn[colAmount];
            int colSize = 12/ColAmount;
            for (int i = 1; i < ColAmount; i++)
            {
                ColumnArray[i] = new TemplateHandlerColumn("column" + i, colSize);
            }
        }
    }
}