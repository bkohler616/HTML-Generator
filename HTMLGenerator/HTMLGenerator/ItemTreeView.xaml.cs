using System;
using System.ComponentModel;
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
            ItemTree.Items.Add(new TreeViewItem {Header = "help"});
        }

        private void AddItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            ModifyItem newItem = new ModifyItem();
            bool newItemUnique = false;
            while (newItemUnique == false)
            {
                Thread.Sleep(300);
                newItem.ShowDialog();
                if (!newItem.AcceptChange) break;
                switch (newItem.CbItemType.Text)
                {
                    case "Item Handler":
                        //New Item Handler
                        switch (newItem.CbItem.Text)
                        {
                            case "Column":
                                TemplateHandlerColumn newColumn = new TemplateHandlerColumn();
                                break;
                            case "Well":
                                TemplateHandlerWell newWell = new TemplateHandlerWell();
                                newWell.Uid = newItem.TbUid.Text;
                                if (!TemplateItems.Add(newWell))
                                {
                                    MessageBox.Show("Error. Name not unique as there is another item with the same name");
                                }
                                else
                                {
                                    newItemUnique = true;
                                    //return;

                                }
                                break;
                            case "Multiple Columns":

                                break;
                            default:
                                MessageBox.Show("Not adding item. Item of type \"" +
                                                newItem.CbItem.Text +
                                                "\" Does not exist.");
                                break;
                        }
                        break;
                    case "Item Content":
                        //New Item content
                        switch (newItem.CbItem.Text)
                        {
                            case "Text":

                                break;
                            case "Image":

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
            }
        }

        private void WindowMovement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}