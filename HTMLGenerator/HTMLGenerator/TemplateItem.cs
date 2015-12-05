﻿namespace HTMLGenerator
{
    public abstract class TemplateItem
    {
        /// <summary>
        ///     The Unique ID of the item. (should be required when making a template item)
        /// </summary>
        public string Uid { get; set; }
        public int Depth { get; set; }
    }
}