using System.Windows;

namespace TemplateSystem
{
    /// <summary>
    ///     Interaction logic for ModifyItem.xaml
    ///     Modify Item will be used for adding and modifying individual items within Templater. We should pass the information
    ///     from TemplateItemList
    ///     To here if we need to make references for the objects.
    /// </summary>
    public partial class ModifyItem : Window
    {
        private string _content = "";

        private bool acceptChange;

        public ModifyItem()
        {
            InitializeComponent();
        }

        private void ContentButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newString = new StringInputWindow(_content);
            newString.ShowDialog();
            _content = newString.ContentEditor.Text;
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            acceptChange = true;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            acceptChange = false;
            Close();
        }
    }
}