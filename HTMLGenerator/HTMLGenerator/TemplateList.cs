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
        public List<TemplateItem> TemplateItems { get; }

        public TemplateList()
        {
            TemplateItems = new List<TemplateItem>();
        }

        public bool Check(string newUid)
        {
            try
            {
                return TemplateItems.All(item => item.Uid != newUid);
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            
        }

        public void Add(TemplateItem newItem)
        {
            TemplateItems.Add(newItem);
        }
    }
}