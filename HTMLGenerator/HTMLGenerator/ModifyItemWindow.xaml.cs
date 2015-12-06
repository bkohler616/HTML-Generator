using System;
using System.Windows;
using System.Windows.Controls;

namespace HTMLGenerator
{
    /// <summary>
    ///     Interaction logic for ModifyItem.xaml
    ///     Modify Item will be used for adding and modifying individual items within Templater. We should pass the information
    ///     from TemplateItemList
    ///     To here if we need to make references for the objects.
    /// </summary>
    public partial class ModifyItem : Window
    {
        public string ItemContent = "";
        private readonly TemplateList _tempListHold;
        public bool AcceptChange;
        public string MarginHolder = "";
        public string TypeHolder = "";

        //TODO: Finish Type Selector (CbTypeSelector)

        public ModifyItem(TemplateList oldList)
        {
            InitializeComponent();
            _tempListHold = oldList;
        }

        private void ContentButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newString = new StringInputWindow(ItemContent);
            newString.ShowDialog();
            ItemContent = newString.ContentEditor.Text;
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_tempListHold.Check(TbUid.Text))
            {
                MessageBox.Show("There's an item with that name already. Try a different name!");
            }
            else
            {
                AcceptChange = true;
                MarginHolder = TbMarginTop.Text + "px " +
                    TbMarginRight.Text + "px " +
                    TbMarginBottom.Text + "px " +
                    TbMarginLeft.Text + "px ";
                if (CbTypeSelector.SelectedItem.Equals("Paragraph"))
                {
                    TypeHolder = "p";
                } else if (CbTypeSelector.SelectedItem.Equals("Heading 1"))
                {
                    TypeHolder = "h1";
                }
                else if (CbTypeSelector.SelectedItem.Equals("Heading 2"))
                {
                    TypeHolder = "h2";
                }
                else if (CbTypeSelector.SelectedItem.Equals("Heading 3"))
                {
                    TypeHolder = "h3";
                }
                else if (CbTypeSelector.SelectedItem.Equals("Heading 4"))
                {
                    TypeHolder = "h4";
                }
                Close();
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            AcceptChange = false;
            Close();
        }

        private void CbItemType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbItem.IsEnabled = true;
            CbItem.Items.Clear();
            if (CbItemType.SelectedIndex == 0)
            {
                //Item Handlers
                
                CbItem.Items.Add("Well");
                CbItem.Items.Add("Multiple Columns");
            }
            else
            {
                CbItem.Items.Add("Text");
                CbItem.Items.Add("Image");
            }
        }

        private void CbItem_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Enable Accept button (Any item selected by now should be a valid item)
            BtnAccept.IsEnabled = true;
            //Margins. (always enabled, only placed here to enable them initially)
            TbMarginBottom.IsEnabled = true;
            TbMarginLeft.IsEnabled = true;
            TbMarginTop.IsEnabled = true;
            TbMarginRight.IsEnabled = true;

            //Disable possibly unused items
            BtnEditContent.IsEnabled = false;
            TbHeight.IsEnabled = false;
            TbWidth.IsEnabled = false;
            CbTypeSelector.IsEnabled = false;
            CbTypeSelector.Items.Clear();

            //Clear info post
            TbInfoPost.Text = "";
            try
            {
                //Handlers
                if (CbItem.SelectedItem.Equals("Column"))
                {
                    TbInfoPost.Text = "Warning! This object is a handler.\n There will not be much to edit.";
                }
                else if (CbItem.SelectedItem.Equals("Well"))
                {
                    TbInfoPost.Text = "Warning! This object is a handler.\n There will not be much to edit.";
                }
                else if (CbItem.SelectedItem.Equals("Multiple Columns"))
                {
                    TbInfoPost.Text = "Warning! This object is a handler.\n There will not be much to edit.";
                }
                //Content
                else if (CbItem.SelectedItem.Equals("Text"))
                {
                    TbInfoPost.Text = "Please select a type for your text type";
                    BtnEditContent.IsEnabled = true;
                    CbTypeSelector.IsEnabled = true;
                    CbTypeSelector.Items.Add("Paragraph");
                    CbTypeSelector.Items.Add("Heading 1");
                    CbTypeSelector.Items.Add("Heading 2");
                    CbTypeSelector.Items.Add("Heading 3");
                    CbTypeSelector.Items.Add("Heading 4");
                    BtnAccept.IsEnabled = false; //Deactivated because a text type needs to be selected.
                }
                else if (CbItem.SelectedItem.Equals("Image"))
                {
                    BtnEditContent.IsEnabled = true;
                    TbHeight.IsEnabled = true;
                    TbWidth.IsEnabled = true;
                }
            }
            catch (NullReferenceException)
            { }

        }


        private void CbTypeSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Can assume that everything is prepared now.
            BtnAccept.IsEnabled = true;
        }
    }
}