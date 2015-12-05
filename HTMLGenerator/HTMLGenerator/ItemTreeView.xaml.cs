using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HTMLGenerator
{
    /// <summary>
    ///     Interaction logic for ItemTreeView.xaml
    /// </summary>
    public partial class ItemTreeView : Window
    {
        public TemplateList TemplateItems;

        public ItemTreeView()
        {
            InitializeComponent();
            TemplateItems = new TemplateList();
            ItemTree.Items.Add(new TreeViewItem {Header = "help"});
        }

        private void AddItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            ModifyItem newItem = new ModifyItem();
            newItem.ShowDialog();
            if (newItem.AcceptChange)
            {
                
            }
        }

        private void ItemTreeView_OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}