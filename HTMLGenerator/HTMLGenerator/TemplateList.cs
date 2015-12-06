using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace HTMLGenerator
{
    /// <summary>
    ///     The purpose of this class is to contain a list of data that will hold all of the information for every object
    ///     within the template.
    ///     TODO: Add class content.
    /// </summary>
    [XmlInclude(typeof (TemplateItem))]
    [XmlInclude(typeof (TemplateHandler))]
    [XmlInclude(typeof (TemplateHandlerColumn))]
    [XmlInclude(typeof (TemplateHandlerMultiCol))]
    [XmlInclude(typeof (TemplateHandlerWell))]
    [XmlInclude(typeof (TemplateContent))]
    [XmlInclude(typeof (TemplateContentText))]
    [XmlInclude(typeof (TemplateContentImage))]
    public class TemplateList
    {
        public List<TemplateItem> TemplateItems { get; set; }

        public TemplateList()
        {
            TemplateItems = new List<TemplateItem>();
        }

        public bool Add(TemplateItem newItem)
        {
            try
            {
                if (TemplateItems.Any(item => item.Uid == newItem.Uid))
                {
                    return false;
                }
                TemplateItems.Add(newItem);
                return true;
            }
            catch (ArgumentNullException e)
            {
                return false;
            }
            
        }
    }
}