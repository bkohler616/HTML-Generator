using System.Windows;
using System.Windows.Controls;

namespace TemplateSystem
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
    }
}