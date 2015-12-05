using System.Windows;

namespace HTMLGenerator
{
    /// <summary>
    ///     Interaction logic for StringInputWindow.xaml
    ///     This will be the input window for the name of templates (which we can send to the file save to set as the
    ///     default file name), and will also be the text editor for any sort of content that the user wants to put into the
    ///     templates.
    /// </summary>
    public partial class StringInputWindow : Window
    {
        public StringInputWindow()
        {
            InitializeComponent();
        }

        public StringInputWindow(string content)
        {
            InitializeComponent();
            ContentEditor.Text = content;
        }
    }
}