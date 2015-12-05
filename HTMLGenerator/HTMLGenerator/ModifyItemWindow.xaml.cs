using System.Windows;

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

        public bool AcceptChange;

        public ModifyItem()
        {
            InitializeComponent();
        }

        private void ContentButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newString = new StringInputWindow(ItemContent);
            newString.ShowDialog();
            ItemContent = newString.ContentEditor.Text;
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            AcceptChange = true;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            AcceptChange = false;
            Close();
        }
    }
}