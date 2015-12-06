using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

        public ItemTreeView(TemplateList oldList)
        {
            TemplateItems = oldList;
            RefreshList();
        }

        private void AddItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newItem = new ModifyItem(TemplateItems);
            Thread.Sleep(300);
            newItem.ShowDialog();
            if (!newItem.AcceptChange) return;
            switch (newItem.CbItemType.Text)
            {
                case "Item Handler":
                    //New Item Handler
                    switch (newItem.CbItem.Text)
                    {
                        case "Well":
                            var newWell = new TemplateHandlerWell (newItem.TbUid.Text);
                            TemplateItems.Add(newWell);
                            ItemTree.Items.Add(new TreeViewItem {Header = newWell.Uid});
                            break;
                        /*case "Multiple Columns":
                            //TODO: Work on multicolumn
                            var newMultiColumn = new TemplateHandlerMultiCol { Uid = newItem.TbUid.Text };
                            //TemplateItems.Add(newMultiColumn);
                            break;*/
                        default:
                            MessageBox.Show("Not adding item. Item of type \"" +
                                            newItem.CbItem.Text +
                                            "\" Does not exist/Not yet added.");
                            break;
                    }
                    break;
                case "Item Content":
                    //New Item content
                    switch (newItem.CbItem.Text)
                    {
                        case "Text":
                            var newText = new TemplateContentText
                            {
                                Uid = newItem.TbUid.Text,
                                Content = newItem.ItemContent,
                                MarginBottom = Convert.ToInt32(newItem.TbMarginBottom.Text),
                                MarginTop = Convert.ToInt32(newItem.TbMarginTop.Text),
                                MarginLeft = Convert.ToInt32(newItem.TbMarginLeft.Text),
                                MarginRight = Convert.ToInt32(newItem.TbMarginRight.Text)
                            };
                            TemplateItems.Add(newText);
                            ItemTree.Items.Add(new TreeViewItem { Header = newText.Uid });
                            break;
                        case "Image":
                            var newImage = new TemplateContentImage { Uid = newItem.TbUid.Text,
                                Content = newItem.ItemContent,
                                MarginBottom = Convert.ToInt32(newItem.TbMarginBottom.Text),
                                MarginTop = Convert.ToInt32(newItem.TbMarginTop.Text),
                                MarginLeft = Convert.ToInt32(newItem.TbMarginLeft.Text),
                                MarginRight = Convert.ToInt32(newItem.TbMarginRight.Text)
                            };
                            TemplateItems.Add(newImage);
                            ItemTree.Items.Add(new TreeViewItem { Header = newImage.Uid });
                            break;
                        default:
                            MessageBox.Show("Not adding item. Item of type \"" +
                                            newItem.CbItem.Text +
                                            "\" Does not exist.");
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Critical error on adding item! No item type selected");
                    break;
            }

            RefreshList();
        }

        private void WindowMovement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void RefreshList()
        {
            ItemTree.Items.Clear();

            foreach (var item in TemplateItems.TemplateItems)
            {
                ItemTree.Items.Add(new TreeViewItem {Header = item.Uid});
            }
        }
    }
}