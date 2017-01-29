using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectApp.view
{
    public sealed partial class EditNote : Page
    {
        public EditNote()
        {
            InitializeComponent();
        }

        private void EditNote_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
