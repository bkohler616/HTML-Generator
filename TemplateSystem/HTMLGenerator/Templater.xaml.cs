using System;
using System.Windows;

namespace TemplateSystem
{
    /// <summary>
    ///     Interaction logic for Templater.xaml
    ///     Templater is the main view for the template system to hold a visual design.
    ///     Most of the code will just interact with a list system.
    ///     TODO: Add side features first, then work on features that will effect the system.
    /// </summary>
    public partial class Templater : Window
    {
        public ItemTreeView ItemTree;

        public Templater()
        {
            InitializeComponent();
            ItemTree = new ItemTreeView();
        }

        /// <summary>
        ///     Start the template item list based off of a serialized object.
        /// </summary>
        /// <param name="newList"></param>
        public Templater(TemplateList newList)
        {
            InitializeComponent();
            ItemTree.TemplateItems = newList;
        }

        private void ContextMenu_AddItem_OnClick(object sender, RoutedEventArgs e)
        {
            var newItem = new ModifyItem();
            newItem.ShowDialog();
        }

        private void ContextMenu_EditForm_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void Templater_OnActivated(object sender, EventArgs e)
        {
            ItemTree.Show();
        }
    }
}